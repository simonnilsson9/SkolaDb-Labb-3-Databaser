using SkolaDb_Labb_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaDb_Labb_3
{
    internal class Method
    {

        public static void NameSorting()
        {
            using SkolaDbContext context = new SkolaDbContext();

            Console.Clear();
            Console.WriteLine("Vad vill du se eleverna sorterade på?");
            Console.WriteLine("[1] Förnamn");
            Console.WriteLine("[2] Efternamn");
            
            string sortBy = Console.ReadLine();
            
            switch (sortBy)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Välj om eleverna ska sorteras stigande eller fallande");
                    Console.WriteLine("[1] Stigande");
                    Console.WriteLine("[2] Fallande");

                    string sortOrderFörnamn = Console.ReadLine();

                    if (sortOrderFörnamn == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("Här är alla elever sorterade på förnamn och stigande:\n");

                        var resultAscendingFörnamn = context.TblStudents.OrderBy(s => s.Förnamn);
                        foreach(TblStudent s in resultAscendingFörnamn)
                        {
                            Console.WriteLine($"{s.Förnamn} {s.Efternamn}\nStudentID: {s.StudentId}\n");
                        }
                    }
                    else if (sortOrderFörnamn == "2")
                    {
                        Console.Clear();
                        Console.WriteLine("Här är alla elever sorterade på förnamn och fallande:\n");

                        var resultDescendingFörnamn = context.TblStudents.OrderByDescending(s => s.Förnamn);
                        foreach (TblStudent s in resultDescendingFörnamn)
                        {
                            Console.WriteLine($"{s.Förnamn} {s.Efternamn}\nStudentID: {s.StudentId}\n");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Ogiltigt val.");
                    }

                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("Välj om eleverna ska sorteras stigande eller fallande");
                    Console.WriteLine("[1] Stigande");
                    Console.WriteLine("[2] Fallande");

                    string sortOrderEfternamn = Console.ReadLine();

                    if (sortOrderEfternamn == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("Här är alla elever sorterade på efternamn och stigande:\n");

                        var resultAscendingEfternamn = context.TblStudents.OrderBy(s => s.Efternamn);
                        foreach (TblStudent s in resultAscendingEfternamn)
                        {
                            Console.WriteLine($"{s.Förnamn} {s.Efternamn}\nStudentID: {s.StudentId}\n");
                        }

                    }
                    else if (sortOrderEfternamn == "2")
                    {
                        Console.Clear();
                        Console.WriteLine("Här är alla elever sorterade på efternamn och fallande:\n");

                        var resultDescendingEfternamn = context.TblStudents.OrderByDescending(s => s.Efternamn);
                        foreach (TblStudent s in resultDescendingEfternamn)
                        {
                            Console.WriteLine($"{s.Förnamn} {s.Efternamn}\nStudentID: {s.StudentId}\n");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Ogiltigt val.");
                    }
                    break;

                default:
                    Console.WriteLine("Ogiltigt val. Försök igen!");
                    break;
            }
            Console.WriteLine("Tryck ENTER för att försätta.");
            Console.ReadKey();
        }

        public static void StudentsInClass()
        {
            using SkolaDbContext context = new SkolaDbContext();

            Console.Clear();
            Console.WriteLine("Här är alla klasser som finns:");

            var distinctClass = context.TblStudents.GroupBy(s => s.Klass).Select(group => group.First());
            
            foreach (TblStudent item in distinctClass)
            {
                Console.WriteLine($"{item.Klass}");
                
            }

            Console.WriteLine("Välj en av klasserna du vill se alla elever i");
            string selectedClass = Console.ReadLine();

            var studentsInSelectedClass = context.TblStudents.Where(s => s.Klass == selectedClass);

            switch (selectedClass.ToUpper())
            {
                case "SUT23":
                    Console.Clear();
                    Console.WriteLine($"Eleverna i klassen {selectedClass.ToUpper()}\n");
                    foreach (TblStudent s in studentsInSelectedClass)
                    {
                        Console.WriteLine($"{s.Förnamn} {s.Efternamn}\nStudentID: {s.StudentId}\n");
                    }
                    break;

                case "SUT21":
                    Console.Clear();
                    Console.WriteLine($"Eleverna i klassen {selectedClass.ToUpper()}\n");
                    foreach (TblStudent s in studentsInSelectedClass)
                    {
                        Console.WriteLine($"{s.Förnamn} {s.Efternamn}\nStudentID: {s.StudentId}\n");
                    }
                    break;

                case "EKB19":
                    Console.Clear();
                    Console.WriteLine($"Eleverna i klassen {selectedClass.ToUpper()}\n");
                    foreach (TblStudent s in studentsInSelectedClass)
                    {
                        Console.WriteLine($"{s.Förnamn} {s.Efternamn}\nStudentID: {s.StudentId}\n");
                    }
                    break;

                case "MEK21":
                    Console.Clear();
                    Console.WriteLine($"Eleverna i klassen {selectedClass.ToUpper()}\n");
                    foreach (TblStudent s in studentsInSelectedClass)
                    {
                        Console.WriteLine($"{s.Förnamn} {s.Efternamn}\nStudentID: {s.StudentId}\n");
                    }
                    break;

                default:                    
                    Console.WriteLine("\nOgiltigt klassval.");
                    break;

            }
            Console.WriteLine("Tryck ENTER för att försätta.");
            Console.ReadKey();

        }

        public static void AddEmployee()
        {
            using SkolaDbContext context = new SkolaDbContext();

            string inputPers;
            DateOnly PersNr;

            Console.Clear() ;
            Console.WriteLine("Dags att lägga in en ny personal i tabellen.");

            Console.Write("\nAnge förnamn: ");
            string inputFörnamn = Console.ReadLine();
            

            Console.Write("Ange efternamn: ");
            string inputEfternamn = Console.ReadLine();
            
                      
            do
            {
                Console.Write("Ange personnummer (YYYY-MM-DD): ");
                inputPers = Console.ReadLine();

                if (!DateOnly.TryParse(inputPers, out PersNr))
                {
                    Console.WriteLine("Ogiltigt personnummer, försök igen.");
                }

            } while (PersNr == default(DateOnly));

            Console.Write("Ange befattning: ");
            string inputBefattning = Console.ReadLine();
            
            TblPersonal tblPersonal = new TblPersonal()
            {
                Förnamn = inputFörnamn,
                Efternamn = inputEfternamn,
                Personnummer = PersNr,
                Befattning = inputBefattning
            };

            context.Add(tblPersonal);
            context.SaveChanges();

            Console.WriteLine($"\n{inputFörnamn} har sparats i systemet som {inputBefattning}.");
            Console.WriteLine("Tryck ENTER för att försätta.");
            Console.ReadKey();
            Console.Clear();
        }

        
        



    }
}
