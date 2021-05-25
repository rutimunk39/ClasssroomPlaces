using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Definition : Form
    {
        public Definition()
        {
            InitializeComponent();
        }
        private string room = "room1";
        private int grade = 1;
        private void Definition_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            AddStudents addStudents = new AddStudents(room, grade);
            addStudents.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            room = "room1";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            room = "room2";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            room = "room3";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            grade = 1;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            grade = 2;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            grade = 3;
        }
    }
}
