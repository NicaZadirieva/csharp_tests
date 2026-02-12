using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using Microsoft.Extensions.Logging;

namespace calculator.Services
{
    public class CalculatorService<T> where T : INumber<T>
    {
        private readonly ILogger<CalculatorService<T>> _logger;

        public CalculatorService(ILogger<CalculatorService<T>> logger)
        {
            _logger = logger;
        }

        public T Add(T a, T b)
        {
            return a + b;
        }
        public T? Divide(T a, T b)
        {
            if (b == T.Zero)
            {
                _logger.LogError("b == 0. Нельзя выполнить деление");
                return default; // T? — вернёт null для ссылочных, default(T) для значимых
            }

            return a / b;   // исключения не будет, деление безопасно
        }
    }
}
