using System;

namespace MartialRobots.Models
{
    /// <summary>
    /// ErrorViewModel.
    /// </summary>
    public class ErrorViewModel
    {
        public ErrorViewModel()
        {

        }

        public ErrorViewModel(Exception exception)
        {
            this.ExceptionMessage = exception.Message;
            this.Exception = exception.ToString();
            this.ShowException = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
        }

        public string ExceptionMessage { get; set; }
        public string Exception { get; set; }
        public bool ShowException { get; set; }
    }
}
