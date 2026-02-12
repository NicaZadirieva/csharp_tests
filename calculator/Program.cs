
using calculator.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace calculator
{
    internal class Program
    {
        static void Main()
        {
            // 1. Настраиваем контейнер
            var services = new ServiceCollection();
            

            
            // 4. Запрашиваем экземпляр CalculatorService<double>
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.AddDebug();
            });

            var logger = loggerFactory.CreateLogger<CalculatorService<double>>();
            var calcService = new CalculatorService<double>(logger); // явная передача

            // 5. Используем
            var sum = calcService.Divide(1, 0);
            Console.WriteLine(sum);

        }
    }
}
