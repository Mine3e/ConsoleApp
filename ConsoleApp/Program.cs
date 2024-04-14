using Core.Enums;
using Core.Exceptions;
using Core.Models;
using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            Classroom classroom = null;

            int chooise;
            do
            {
                Console.WriteLine("Menu-");
                Console.WriteLine("1.Classroom yarat");
                Console.WriteLine("2.Student yarat");
                Console.WriteLine("3.Butun Telebeleri ekrana cixart");
                Console.WriteLine("4.Secilmis sinifdeki telebeleri ekrana cixart");
                Console.WriteLine("5.Telebe sil");
                Console.WriteLine("0.Proqrami bitir");

                Console.WriteLine("Seciminizi edin:");

                int.TryParse(Console.ReadLine(), out chooise);

                switch (chooise)
                {
                    case 0:
                        Console.WriteLine("Proses bitdi.");
                        break;
                    case 1:
                        try
                        {
                            Console.Write("Classroom name: ");
                            string classroomName = Console.ReadLine();

                            Console.WriteLine("0.Backend");
                            Console.WriteLine("1.Frontend");
                            string answerStr = "";
                            ClassType classType;
                            do
                            {
                                Console.WriteLine(" Class Type:");
                                answerStr = Console.ReadLine();
                            } while (!Enum.TryParse(answerStr, out classType));

                            classroom = Classroom.CreateClassroom(classroomName, classType);
                            if (classroom != null)
                            {
                                database.AddClassroom(classroom);

                            }

                        }
                        catch (ClassNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 2:
                        try
                        {
                            Console.Write("Student name: ");
                            string name = Console.ReadLine();
                            Console.Write("Student surname: ");
                            string surname = Console.ReadLine();
                            Student newstudent = new Student(name, surname);
                            string strId = "";
                            int classroomId;
                            do
                            {
                                Console.WriteLine("Classroom id daxil edin:");
                                strId = Console.ReadLine();
                            } while (!int.TryParse(strId, out classroomId));
                            classroom.StudentAdd(classroomId, newstudent);

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 3:
                        classroom.ShowAllStudents();

                        break;
                    case 4:
                        string idstr = "";
                        int idd;
                        do
                        {
                            Console.WriteLine("Gormek istediyiniz sinfin id'sini daxil edin:");
                            idstr = Console.ReadLine();
                        } while (!int.TryParse(idstr, out idd));
                        classroom.ShowStudentsInClassroom(idd);

                        break;
                    case 5:
                        try
                        {

                            string idStr = "";
                            int id;
                            do
                            {
                                Console.WriteLine("Silmek istediyiniz telebenin id'sini daxil edin:");
                                idStr = Console.ReadLine();
                            } while (!int.TryParse(idStr, out id));
                            classroom.Delete(id);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    default:
                        Console.WriteLine("Duzgun deyer daxil edin:");
                        break;
                }
            } while (chooise != 0);
        }
    }
}