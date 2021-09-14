using MartianRobots.Engine.Engine;
using MartianRobots.Engine.Parser;
using MartianRobots.Engine.Models;
using MartianRobots.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MartianRobots.Domain.Interfaces;
using MartianRobots.Domain.DomainEntities;

namespace MartianRobots.Controllers
{
    /// <summary>
    /// Default controller that can execute martian worlds and show a list of historical executions
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor of the HomeController, used for the dependency injection
        /// </summary>
        /// <param name="logger">microsoft logger object</param>
        /// <param name="unitOfWork">unitOf work object</param>
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Index page that serves the form
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Index page that recieves the input and returns the page with th result
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(MartianModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MartianWorld martianWorld = MartianWorldParser.Parse(model.WorldInput);

                    if (martianWorld.ParsingErrors.Any())
                    {
                        foreach (var error in martianWorld.ParsingErrors)
                        {
                            ModelState.AddModelError(nameof(model.WorldInput), error);
                        }
                    }
                    else
                    {
                        model.WorldResult = MartianWorldEngine.Execute(martianWorld);

                        StoreExecution(model);

                    }
                }
            }
            catch (Exception ex)
            {
                //TODO: Log exception
                return View("Error", new ErrorViewModel(ex));
            }

            return View(model);
        }

        /// <summary>
        /// Page that returns the last 10 executions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> History()
        {
            List<MartianWorldHistory> historyList = new();

            try
            {
                var entityList = await _unitOfWork.MartianWorlds.GetLastTenMartianWorlds();

                foreach (var entity in entityList)
                {
                    MartianWorldHistory historyItem = new();
                    historyItem.WorldInput = entity.Input;
                    historyItem.WorldResult = entity.Output;
                    historyItem.ExecutionDate = entity.ExecutionDate;

                    historyList.Add(historyItem);
                }
            }
            catch (Exception ex)
            {
                //TODO: Log exception
                return View("Error", new ErrorViewModel(ex));
            }

            return View(historyList);
        }

        private void StoreExecution(MartianModel model)
        {
            MartianWorldEntity entity = new();
            entity.Input = model.WorldInput;
            entity.Output = string.Join(Environment.NewLine, model.WorldResult);
            entity.ExecutionDate = DateTime.Now;

            _unitOfWork.MartianWorlds.Add(entity);
            _unitOfWork.Complete();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { Exception = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
