using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionApp.Attributes.Validation
{
    public class MyPriceGreaterThanBestBidPriceAttribute : ValidationAttribute
    {
        readonly string _bestBidPricePropertyName;

        public MyPriceGreaterThanBestBidPriceAttribute(string bestBidPricePropertyName)
        {
            _bestBidPricePropertyName = bestBidPricePropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            var myPrice = Convert.ToDecimal(value);
            var bestBidPriceProperty = validationContext.ObjectType.GetProperty(_bestBidPricePropertyName);

            if (bestBidPriceProperty == null) throw new ArgumentException("Property not found.");

            var bestBidPriceValue = (decimal)bestBidPriceProperty.GetValue(validationContext.ObjectInstance);

            if (myPrice <= bestBidPriceValue) return new ValidationResult(ErrorMessage);
            return ValidationResult.Success;
        }
    }
}
