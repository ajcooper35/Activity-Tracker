using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivtyTracker
{
    class Exercise
    {
        public string Name { get; set; }
        public int ExerciseCount { get; set; }

        public Exercise(string name, int count)
        {
            Name = name;
            ExerciseCount = count;
        }
    }
}
