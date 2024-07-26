using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace QuanLyKhoaHoc.Domain.Validations
{
    public class ValidateInput
    {
        public static bool IsValidEmail(string email)
        {
            var emailAttribute = new EmailAddressAttribute();
            return emailAttribute.IsValid(email);
        }

        public static bool IsValidPhoneNumber(string phoneNumber) {
            string pattern = @"(?:\+84|0084|0)[235789][0-9]{1,2}[0-9]{7}(?:[^\d]+|$)";
            return Regex.IsMatch(phoneNumber, pattern);
        }
    }
}
