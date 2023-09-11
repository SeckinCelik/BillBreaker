using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Text;

namespace BillBreaker
{
    [MemoryDiagnoser]
    public class BreakerBenchmark
    {
        private int cents = 100;
        [Benchmark]
        public List<List<Coin>> getPossibleCoins()
        {
            int countOfCoinType25 = cents / (int)CoinType.Quarter;
            List<List<Coin>> allList = new List<List<Coin>>();

            for (int i = countOfCoinType25; i >= 0; i--)
            {
                if ((i) * (int)CoinType.Quarter == cents)
                {
                    allList.Add(new List<Coin> { new Coin { Type = CoinType.Quarter, Count = (i) }, new Coin { Type = CoinType.Dime, Count = 0 }, new Coin { Type = CoinType.Nickel, Count = 0 }, new Coin { Type = CoinType.Penny, Count = 0 } });
                    continue;
                }
                for (int j = 0; j < ((cents - ((i) * (int)CoinType.Quarter)) / (int)CoinType.Dime) + 1; j++)
                {
                    if ((i) * (int)CoinType.Quarter + (j) * (int)CoinType.Dime == cents)
                    {
                        allList.Add(new List<Coin> { new Coin { Type = CoinType.Quarter, Count = (i) }, new Coin { Type = CoinType.Dime, Count = (j) }, new Coin { Type = CoinType.Nickel, Count = 0 }, new Coin { Type = CoinType.Penny, Count = 0 } });
                        continue;
                    }
                    for (int z = 0; z < ((cents - ((i) * (int)CoinType.Quarter + (j) * (int)CoinType.Dime)) / (int)CoinType.Nickel) + 1; z++)
                    {
                        if ((i) * (int)CoinType.Quarter + (j) * (int)CoinType.Dime + (z) * (int)CoinType.Nickel == cents)
                        {
                            allList.Add(new List<Coin> { new Coin { Type = CoinType.Quarter, Count = (i) }, new Coin { Type = CoinType.Dime, Count = (j) }, new Coin { Type = CoinType.Nickel, Count = z }, new Coin { Type = CoinType.Penny, Count = 0 } });
                            continue;
                        }

                        allList.Add(new List<Coin> { new Coin { Type = CoinType.Quarter, Count = (i) }, new Coin { Type = CoinType.Dime, Count = (j) }, new Coin { Type = CoinType.Nickel, Count = z }, new Coin { Type = CoinType.Penny, Count = (cents - ((i) * (int)CoinType.Quarter + (j) * 10 + (z) * 5)) } });
                        continue;
                    }
                }
            }

            return allList;
        }

        public string Print(List<List<Coin>> listOfPossibilities)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in listOfPossibilities)
            {
                var array = item.ToArray();
                stringBuilder.AppendFormat("25*{0}  10*{1}  5*{2}  1*{3} ", array[0].Count, array[1].Count, array[2].Count, array[3].Count);
                stringBuilder.AppendLine();
            }
            return stringBuilder.ToString();
        }
    }
}
