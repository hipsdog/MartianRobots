using MartialRobots.Engine.Engine;
using MartialRobots.Engine.Parser;
using MartialRobots.Engine.Models;
using MartialRobots.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MartialRobots.Domain.Interfaces;
using MartialRobots.Domain.DomainEntities;

namespace MartialRobots.Controllers
{
    /// <summary>
    /// Default controller that can execute martial worlds and show a list of historical executions
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
        public IActionResult Index(MartialModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MartialWorld martialWorld = MartialWorldParser.Parse(model.WorldInput);

                    if (martialWorld.ParsingErrors.Any())
                    {
                        foreach (var error in martialWorld.ParsingErrors)
                        {
                            ModelState.AddModelError(nameof(model.WorldInput), error);
                        }
                    }
                    else
                    {
                        model.WorldResult = MartialWorldEngine.Execute(martialWorld);

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
            List<MartialWorldHistory> historyList = new();

            try
            {
                var entityList = await _unitOfWork.MartialWorlds.GetLastTenMartialWorlds();

                foreach (var entity in entityList)
                {
                    MartialWorldHistory historyItem = new();
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

        private void StoreExecution(MartialModel model)
        {
            MartialWorldEntity entity = new();
            entity.Input = model.WorldInput;
            entity.Output = string.Join(Environment.NewLine, model.WorldResult);
            entity.ExecutionDate = DateTime.Now;

            _unitOfWork.MartialWorlds.Add(entity);
            _unitOfWork.Complete();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { Exception = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
