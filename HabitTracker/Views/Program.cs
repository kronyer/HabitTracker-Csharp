using HabitTracker.Controllers;
using Microsoft.Data.Sqlite;
using System.Globalization;

namespace HabitTracker.Views
{

    class Program
    {
        static string connectionString = @"Data Source=habit-Tracker.db";

        static void Main(string[] args)
        {

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText = @"CREATE TABLE IF NOT EXISTS drinking_water (Id INTEGER PRIMARY KEY AUTOINCREMENT, Date TEXT, Quantity INTEGER)";

                tableCmd.ExecuteNonQuery();

                connection.Close();
            }
            WaterController.GetUserInput();
        }

        public static DateTime GetDateInput()
        {
            DateTime dateInput;
            Console.WriteLine("Insert the date: (dd--mm---yy) or type 0 to return");

            while (!DateTime.TryParse(Console.ReadLine(), out dateInput))
            {
                Console.WriteLine("Insert a valid DateTime:");
                DateTime.TryParse(Console.ReadLine(), out dateInput);
            }
            return dateInput;
        }


        public static int GetNumberInput(string message)
        {
            Console.WriteLine(message);
            string numberInput = Console.ReadLine();

            if (numberInput == "0")
            {
                WaterController.GetUserInput();
            }
            int finalInput = Convert.ToInt32(numberInput);
            return finalInput;
        }




    }
}
