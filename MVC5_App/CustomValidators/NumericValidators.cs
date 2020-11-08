using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5_App.CustomValidators
{
    /// <summary>
    /// The custom validator will implement 
    /// ValidationAttribute class and will implement the IsValid method
    /// This method will contain the validation logic
    /// </summary>
    public class NumericValidatorAttribute : ValidationAttribute
    {
        // value is the parameter that will be entered in the
        // textbox on which property the validaiton is applied
        public override bool IsValid(object value)
        {
            int val = Convert.ToInt32(value);
            if (val < 0) return false;
            return true;
        }
    }
}