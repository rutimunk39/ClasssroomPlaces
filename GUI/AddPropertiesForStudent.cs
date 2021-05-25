using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
namespace GUI
{
    public partial class AddPropertiesForStudent : Form
    {
        
        int win, door, hide, aircon;//משתנים לשמירת העדפה עבור כל אחד מהמאפיינים
        //0 לא משנה
        //1 לא רוצה
        //2רוצה 
        int grade;
        string room;
        public AddPropertiesForStudent(int grade, string room)
        {
            this.grade = grade;
            this.room = room;
            InitializeComponent();
        }       
        //private void btn_window_Click(object sender, EventArgs e)
        //{
        //    win++;
        //    if (win == 3)
        //        win = 0;
        //    draw(1, win);
        //    StudentsManagement.AlterPropertiesToStudents(comboBox1.SelectedItem.ToString(), 1, win);
        //}

        private void btn_door_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_conditioner_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_hide_Click(object sender, EventArgs e)
        {
            
        }

        //private void btn_continue_Click(object sender, EventArgs e)
        //{

        //    ClassRoom c = new ClassRoom(grade, room);
        //    c.Show();
        //}

        private void AddPropertiesForStudent_Load_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            comboBox1.DataSource = StudentsManagement.GetStudentsByClass(grade).Select(p => p.first_name).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClassRoom c = new ClassRoom(grade, room);
            c.Show();
        }

        private void window_Click(object sender, EventArgs e)
        {

            win++;
            if (win == 3)
                win = 0;
            draw(1, win);
            StudentsManagement.AlterPropertiesToStudents(comboBox1.SelectedItem.ToString(), 1, win);
        }

        private void bt_door_Click(object sender, EventArgs e)
        {
            door++;
            if (door == 3)
                door = 0;
            draw(2, door);
            StudentsManagement.AlterPropertiesToStudents(comboBox1.SelectedItem.ToString(), 2, door);
        }
        
        private void conditiner_Click(object sender, EventArgs e)
        {
            aircon++;
            if (aircon == 3)
                aircon = 0;
            draw(3, aircon);
            StudentsManagement.AlterPropertiesToStudents(comboBox1.SelectedItem.ToString(), 3, aircon);
        }

        private void bt_hide_Click(object sender, EventArgs e)
        {
            hide++;
            if (hide == 3)
                hide = 0;
            draw(4, hide);
            StudentsManagement.AlterPropertiesToStudents(comboBox1.SelectedItem.ToString(), 4, hide);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            win = StudentsManagement.ExitsProperties(comboBox1.SelectedItem.ToString(), 1);
            door = StudentsManagement.ExitsProperties(comboBox1.SelectedItem.ToString(), 2);
            aircon = StudentsManagement.ExitsProperties(comboBox1.SelectedItem.ToString(), 3);
            hide = StudentsManagement.ExitsProperties(comboBox1.SelectedItem.ToString(), 4);
            draw(1, win);
            draw(2, door);
            draw(3, aircon);
            draw(4, hide);
        }

        private void AddPropertiesForStudent_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            comboBox1.DataSource = StudentsManagement.GetStudentsByClass(grade).Select(p => p.first_name).ToList();


        }

        private void students_SelectedValueChanged(object sender, EventArgs e)
        {
            win = StudentsManagement.ExitsProperties(comboBox1.SelectedItem.ToString(), 1);
            door = StudentsManagement.ExitsProperties(comboBox1.SelectedItem.ToString(), 2);
            aircon = StudentsManagement.ExitsProperties(comboBox1.SelectedItem.ToString(), 3);
            hide = StudentsManagement.ExitsProperties(comboBox1.SelectedItem.ToString(), 4);
            draw(1, win);
            draw(2, door);
            draw(3, aircon);
            draw(4, hide);
        }
        private void draw(int prop, int status)
        {
            if (prop == 1)
            {
                switch (status)
                {
                    case 0: window.BackColor = Color.Yellow; break;
                    case 1: window.BackColor = Color.Red; break;
                    case 2: window.BackColor = Color.Green; break;

                }
            }
            else
            {
                if (prop == 2)
                {
                    switch (status)
                    {
                        case 0: bt_door.BackColor = Color.Yellow; break;
                        case 1: bt_door.BackColor = Color.Red; break;
                        case 2: bt_door.BackColor = Color.Green; break;

                    }
                }
                else
                {
                    if (prop == 3)
                    {
                        switch (status)
                        {
                            case 0: conditiner.BackColor = Color.Yellow; break;
                            case 1: conditiner.BackColor = Color.Red; break;
                            case 2: conditiner.BackColor = Color.Green; break;

                        }
                    }
                    else
                    {
                        switch (status)
                        {
                            case 0:bt_hide.BackColor = Color.Yellow; break;
                            case 1:bt_hide.BackColor = Color.Red; break;
                            case 2:bt_hide.BackColor = Color.Green; break;

                        }
                    }
                }
            }
        }
    }
}
