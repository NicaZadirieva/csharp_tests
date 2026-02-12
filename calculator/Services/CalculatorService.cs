using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using Microsoft.Extensions.Logging;

namespace calculator.Services
{
    internal class CalculatorService<T> where T : INumber<T>
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
            try
            {
                return a / b;
            }
            catch (DivideByZeroException ex)
            {
                _logger.LogError("b == 0. Нельзя совершить операцию");
                return default;
            }
        }
    }
}
