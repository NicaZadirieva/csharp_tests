using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserMock
{
    internal class Program
    {
        static void Main()
        {
            var services = new ServiceCollection();

            services.AddLogging(builder =>
            {
                builder.AddConsole();          // <-- без этого логов не будет
                builder.SetMinimumLevel(LogLevel.Trace);
            });

           

            Console.WriteLine("Готово. Нажмите Enter...");
            Console.ReadLine();
        }
    }
}
