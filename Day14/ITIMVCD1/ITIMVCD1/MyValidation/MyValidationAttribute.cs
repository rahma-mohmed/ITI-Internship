using System.ComponentModel.DataAnnotations;

namespace ITIMVCD1.MyValidation
{
    public class MyValidationAttribute:ValidationAttribute
    {
        //server side
        public override bool IsValid(object? value)
        {
            return base.IsValid(value); 
        }
    }
}
