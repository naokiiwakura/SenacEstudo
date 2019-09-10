using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Tools
{
    public static class Auxiliar
    {
        public static int CalculateAge(DateTime dateOfBirth)
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age -= 1;

            return age;
        }
    }
}
