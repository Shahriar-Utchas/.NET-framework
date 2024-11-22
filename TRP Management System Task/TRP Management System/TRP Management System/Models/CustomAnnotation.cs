using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TRP_Management_System.EF;

namespace TRP_Management_System.Models
{
    public class ChannelUniqueName: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return new ValidationResult("Channel Name is Required");
            }
            TRP_Management_SystemEntities db = new TRP_Management_SystemEntities();
            var channels = db.Channels.ToList();
            var channelName = value.ToString();
            var valueExist = channels.Any(c => c.ChannelName == channelName);
            if (valueExist)
            {
                var errorMessage = "Channel Already Exist";
                return new ValidationResult(errorMessage);
            }

            return ValidationResult.Success;

        }

    }
    public class ChannelYearValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Establish Year is Required");
            }
            var year = Convert.ToInt32(value);
            if (year > DateTime.Now.Year)
            {
                var errorMessage = "Establish Year must be between 1900 and Current Year";
                return new ValidationResult(errorMessage);
            }
            return ValidationResult.Success;
        }

    }
    public class ProgramUniqueName : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Program Name is Required");
            }
            var db = new TRP_Management_SystemEntities();
            
            var programName = value.ToString();

                // Retrieve the ChannelId from the object being validated
                var instance = validationContext.ObjectInstance;
                var channelIdProperty = validationContext.ObjectType.GetProperty("ChannelId");

                int channelId = (int)channelIdProperty.GetValue(instance);

                // Check if the program exists within the specified channel
                var valueExist = db.Programs.Any(p => p.ProgramName == programName && p.ChannelId == channelId);

                if (valueExist)
                {
                    var errorMessage = "Program Already Exists within the selected Channel.";
                    return new ValidationResult(errorMessage);
                }
            

            // Validation passed
            return ValidationResult.Success;
        }
    }



}