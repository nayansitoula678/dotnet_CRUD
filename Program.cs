using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("=================================");
            Console.WriteLine("      STUDENT MANAGEMENT SYSTEM");
            Console.WriteLine("=================================");
            Console.WriteLine("1. View Students");
            Console.WriteLine("2. Add Student");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Exit");
            Console.WriteLine("=================================");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    StudentOperations.ViewStudents();
                    break;

                case "2":
                    StudentOperations.AddStudent();
                    break;

                case "3":
                    StudentOperations.UpdateStudent();
                    break;

                case "4":
                    StudentOperations.DeleteStudent();
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}