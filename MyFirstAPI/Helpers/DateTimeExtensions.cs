using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.Helpers
{
    public static class DateTimeExtensions
    {
        public static int CalculateAge(this DateTime dateOfBirth)
        {
            var temp = DateTime.Now - dateOfBirth;

            int age = Convert.ToInt32(temp.Days / 365.25);

            return age;
        }
    }
}
