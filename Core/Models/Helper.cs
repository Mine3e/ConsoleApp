using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.Models
{
    public static class Helper
    {
        public static bool CheckName(this string name)
        {
            return Regex.IsMatch(name, @"^[A-Z][a-z]{2,}( [A-Z][a-z]{2,})*$") && name.Split(' ').Length == 1;
        }

        public static bool CheckSurName(this string surname)
        {
            return Regex.IsMatch(surname, @"^[A-Z][a-z]{2,}( [A-Z][a-z]{2,})*$") && surname.Split(' ').Length == 1;
        }

        public static bool CheckClassroomName(this string classroomname)
        {
            return Regex.IsMatch(classroomname, @"^[A-Z]{2}\d{3}$");
        }
    }
}