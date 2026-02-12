using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using calculator.Services;   // ← обязательно!

class Program
{
    static void Main()
    {
        var services = new ServiceCollection();

        services.AddLogging(builder =>
        {
            builder.AddConsole();          // <-- без этого логов не будет
            builder.SetMinimumLevel(LogLevel.Trace);
        });

        services.AddTransient(typeof(CalculatorService<>));

        var serviceProvider = services.BuildServiceProvider();

        var calc = serviceProvider.GetRequiredService<CalculatorService<double>>();

        calc.Divide(1, 0);   // здесь должен появиться лог!

        Console.WriteLine("Готово. Нажмите Enter...");
        Console.ReadLine();
    }
}