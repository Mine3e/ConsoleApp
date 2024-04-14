using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Database
    {
        public static Classroom[] _classrooms;

        public Database()
        {
            _classrooms = new Classroom[0];
        }

        public void AddClassroom(Classroom classroom)
        {
            Array.Resize(ref _classrooms, _classrooms.Length + 1);
            _classrooms[^1] = classroom;
        }

        public static Classroom[] GetClassrooms()
        {
            return _classrooms;
        }
    }
}