using Core.Enums;
using Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Student
    {
        private static int _id;
        public int Id { get; set; }
        private  string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (Helper.CheckName(value))
                {
                    _name = value;
                }
                else
                {
                    Console.WriteLine("Student name duzgun deyil");
                }
            }
        }
        private  string _surName;
        public string SurName
        {
            get
            {
                return _surName;
            }
            set
            {
                if (Helper.CheckSurName(value))
                {
                    _surName = value;
                }
                else
                {
                    Console.WriteLine("Student surname duzgun deyil");
                }
            }
        }
        public Student(string name, string surname)
        {
            _id++;
            Id = _id;
            Name = name;
            SurName = surname;
        }


    }
}