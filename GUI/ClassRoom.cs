using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
namespace GUI
{
    public partial class ClassRoom : Form
    {
        int numStudent = 0;//מספר התלמידות בכיתה
        int grade;//כיתה
        string room;//חדר הכיתה
        Label numStudents = new Label();//תוית להצגת מספר התלמידות שעדיין לא שובצו
        XDocument myClassrom;
        string path;
        public ClassRoom(int grade, string room)
        {
            InitializeComponent();
            this.grade = grade;
            this.room = room;
        }
        int[] columns;
       
        public void saveRoomMap(object sender, EventArgs e)
        {//שמירה בקובץ xml
            StreamWriter sw = null;
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    XmlSerializer xs = new XmlSerializer(typeof(DemoPlacementStudent));
                    sw = new StreamWriter(saveFileDialog1.FileName);
                    Console.WriteLine(sw);
                    foreach (var item in Controls)
                    {
                        if (item is GUI.DeskUserControl)
                        {
                            DemoPlacementStudent saveTable = new DemoPlacementStudent();
                            saveTable.LeftStudent = (item as GUI.DeskUserControl).tempL;
                            saveTable.RightStudent = (item as GUI.DeskUserControl).tempR;
                            saveTable.Column = (item as GUI.DeskUserControl).Column;
                            saveTable.Column = (item as GUI.DeskUserControl).Row;
                            xs.Serialize(sw, saveTable);

                        }
                    }
                    MessageBox.Show("הנתונים נשמרו בהצלחה");
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sw.Close();
            }
        }
        public void UpdateTablesLists(string todell, string toadd)
        {//בעת שיבוץ תלמידה הפעלת פונקציות המחיקה וההוספה על מנת
         //למחוק את התלמידה שנבחרה משאר השולחנות כדי שלא יהיה שיבוץ כפול
         //וכן אם בוטל שיבוץ תלמידה בשולחן מסוים יש להחזיר אותה לשאר השולחנות כדי שתוכל להבחר לשבת בשולחן אחר
         //כמו כן עדכון כמה תלמידות עדיין לא משובצות
            if (todell != " ")
            {
                foreach (var item in Controls)
                {
                    if (item is GUI.DeskUserControl)
                        (item as GUI.DeskUserControl).DeleteStudentFromList(todell);
                }
            }
            if (toadd != " ")
            {
                foreach (var item in Controls)
                {
                    if (item is GUI.DeskUserControl)
                        (item as GUI.DeskUserControl).AddStudentToList(toadd);
                }
            }
            if (todell == " " && toadd != " ")
            {
                numStudent += 1;
                numStudents.Text = "מספר התלמידות שעדיין אינן משובצות: " + numStudent.ToString();
                Controls.Remove(numStudents);
                Controls.Add(numStudents);
                Console.WriteLine(numStudents.Text);
            }
            if (todell != " " && toadd == " ")
            {
                numStudent -= 1;
                numStudents.Text = "מספר התלמידות שעדיין אינן משובצות: " + numStudent.ToString();

                Console.WriteLine(numStudents.Text);

            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void ClassRoom_Load_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;            
            path = @"../../" + room + ".xml";
            myClassrom = XDocument.Load(path);
            int rows = myClassrom.Root.Descendants("column").Count();
            columns = new int[rows];
            for (int i = 0; i < rows; i++)//הכנסה למערך כמה שולחנות יש בכל טור
            {
                columns[i] = myClassrom.Root.Descendants("column").First(p => p.Attribute("col").Value == (i + 1).ToString()).Descendants("table").Count();
            }
            for (int i = 0; i < columns.Length + 1; i++)
            {//ציור השולחנות על פי המפה וכן ציור ההוראות וההסברים
                if (i == columns.Length)
                {//באיטרציה האחרונה הוספת תווית עם הסברים
                    Label instructions = new Label();
                    instructions.Location = new Point((i + 1) * 300 + (i - 4) * 35, 30);
                    instructions.Width = 250;
                    instructions.Height = 800;
                    instructions.RightToLeft = RightToLeft.Yes;
                    instructions.Text = "הוראות והסברים לשיבוץ\n" +
                        "כאמור השיבוץ נעשה על פי 3 פרמטרים:\n" +
                        "1.אילוצי תלמידה \n" +
                        "2.שילוב 2 תלמידות יחד מבחינת פטפוט\n" +
                        "3.שיבוץ תלמידה בשולחן מבחינת שורה מומלצת\n" +
                        "המערכת מתריעה על הפרמטרים הללו באופנים הבאים:" +
                        "בשיבוץ זוג תלמידות שדרגת הפטפוט שלהן קטן מ5 יצבע השולחן בירוק\n" +
                        "בשיבוץ זוג תלמידות שדרגת הפטפוט שלהן גדול מ5 יצבע השולחן בצהוב\n" +
                        " בשיבוץ זוג תלמידות שדרגת הפטפוט שלהן גדול מ7 יצבע השולחן באדום\n" +
                        "אם תלמידה שובצה בשורה המומלצת לה תצבע התלמידה בירוק\n" +
                     "אם הפרש בין השורה המומלצת לשורת השיבוץ לא גדול מ1 תצבע בצהוב\n" +
                     "אחרת תצבע באדום\n" +
                     "אם קיימת סתירה בין מאפיני שולחן לבקשת תלמידה \n" +
                     "תופיע התרעה\n" +
                     "שימו לב בעת מעבר על השולחן יופיעו מאפיני השולחן" +
                     "\nבעת לחיצה על כפתור עזרה תופענה התלמידות המתאימות לשבת בשולחן מבחינת אילוצים\n" +
                     "וכן מבחינת שורה מומלצת כל עוד החריגה אינה גדולה מ1" +
                     "\nבעת יציאת העכבר מרשימת התלמידות היכולות לשבת בשולחן-הרשימה תוסר";
                    Controls.Add(instructions);
                    break;
                }
                for (int j = columns[i] - 1; j >= 0 && i < columns.Length; j--)
                {//ציור השולחנות 
                    DeskUserControl table = new DeskUserControl(grade);
                    table.Column = i + 1;
                    table.Row = j + 1;
                    bool b = myClassrom.Root.Descendants("column").First(p => p.Attribute("col").Value == (i + 1).ToString())
                    .Descendants("table").First(c => c.Attribute("row").Value == (j + 1).ToString())
                    .Attribute("nearwindow").Value == "yes" ? true : false;
                    table.TablesProp.Add(1, b);
                    b = myClassrom.Root.Descendants("column").First(p => p.Attribute("col").Value == (i + 1).ToString())
                    .Descendants("table").First(c => c.Attribute("row").Value == (j + 1).ToString())
                    .Attribute("neardoor").Value == "yes" ? true : false;
                    table.TablesProp.Add(2, b);
                    b = myClassrom.Root.Descendants("column").First(p => p.Attribute("col").Value == (i + 1).ToString())
                   .Descendants("table").First(c => c.Attribute("row").Value == (j + 1).ToString())
                   .Attribute("nearconditioner").Value == "yes" ? true : false;
                    table.TablesProp.Add(3, b);
                    b = myClassrom.Root.Descendants("column").First(p => p.Attribute("col").Value == (i + 1).ToString())
                    .Descendants("table").First(c => c.Attribute("row").Value == (j + 1).ToString())
                    .Attribute("hide").Value == "yes" ? true : false;
                    table.TablesProp.Add(4, b);
                    table.Size = new Size(300, 150);
                    table.Location = new Point(i * 300 + (i + 1) * 15, 150 * (columns[i] - 1 - j) + 10 * (columns[i] - j));
                    table.Updatelist = UpdateTablesLists;

                    Controls.Add(table);


                }
                //הוספת תווית המציינת כמה תלמידות עדיין לא שובצו-בתחילה כל בנות הכיתה לא משובצות
            numStudents.Location = new Point(800, columns.Max() * 160);
                numStudents.Width = 500;
                numStudent = BL.StudentsManagement.GetStudentsByClass(grade).Count();
                numStudents.Text = "מספר התלמידות שעדיין אינן משובצות: " + numStudent.ToString();
                Controls.Add(numStudents);
                Button save = new Button();//הוספת כפתור לשמירת השיבוץ כקובץ
                save.Location = new Point(1400, columns.Max() * 160);
                save.Text = "שמירה כקובץ";
                save.Click += saveRoomMap;
                Controls.Add(save);
            }
        }
    }
}

