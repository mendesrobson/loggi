using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;

namespace App.Application.AttributeValidation
{
    public sealed class JsonFormatAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            string str = JsonConvert.SerializeObject(value);


            if (str.TryParseJson())
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Metadata deve ter o formato array de json ex: {\"key\":\"value\",\"key\":\"value\"}.");
        }
    }

    public static class JsonExtension
    {
        public static bool TryParseJson(this string str)
        {
            try
            {
                JToken jObject = JToken.Parse(str);
                JObject.Parse(jObject.ToString());

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
