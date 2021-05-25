using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using DAL;

namespace GUI
{
    public partial class DeskUserControl : UserControl
    {
        public delegate void UpdateListStudent(string toDelete, string ToAdd);
        ListBox lb = new ListBox();//להצגת התלמידות שיכולות לשבת בשולחן
        public UpdateListStudent Updatelist { get; set; }//עדכון רשימת תלמידות לשיבוץ בהתאם לתלמידות ששובצו
        public ComboBox RightStudent { get; set; }
        public ComboBox LeftStudent { get; set; }
        int grade;
        ToolTip toolTip = new ToolTip();
        public int Row { get; set; }//שורה
        public int Column { get; set; }//טור
        //public Students ChooseRightStudent { get; set; } = new Students();
        //public Students ChooseLeftStudent { get; set; } = new Students();
        public string tempR { get; set; } = " ";
        public string tempL { get; set; } = " ";
        public Dictionary<int, bool> TablesProp { get; set; }
        List<string> datar;//רשימת תלמידות שיופיעו בקומבו בוקס ימין
        List<string> datal; //רשימת תלמידות שיופיעו בקומבו בוקס שמאל
        public DeskUserControl(int grade)
        {
            InitializeComponent();
            TablesProp = new Dictionary<int, bool>();
            this.grade = grade;
        }       
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //בעת שינוי תלמידה בצד ימין עדכון טור ושולחן במסד נתונים מחיקת השורה והטור לתלמידה שהיתה משובצת שם קודם
            //מחיקת התלמידה מכל השולחנות שלא תבחר פעמיים והוספת התלמידה שישבה שם קודם לכל השולחנות
            if (right.SelectedItem.ToString() != tempR)
            {
                StudentsManagement.UpdateLineAndRow(right.SelectedItem.ToString(), Row, Column);
                if (tempR != " ")
                    StudentsManagement.UpdateLineAndRow(tempR.ToString(), 0, 0);
                Updatelist(right.SelectedItem.ToString(), tempR);

                tempR = right.SelectedItem.ToString();
                if (right.SelectedItem == null || right.SelectedItem.ToString() == " " || left.SelectedItem == null || left.SelectedItem.ToString() == " ")
                {
                    BackColor = Color.Linen;
                }
                else
                {
                    SchedulingT tb = new SchedulingT(right.SelectedItem.ToString(), left.SelectedItem.ToString());
                    values result = tb.checkMatch();
                    ColorTable(result);
                }
                if (right.SelectedItem.ToString() != " ")
                {
                    SchedulingS sp = new SchedulingS(right.SelectedItem.ToString());
                    values result = sp.checkLocation(Row);
                    ColorCombo(result, true);
                    if (result != values.Excellent)
                        MessageBox.Show("שימי לב השורה הממומלצת לתלמידה היא: " + sp.GetStudent().rec_row);
                    if (sp.checkConstraints(TablesProp))
                    {
                        students s = sp.GetStudent();

                        errorProvider1.SetError(right, "בעיה באילוצי תלמידה ראו את פרוט אילוצי התלמידה במסך קודם");
                    }
                    else
                    {
                        errorProvider1.Clear();
                    }

                }
                else
                {
                    right.BackColor = Color.White;
                    errorProvider1.Clear();

                }

            }

        }
        private void DeskUserControl_Load(object sender, EventArgs e)
        {
            //מלוי הקומבובוקס ברשימת תלמידות הכיתה הוספת ערך ריק לסימון מקום פנוי
            datar = StudentsManagement.GetStudentsByClass(grade).Select(p => p.first_name).ToList();
            datar.Insert(0, " ");
            datar.ForEach(s =>right.Items.Add(s));
            datal = StudentsManagement.GetStudentsByClass(grade).Select(p => p.first_name).ToList();
            datal.Insert(0, " ");
            datal.ForEach(s => left.Items.Add(s));
            RightStudent = right;
            LeftStudent = left;
        }
        private void ColorTable(values result)
        {//צביעת השולחן בהתאם לשיבוץ תלמידות מבחינת רמת פטפוט
            switch (result)
            {
                case values.Excellent:
                    label1.BackColor= Color.Green;
                    //BackColor = Color.Green;
                    break;
                case values.Possible:
                    label1.BackColor = Color.Yellow;
                    //BackColor = Color.Yellow;
                    break;
                case values.Impossible:
                    label1.BackColor = Color.Red;
                    //BackColor = Color.Red;
                    break;
            }
        }
        private void ColorCombo(values result, bool IsRight)
        {//צביעת הקומבובוקס בהתאם לשיבוץ תלמידות מבחינת שורה מומלצת
            switch (result)
            {
                case values.Excellent:
                    if (IsRight) right.BackColor = Color.Green;

                    else left.BackColor = Color.Green;
                    break;
                case values.Possible:
                    if (IsRight) right.BackColor = Color.Yellow;

                    else left.BackColor = Color.Yellow;
                    break;
                case values.Impossible:
                    if (IsRight) right.BackColor = Color.Red;

                    else left.BackColor = Color.Red;
                    break;
            }
        }
        private void rightStudent_SelectedIndexChanged(object sender, EventArgs e)
        {//בעת שינוי תלמידה בצד ימין עדכון טור ושולחן במסד נתונים מחיקת השורה והטור לתלמידה שהיתה משובצת שם קודם
         //מחיקת התלמידה מכל השולחנות שלא תבחר פעמיים והוספת התלמידה שישבה שם קודם לכל השולחנות
            if (right.SelectedItem.ToString() != tempR)
            {
                StudentsManagement.UpdateLineAndRow(right.SelectedItem.ToString(), Row, Column);
                if (tempR != " ")
                    StudentsManagement.UpdateLineAndRow(tempR.ToString(), 0, 0);
                Updatelist(right.SelectedItem.ToString(), tempR);

                tempR = right.SelectedItem.ToString();
                if (right.SelectedItem == null || right.SelectedItem.ToString() == " " || left.SelectedItem == null || left.SelectedItem.ToString() == " ")
                {
                    BackColor = Color.Linen;
                }
                else
                {
                    SchedulingT tb = new SchedulingT(right.SelectedItem.ToString(), left.SelectedItem.ToString());
                    values result = tb.checkMatch();
                    ColorTable(result);
                }
                if (right.SelectedItem.ToString() != " ")
                {
                    SchedulingS sp = new SchedulingS(right.SelectedItem.ToString());
                    values result = sp.checkLocation(Row);
                    ColorCombo(result, true);
                    if (result != values.Excellent)
                        MessageBox.Show("שימי לב השורה הממומלצת לתלמידה היא: " + sp.GetStudent().rec_row);
                    if (sp.checkConstraints(TablesProp))
                    {
                        students s = sp.GetStudent();

                        errorProvider1.SetError(right, "בעיה באילוצי תלמידה ראו את פרוט אילוצי התלמידה במסך קודם");
                    }
                    else
                    {
                        errorProvider1.Clear();
                    }

                }
                else
                {
                    right.BackColor = Color.White;
                    errorProvider1.Clear();

                }
                
            }

        }
        private void leftStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            //בעת שינוי תלמידה בצד שמאל עדכון טור ושולחן במסד נתונים מחיקת השורה והטור לתלמידה שהיתה משובצת שם קודם
            //מחיקת התלמידה מכל השולחנות שלא תבחר פעמיים והוספת התלמידה שישבה שם קודם לכל השולחנות
            if (left.SelectedItem.ToString() != tempL)
            {
                StudentsManagement.UpdateLineAndRow(left.SelectedItem.ToString(), Row, Column);
                if (tempL != " ")
                    StudentsManagement.UpdateLineAndRow(tempL, 0, 0);
                Updatelist(left.SelectedItem.ToString(), tempL);
                tempL = left.SelectedItem.ToString();

                if (right.SelectedItem == null || right.SelectedItem.ToString() == " " || left.SelectedItem == null || left.SelectedItem.ToString() == " ")
                {
                    BackColor = Color.Linen;
                }
                else
                {
                    SchedulingT tb = new SchedulingT(right.SelectedItem.ToString(), left.SelectedItem.ToString());
                    values result = tb.checkMatch();
                    ColorTable(result);
                }
                if (left.SelectedItem.ToString() != " ")
                {
                    SchedulingS sp = new SchedulingS(left.SelectedItem.ToString());
                    values result = sp.checkLocation(Row);
                    ColorCombo(result, false);
                    if (result != values.Excellent)
                        MessageBox.Show("שימי לב השורה הממומלצת לתלמידה היא: " + sp.GetStudent().rec_row);
                    if (sp.checkConstraints(TablesProp))
                    {
                        errorProvider2.SetError(left, " בעיה באילוצי תלמידה ראו את פרוט אילוצי התלמידה במסך קודם");
                    }
                    else
                    {
                        errorProvider2.Clear();
                    }
                }
                else
                {
                    left.BackColor = Color.White;
                    errorProvider2.Clear();

                }
            }

        }
        public void AddStudentToList(string name)
        {//הוספת תלמידה שעד כה שובצה בשולחן מסוים וכעת בטלו את שיבוצה לכל השולחנות
            if (name != tempR)
            {

                right.Items.Add(name);
            }

            if (name != tempL)
            {

                left.Items.Add(name);
            }

        }
        public void DeleteStudentFromList(string name)
        {//מחיקת תלמידה שנבחרה לשבת בשולחן מסוים מהרשימות בכל שאר השולחנות
            if (right.SelectedItem == null || name != right.SelectedItem.ToString())
            {
                right.Items.Remove(name);

            }
            if (left.SelectedItem == null || name != left.SelectedItem.ToString())
            {
                left.Items.Remove(name);

            }
        }
        private void TableUserControl_MouseHover(object sender, EventArgs e)
        {//הצגת מאפייני שולחן בעת מעבר על השולחן
            string props = " ";
            foreach (var item in TablesProp)
            {
                if (item.Value)
                {
                    switch (item.Key)
                    {
                        case 1: props += "ליד החלון" + "\n"; break;
                        case 2: props += "  ליד הדלת" + "\n"; break;
                        case 3: props += "ליד המזגן" + "\n"; break;
                        case 4: props += "מוסתר"; break;
                    }
                }
            }
            if (props != " ") toolTip.SetToolTip(this, props);
            else toolTip.SetToolTip(this, "ללא מאפיינים מיוחדים");
        }

        private void button1_Click(object sender, EventArgs e)
        {//בעת לחיצה על כפתור עזרה-הצגת התלמידות שיכולות לשבת בשולחן
            //עשיתי כך כי זה היה נראה לי מאד מסובך לכתוב את הקוד הזה בlinq
            List<students> students = new List<students>();
            List<string> appropriateStudents = new List<string>();
            students = StudentsManagement.GetStudentsByClass(grade);
            foreach (var student in students)
            {
                SchedulingS mp = new SchedulingS(student.first_name);
                if (!mp.checkConstraints(TablesProp))
                {
                    if (mp.checkLocation(Row) != values.Impossible)
                        appropriateStudents.Add(student.first_name);
                }
            }


            lb.Text = "התלמידות האפשריות לישיבה בשולחן";
            lb.Location = new Point((sender as Control).Location.X + 80, (sender as Control).Location.Y - 100);
            lb.MouseLeave += RemoveList;
            lb.Height = appropriateStudents.Count() > 0 ? appropriateStudents.Count() * 50 : 50;
            if (appropriateStudents.Count() == 0)
                appropriateStudents.Add("לא נמצא");
            lb.DataSource = appropriateStudents;

            Controls.Add(lb);
        }
        public void RemoveList(object sender, EventArgs e)
        {
            Controls.Remove(lb);
        }

        private void left_SelectedIndexChanged(object sender, EventArgs e)
        {

            //בעת שינוי תלמידה בצד שמאל עדכון טור ושולחן במסד נתונים מחיקת השורה והטור לתלמידה שהיתה משובצת שם קודם
            //מחיקת התלמידה מכל השולחנות שלא תבחר פעמיים והוספת התלמידה שישבה שם קודם לכל השולחנות
            if (left.SelectedItem.ToString() != tempL)
            {
                StudentsManagement.UpdateLineAndRow(left.SelectedItem.ToString(), Row, Column);
                if (tempL != " ")
                    StudentsManagement.UpdateLineAndRow(tempL, 0, 0);
                Updatelist(left.SelectedItem.ToString(), tempL);
                tempL = left.SelectedItem.ToString();

                if (right.SelectedItem == null || right.SelectedItem.ToString() == " " || left.SelectedItem == null || left.SelectedItem.ToString() == " ")
                {
                    BackColor = Color.Linen;
                }
                else
                {
                    SchedulingT tb = new SchedulingT(right.SelectedItem.ToString(), left.SelectedItem.ToString());
                    values result = tb.checkMatch();
                    ColorTable(result);
                }
                if (left.SelectedItem.ToString() != " ")
                {
                    SchedulingS sp = new SchedulingS(left.SelectedItem.ToString());
                    values result = sp.checkLocation(Row);
                    ColorCombo(result, false);
                    if (result != values.Excellent)
                        MessageBox.Show("שימי לב השורה הממומלצת לתלמידה היא: " + sp.GetStudent().rec_row);
                    if (sp.checkConstraints(TablesProp))
                    {
                        errorProvider2.SetError(left, " בעיה באילוצי תלמידה ראו את פרוט אילוצי התלמידה במסך קודם");
                    }
                    else
                    {
                        errorProvider2.Clear();
                    }
                }
                else
                {
                    left.BackColor = Color.White;
                    errorProvider2.Clear();

                }
            }
        }
    }
}
