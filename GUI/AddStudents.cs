using BL;
using DAL;
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
    public partial class AddStudents : Form
    {
        public AddStudents()
        {
            InitializeComponent();
        }
        private string room;//משתנה לשמירת חדר כיתה
        private int grade;//הכיתה שרוצים לשבץ
        public AddStudents(string room, int grade)
        {
            InitializeComponent();
            this.grade = grade;
            this.room = room;
        }
        private void AddStudents_Load(object sender, EventArgs e)
        {
            button2.Select();
            WindowState = FormWindowState.Maximized;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //הוספת תלמידה

            students student = new students();
            student.@class = grade;
            //student.id= textBox1.Text;
            //student.id = int.Parse( textBox1.Text);
            student.first_name = textBox2.Text;
            student.family_name = textBox3.Text;
            int rec;
            if (int.TryParse(textBox4.Text, out rec)) ;
            student.rec_row = rec;
            student.chat = (int)numericUpDown1.Value;
            if (StudentsManagement.AddStudent(student))
            {
                MessageBox.Show("התלמידה נוספה בהצלחה!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                numericUpDown1.Value = 1;
            }
            else
                MessageBox.Show("תעודת הזהות כבר קיימת במערכת ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddPropertiesForStudent f = new AddPropertiesForStudent(grade, room);
            f.Show();
        }
    }
}
