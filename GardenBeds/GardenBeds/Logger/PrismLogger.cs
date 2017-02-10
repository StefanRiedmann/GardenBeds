using System.Diagnostics;
using Prism.Logging;

namespace GardenBeds.Logger
{
    public class PrismLogger : ILoggerFacade
    {
        public void Log(string message, Category category, Priority priority)
        {
            Debug.WriteLine($"{priority}, {category}, {message}");
        }
    }
}