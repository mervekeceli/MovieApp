using System;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Web.Validators
{
    public class BirthDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime = Convert.ToDateTime(value);
            return dateTime <= DateTime.Now;
        }
    }
}
