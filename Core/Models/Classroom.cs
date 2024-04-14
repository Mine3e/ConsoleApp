using Core.Enums;
using Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.Models
{
    public class Classroom
    {
        private static int _id;
        public int Id { get; set; }
        private string _name;
        private ClassType _classType;
        public Student[] _students;
        private int _studentCount;
        private int _studentLimit;

        public Classroom(string name, ClassType classType)
        {
            _id++;
            Id = _id;
            _name = name;
            _classType = classType;
            _studentLimit = StudentLimit(classType);
            _students = new Student[0];
        }
        public Student FindId(int id)
        {
            for (int i = 0; i < _students.Length; i++)
            {
                if (_students[i].Id == id)
                {
                    return _students[i];
                }
            }

            throw new StudentNotFoundException("StudentNotFoundException");
        }

        public void Delete(int id)
        {
            
            foreach(Classroom classroom in Database._classrooms)
            {
                bool found = false;
                for (int i=0; i<classroom._students.Length; i++)
                {
                    if (classroom._students[i].Id == id && classroom._students[i] != null)
                    {
                        classroom._students[i] = null;
                        found = true;
                        break;
                    }
                    
                }
                if (found)
                {
                    return;
                }
            }
            throw new StudentNotFoundException("StudentNotFoundException");
        }

        private int StudentLimit(ClassType type)
        {
            return type == ClassType.Backend ? 20 : 15;
        }

        public static Classroom CreateClassroom(string name, ClassType classType)
        {
            if (!Helper.CheckClassroomName(name))
            {
                throw new ClassNotFoundException("Classroom name duzgun deyil.");
            }

            return new Classroom(name, classType);
        }


        public void StudentAdd(int classroomId, Student student)
        {

            foreach (Classroom classroom in Database._classrooms)
            {
                
                if (classroom.Id == classroomId)
                {
                    if (classroom._studentCount < classroom._studentLimit)
                    {

                        Array.Resize(ref classroom._students, classroom._students.Length + 1);
                        classroom._students[^1] = student;
                        classroom._studentCount++;

                    }
                    else
                    {
                        Console.WriteLine("Student limit kecdiniz.");
                    }
                }

            }
        }


        public void ShowAllStudents()
        {
            foreach (Classroom classroom in Database._classrooms)
            {
                foreach (Student student in classroom._students)
                {
                    if (student != null)
                    {
                        Console.WriteLine($"ID:{student.Id}, Name:{student.Name}, Surname:{student.SurName},ClasroomName:{classroom._name}, ClasroomId:{classroom.Id}");
                    }
                }
            }

        }


        public void ShowStudentsInClassroom(int classroomId)
        {
            foreach (Classroom classroom in Database._classrooms)
            {
                if (classroom.Id == classroomId)
                {
                    foreach (Student student in classroom._students)
                    {
                        if (student != null)
                        {
                            Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Surname: {student.SurName} , ClassroomName:{classroom._name}, ClassroomId:{classroom.Id}");
                        }
                    }
                }
            }
        }

    }
}