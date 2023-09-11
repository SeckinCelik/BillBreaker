namespace BillBreaker
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    System.Console.WriteLine("Enter a positive integer to get started");
                    var count = System.Convert.ToInt32(System.Console.ReadLine());
                    var coinBreaker = new CoinBreakerUtility();
                    var result = coinBreaker.GetCoinPairs(count);
                    System.Console.WriteLine(string.Format("Total Count:{0}", result.Count));
                    System.Console.WriteLine(coinBreaker.Print(result));
                    System.Console.WriteLine("****************************");
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            } while (System.Console.ReadLine() != "q");


            System.Console.ReadKey();
        }
    }
}
