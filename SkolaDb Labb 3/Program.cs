using SkolaDb_Labb_3.Models;

namespace SkolaDb_Labb_3
{
    internal class Program
    {
        static void Main(string[] args)
        {            

            Console.WriteLine("Välkommen till Skolan!");

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Välj något av följande val i menyn.");
                Console.WriteLine("[1] Sortering av namn");
                Console.WriteLine("[2] Hämta elever ifrån en klass");
                Console.WriteLine("[3] Lägg till ny personal");
                Console.WriteLine("[4] Stäng av programmet");
                

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Method.NameSorting();                        
                        break;

                    case "2":
                        Method.StudentsInClass();                        
                        break;

                    case "3":
                        Method.AddEmployee();                        
                        break;

                    case "4":
                        Environment.Exit(0);
                        break;
                }
            }
            


        }
    }
}
