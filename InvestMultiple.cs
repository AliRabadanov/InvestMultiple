using System;

namespace Invest
{
    internal class Program
    {
        public static void Main()
        {
            var x = new InvestMultiple
            {
                Rate = 0.08,
                ContractPrice = 100,
                ContractCount = 1 // Со скольки контрактов начинаем
            };

            Console.WriteLine("У нас есть " + x.ContractCount + " контракт(ов)");

            var contractsNeed = 5; // Сколько еще нужно контрактов

            for (var i = 0; i < contractsNeed; i++)
            {
                x.NextContract();
                Console.Write($"{x.ContractCount,2} контракт через мес.: {x.MonthTotal,6:0.00}.");
                Console.WriteLine($" || {x.TimeUntilNextContract:0.00} мес. от предыдущего контракта");
            }
        }
    }

    public class InvestMultiple
    {
        public double Rate { get; set; }
        public double ContractPrice { get; set; }
        public int ContractCount { get; set; }
        public double MonthTotal { get; private set; }
        public double TimeUntilNextContract { get; private set; }

        public void NextContract()
        {
            TimeUntilNextContract = Math.Log(
                (ContractPrice * ContractCount + ContractPrice) / (ContractPrice * ContractCount),
                1 + Rate / 12);
            ContractCount++;
            MonthTotal += TimeUntilNextContract;
        }
    }
}