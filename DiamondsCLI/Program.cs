using System;

namespace DiamondsCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            if (args.Length < 2)
            {
                Console.WriteLine("Należy podać login oraz hasło");
            }
            else
            {
                Serwis darkW = new Serwis("https://darkw.pl//login/",
                                          "https://darkw.pl/ajax/diamondsLotery/1/",
                                          args[0],
                                          args[1]);
                darkW.Zaloguj();
                Console.WriteLine(DateTime.Now.ToShortDateString() +" - "+DateTime.Now.ToShortTimeString() +" "+darkW.Losuj());
                
            }
            
        }
    }
}
