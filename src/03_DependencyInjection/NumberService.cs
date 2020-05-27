using System;

namespace _03_DependencyInjection
{
    public interface INumberService
    {
        int Number { get; }
    }

    public class NumberService : INumberService
    {
        public int Number { get; }

        public NumberService()
        {
            Number = new Random().Next();
        }
    }
}
