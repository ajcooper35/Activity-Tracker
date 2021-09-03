using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActivtyTracker
{
    public partial class MainUI : Form
    {
        private bool IsExercise { get; set; }

        private Exercise[] ExerciseList = new Exercise[2];
        public MainUI()
        {
            InitializeComponent();
            this.ControlBox = false;
            IsExercise = false;

            label1.Text = "Drink Water";
        }

        public MainUI(string ex1, int count1, string ex2, int count2)
        {
            InitializeComponent();
            this.ControlBox = false;
            IsExercise = true;

            ExerciseList[0] = new Exercise(ex1, count1);
            ExerciseList[1] = new Exercise(ex2, count2);

            string labelText = $"Drink Water!\n{count1} {ex1}\n{count2} {ex2}";
            label1.Text = labelText;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (IsExercise)
            {
                SQLite.AddExercise(ExerciseList);
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
