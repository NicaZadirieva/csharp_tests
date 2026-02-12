using calculator.Services;
using Microsoft.Extensions.Logging;

namespace calculator
{
    public class CalculatorTests
    {

        [Theory]
        [InlineData(10, 2, 12)]
        [InlineData(9, 3, 12)]
        [InlineData(-6, 2, -4)]
        public void Add_ShouldReturn_Valid(int a, int b, double expected)
        {
           
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.SetMinimumLevel(LogLevel.Trace);
            });

            var logger = loggerFactory.CreateLogger<CalculatorService<double>>();
            var calc = new CalculatorService<double>(logger);
            var result = calc.Add(a, b);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 2, 5)]
        [InlineData(9, 3, 3)]
        [InlineData(-6, 2, -3)]
        public void Divide_ShouldReturn_Valid(int a, int b, double expected)
        {

            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.SetMinimumLevel(LogLevel.Trace);
            });

            var logger = loggerFactory.CreateLogger<CalculatorService<double>>();
            var calc = new CalculatorService<double>(logger);
            var result = calc.Divide(a, b);
            Assert.Equal(expected, result);
        }
        [Fact]
        public void Divide_ShouldThrowsException()
        {

            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.SetMinimumLevel(LogLevel.Trace);
            });

            var logger = loggerFactory.CreateLogger<CalculatorService<double>>();
            var calc = new CalculatorService<double>(logger);
            Assert.Throws<DivideByZeroException>(
                () => calc.Divide(5, 0)
            );
        }

    }
}
