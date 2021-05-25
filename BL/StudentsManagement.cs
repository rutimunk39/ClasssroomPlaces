using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BL
{
    public class StudentsManagement
    {//ניהול תלמידים
        public static bool AddStudent(students student)
        {
            using (classEntities db = new classEntities())
            {
                
                //if (db.students.Where(p=>p.family_name.Equals(student.family_name)).Any()==false)
                if (db.students.Where(p => p.id == student.id).Any() == false)
                {
                    db.students.Add(Convertions.GetStudents(student));
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public static bool RemoveStudent(int id)
        {
            using (classEntities db = new classEntities())
            {
                if (db.students.Where(p => p.id == id).Any())
                {
                    db.students.Remove(db.students.Where(p => p.id == id).First());
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public static List<students> GetStudentsByClass(int grade)
        {
            using (classEntities db = new classEntities())
            {
                return Convertions.GetStudentsList(db.students.Where(c => c.@class == grade).ToList());
            }
        }
        public static DAL.students GetStudentsByName(string name)
        {
            using (classEntities db = new classEntities())
            {
                return db.students.Where(c => c.first_name == name).FirstOrDefault();
            }
        }
        public static int ExitsProperties(string name, int code)
        {

            using (classEntities db = new classEntities())
            {
                int id = db.students.Where(p => p.first_name == name).First().id;
                try
                {
                    DAL.student_type prop = db.student_type.Where(p => p.id == code && p.student_id == id).First();
                    if (prop.ok == false)
                        return 1;
                    return 2;
                }
                catch (Exception)
                {
                    return 0;
                }

            }
        }
        public static void AlterPropertiesToStudents(string name, int prop, int status)
        {
            using (classEntities db = new classEntities())
            {
                int id = db.students.Where(p => p.first_name == name).First().id;
                if (status == 0)
                {

                    db.student_type.Remove(db.student_type.First(p => p.student_id == id && p.type_kod == prop));
                }
                else
                {
                    if (status == 1)
                    {
                        db.student_type.Add(new DAL.student_type() { type_kod = prop, student_id = id, ok = false });
                    }
                    if (status == 2)
                    {
                            db.student_type.First(p => p.student_id == id && p.type_kod == prop).ok = true;
                    }
                }
                db.SaveChanges();
            }
        }
        public static void UpdateLineAndRow(string student, int row, int col)
        {
            if (student != " ")
            {
                using (classEntities db = new classEntities())
                {
                    DAL.students s = db.students.Where(p => p.first_name == student).First();
                    if (s != null)
                    {
                        s.line = row;
                        s.col = col;
                    }
                    db.SaveChanges();
                }
            }
        }
    }
}

