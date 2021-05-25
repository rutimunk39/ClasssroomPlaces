using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SchedulingT
    {//מחלקת שיבוץ שולחן האם 2 תלמידות יכולות לשבת יחד מבחינת רמת פטפוט
        public students student1 { get; set; }
        public students student2 { get; set; }
        public SchedulingT(string name1, string name2)
        {
            student1 = StudentsManagement.GetStudentsByName(name1);//איתור התלמידה שזהו שמה
            student2 = StudentsManagement.GetStudentsByName(name2);
        }
        public values checkMatch() {
            if (student1.chat + student2.chat < 5) { return values.Excellent; }
            if (student1.chat + student2.chat < 7) { return values.Possible; }
            return values.Impossible;
        }
    }
}
