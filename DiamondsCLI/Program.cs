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
                Console.WriteLine("Login: "+args[0]+" Haslo: "+args[1]);
            }
            
        }
    }
}
