using System;
using Microsoft.Data.Sqlite;

namespace ActivtyTracker
{
    interface SQLite
    {
        private static string Database = "exerciseTracker.db";

        public static void CreateDatabase()
        {
            using (var connection = new SqliteConnection($"Data Source={Database}"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"CREATE TABLE IF NOT EXISTS ExerciseTracker (
                                            key INTEGER PRIMARY KEY AUTOINCREMENT,
                                            datetime text,
                                            exercise_1 text,
                                            count_1 int,
                                            exercise_2 text,
                                            count_2 int);";
                command.ExecuteNonQuery();
            }
        }

        public static void AddExercise(Exercise[] exerciseList)
        {
            using (var connection = new SqliteConnection($"Data Source={Database}"))
            {
                connection.Open();
                var command = connection.CreateCommand();

                Exercise exerciseOne = exerciseList[0];
                Exercise exerciseTwo = exerciseList[1];

                command.CommandText = @"INSERT INTO ExerciseTracker 
                                            (datetime, exercise_1, count_1, exercise_2, count_2)
                                        VALUES 
                                            ($datetime, $ex1, $count1, $ex2, $count2);";

                command.Parameters.AddWithValue("$datetime", DateTime.Now);
                command.Parameters.AddWithValue("$ex1", exerciseOne.Name);
                command.Parameters.AddWithValue("$count1", exerciseOne.ExerciseCount);
                command.Parameters.AddWithValue("$ex2", exerciseTwo.Name);
                command.Parameters.AddWithValue("$count2", exerciseTwo.ExerciseCount);

                command.ExecuteNonQuery();

            }
        }
    }
}
