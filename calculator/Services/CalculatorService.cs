using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using Microsoft.Extensions.Logging;
using Xunit.Sdk;

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

        /// <summary>
        /// Делить a/b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="DivideByZeroException"></exception>
        public T Divide(T a, T b)
        {
            if (b == T.Zero)
            {
                _logger.LogError("b == 0. Нельзя выполнить деление");
                throw new DivideByZeroException("b == 0. Нельзя выполнить деление");
            }

            return a / b;   // исключения не будет, деление безопасно
        }
    }
}
