using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace ActivtyTracker
{
    static class Program
    {
        private static Dictionary<int, string> Exercises = new Dictionary<int, string>()
        {
            { 1, "Push Ups" },
            { 2, "Squats" },
            { 3, "Shoulder Press (Each Arm)" },
            { 4, "Banded Rows" },
            { 5, "Band Pull Aparts" },
            { 6, "Sit Ups" },
            { 7, "Ab Roll Outs" },
            { 8, "T Spine Rotations" },
            { 9, "90/90s" },
            { 10, "Bench Lat Stretches" },
            { 11, "Tricep Pushdowns" },
            { 12, "Banded Shoulder Raises" },
            { 13, "Banded Push Ups" },
            { 14, "Side Raises" }
        };

        [STAThread]
        static void Main()
        {
            SQLite.CreateDatabase();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                DateTime timeNow = DateTime.Now;

                int hourNow = timeNow.Hour;
                int minuteNow = timeNow.Minute;
                int weekdayNum = (int)timeNow.DayOfWeek;
                bool correctWeekday = weekdayNum >= 1 && weekdayNum <= 5;
                bool correctHour = hourNow >= 9 && hourNow <= 17;
                bool correctMinute = minuteNow % 30 == 0;
                bool correctSecond = timeNow.Second == 0;
                bool exerciseNow = minuteNow == 0;
                
                if (correctWeekday & correctHour & correctMinute & correctSecond)
                {
                    RunActivity(exerciseNow);
                }  
            }
        }

        private static void RunActivity(bool exerciseNow)
        {

            if (exerciseNow)
            {
                int numExercises = Exercises.Count;
                var rand = new Random();
                int exercise1, exercise2;

                exercise1 = rand.Next(1, numExercises);
                do
                {
                    exercise2 = rand.Next(1, numExercises);

                } while (exercise1 == exercise2);

                string exerciseOneName = Exercises[exercise1];
                string exerciseTwoName = Exercises[exercise2];

                int countOne = rand.Next(2, 10) * 2;
                int countTwo = rand.Next(2, 10) * 2;

                MainUI MainUI = new MainUI(exerciseOneName, countOne, exerciseTwoName, countTwo);

                Application.Run(MainUI);
                GC.Collect();

            }
            else
            {
                MainUI MainUI = new MainUI();
                Application.Run(MainUI);
                GC.Collect();
            }
        }
    }
}
