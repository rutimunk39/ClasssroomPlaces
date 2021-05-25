using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BL
{
    class Convertions
    {//מחלקת המרה
        public static students GetStudents(students student)
        {
            return new students()
            {
                id = student.id,
                first_name = student.first_name,
                family_name = student.family_name,
                @class = (int)student.@class,
                chat = (int)student.chat,
                rec_row = (int)student.rec_row,
                col = null,
                line = null
            };
        }
        public static @class GetClasses(@class studntClass)
        {
            return new @class() { id = studntClass.id, class_name = studntClass.class_name };
        }
        public static seat_type GetPropertiesOfPlaces(DAL.seat_type prop)
        {
            return new seat_type() { id = prop.id, name_type = prop.name_type };
        }
        public static student_type GetStudentPropertiesOfPlaces(DAL.student_type sp)
        {
            return new student_type() { id = sp.id, student_id = (int)sp.student_id, type_kod = (int)sp.type_kod, ok = (bool)sp.ok };
        }                          
        public static List<students> GetStudentsList(List<DAL.students> students)
        {
            List<students> students2 = new List<students>();
            students.ForEach(p => students2.Add(GetStudents(p)));
            return students2;
        }
    }
}

