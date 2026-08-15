using System;
using MySql.Data.MySqlClient;

class StudentOperations
{
    private static string connectionString =
        "Server=127.0.0.1;" +
        "Port=3307;" +
        "Database=csharp_db;" +
        "User ID=root;" +
        "Password=;";

    public static void ViewStudents()
    {
        Console.Clear();
        Console.WriteLine("=== STUDENT LIST ===\n");

        string query = "SELECT * FROM students";

        try
        {
            using MySqlConnection connection =
                new MySqlConnection(connectionString);

            connection.Open();

            using MySqlCommand command =
                new MySqlCommand(query, connection);

            using MySqlDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(
                    $"ID: {reader["id"]} | " +
                    $"Name: {reader["name"]} | " +
                    $"Email: {reader["email"]} | " +
                    $"Age: {reader["age"]}"
                );
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Database error:");
            Console.WriteLine(ex.Message);
        }

        Pause();
    }

    public static void AddStudent()
    {
        Console.WriteLine("Add Student will go here.");
        Pause();
    }

    public static void UpdateStudent()
    {
        Console.WriteLine("Update Student will go here.");
        Pause();
    }

    public static void DeleteStudent()
    {
        Console.WriteLine("Delete Student will go here.");
        Pause();
    }

    private static void Pause()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}