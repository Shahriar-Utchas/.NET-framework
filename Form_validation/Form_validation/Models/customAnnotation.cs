using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Form_validation.Models
{
    public class customEmail: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                student student = (student)validationContext.ObjectInstance;
                string _id = student.ID;
                string email = "";
                string value_email = value.ToString();
                int length = value_email.Length;

                for (int i = 0; i < length; i++)
                {
                    if (value_email[i] == '@')
                    {
                        break;
                    }
                    else
                    {
                        email += value_email[i];
                    }
                }

                if (email != _id)
                {
                    var errorMessage = "Email does not match with student id";
                    return new ValidationResult(errorMessage);
                }
                else
                {
                    var complete_email = _id + "@student.aiub.edu";
                    if (complete_email != value_email)
                    {
                        var errorMessage = "Must be a valid email address";
                        return new ValidationResult(errorMessage);
                    }
                }
            }

            return ValidationResult.Success;

        }

        }
    public class customDOB : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value != null)
            {
                DateTime date;
                if (DateTime.TryParse(value.ToString(), out date))
                {
                    if (date.AddYears(18) > DateTime.Now)
                    {
                        var errorMessage = "Age must be 18+";
                        return new ValidationResult(errorMessage);
                    }
                }
            }
            return ValidationResult.Success;

        }
    }

}