using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    public enum values { Excellent, Possible, Impossible }
    public class SchedulingS
        //מחלקת שיבוץ תלמידה
    {
        
        public students student { get; set; }
        //seat_type[]seatArr
        public students GetStudent()
        {
            return Convertions.GetStudents(student);
        }
        public SchedulingS(string name)
        {//בדיקת השיבוץ בשולחן מבחינת שורה מומלצת לתלמידה
            student = StudentsManagement.GetStudentsByName(name);
        }
        public bool checkConstraints( Dictionary<int, bool> TablesProp)
        {//בודקת האם קיימת סתירה בין אילוצי תלמידה למאפייני שטלחן 
            using (classEntities db = new classEntities())
            {
                
                foreach (var prop in TablesProp)
                {
                    if (db.student_type.Any(p => p.student_id == student.id && p.type_kod == prop.Key && p.ok != prop.Value))
                    {
                        return true;//יש התנגשות
                    }
                }
            }
            return false;//אין התנגשות
        }
        public values checkLocation(int row)
        {//בדיקת מיקומים
            if(student.rec_row == 0 || row == student.rec_row)//אם עבור התלמידה אין שורה מועדפת מסוימת או ששובצה בשורה המומלצתkk
            { return values.Excellent; }
            if(Math.Abs(row - (int)student.rec_row)== 1)         
            { return values.Possible; }
            return values.Impossible;
        }
        
    }
}
