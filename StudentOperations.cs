using System;
using MySql.Data.MySqlClient;

class StudentOperations
{
    // Database connection
    private static string connectionString =
        "Server=127.0.0.1;" +
        "Port=3307;" +
        "Database=csharp_db;" +
        "User ID=root;" +
        "Password=;";

    // =========================================
    // CREATE - ADD STUDENT
    // =========================================
    public static void AddStudent()
    {
        Console.Clear();
        Console.WriteLine("==========================");
        Console.WriteLine("       ADD STUDENT");
        Console.WriteLine("==========================");

        Console.Write("Enter student name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter student email: ");
        string email = Console.ReadLine() ?? "";

        Console.Write("Enter student age: ");

        if (!int.TryParse(Console.ReadLine(), out int age))
        {
            Console.WriteLine("\nInvalid age.");
            Pause();
            return;
        }

        string query =
            "INSERT INTO students (name, email, age) " +
            "VALUES (@name, @email, @age)";

        try
        {
            using MySqlConnection connection =
                new MySqlConnection(connectionString);

            connection.Open();

            using MySqlCommand command =
                new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@age", age);

            int result = command.ExecuteNonQuery();

            if (result > 0)
            {
                Console.WriteLine("\nStudent added successfully.");
            }
            else
            {
                Console.WriteLine("\nStudent could not be added.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nDatabase error:");
            Console.WriteLine(ex.Message);
        }

        Pause();
    }


    // =========================================
    // READ - VIEW STUDENTS
    // =========================================
    public static void ViewStudents()
    {
        Console.Clear();
        Console.WriteLine("==============================================");
        Console.WriteLine("                STUDENT LIST");
        Console.WriteLine("==============================================");

        string query =
            "SELECT id, name, email, age FROM students ORDER BY id";

        try
        {
            using MySqlConnection connection =
                new MySqlConnection(connectionString);

            connection.Open();

            using MySqlCommand command =
                new MySqlCommand(query, connection);

            using MySqlDataReader reader =
                command.ExecuteReader();

            Console.WriteLine(
                "{0,-5} {1,-20} {2,-30} {3,-5}",
                "ID",
                "Name",
                "Email",
                "Age"
            );

            Console.WriteLine(new string('-', 65));

            bool hasStudents = false;

            while (reader.Read())
            {
                hasStudents = true;

                Console.WriteLine(
                    "{0,-5} {1,-20} {2,-30} {3,-5}",
                    reader["id"],
                    reader["name"],
                    reader["email"],
                    reader["age"]
                );
            }

            if (!hasStudents)
            {
                Console.WriteLine("No students found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nDatabase error:");
            Console.WriteLine(ex.Message);
        }

        Pause();
    }


    // =========================================
    // UPDATE - UPDATE STUDENT
    // =========================================
    public static void UpdateStudent()
    {
        Console.Clear();

        Console.WriteLine("==========================");
        Console.WriteLine("      UPDATE STUDENT");
        Console.WriteLine("==========================");

        Console.Write("Enter student ID to update: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("\nInvalid student ID.");
            Pause();
            return;
        }

        Console.Write("Enter new name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Enter new email: ");
        string email = Console.ReadLine() ?? "";

        Console.Write("Enter new age: ");

        if (!int.TryParse(Console.ReadLine(), out int age))
        {
            Console.WriteLine("\nInvalid age.");
            Pause();
            return;
        }

        string query =
            "UPDATE students " +
            "SET name = @name, email = @email, age = @age " +
            "WHERE id = @id";

        try
        {
            using MySqlConnection connection =
                new MySqlConnection(connectionString);

            connection.Open();

            using MySqlCommand command =
                new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@age", age);
            command.Parameters.AddWithValue("@id", id);

            int result = command.ExecuteNonQuery();

            if (result > 0)
            {
                Console.WriteLine("\nStudent updated successfully.");
            }
            else
            {
                Console.WriteLine("\nStudent ID not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nDatabase error:");
            Console.WriteLine(ex.Message);
        }

        Pause();
    }


    // =========================================
    // DELETE - DELETE STUDENT
    // =========================================
    public static void DeleteStudent()
    {
        Console.Clear();

        Console.WriteLine("==========================");
        Console.WriteLine("      DELETE STUDENT");
        Console.WriteLine("==========================");

        Console.Write("Enter student ID to delete: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("\nInvalid student ID.");
            Pause();
            return;
        }

        string query =
            "DELETE FROM students WHERE id = @id";

        try
        {
            using MySqlConnection connection =
                new MySqlConnection(connectionString);

            connection.Open();

            using MySqlCommand command =
                new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@id", id);

            int result = command.ExecuteNonQuery();

            if (result > 0)
            {
                Console.WriteLine("\nStudent deleted successfully.");
            }
            else
            {
                Console.WriteLine("\nStudent ID not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nDatabase error:");
            Console.WriteLine(ex.Message);
        }

        Pause();
    }


    // =========================================
    // PAUSE
    // =========================================
    private static void Pause()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}