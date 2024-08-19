
using System.Text.RegularExpressions;

namespace EasyPOS.Domain.ValueObjects
{
    public partial record PhoneNumber
    {
        private const int DefaultLenght = 10;
        private const string Pattern = @"^(?:-*\d-*){9}$";

        public string Value { get; init; }


        private PhoneNumber(string value)
        {
            Value = value;
        }

        public static PhoneNumber? Create(string value)
        {
            if (string.IsNullOrEmpty(value) || !PhoneNumberRegex().IsMatch(value) || value.Length != DefaultLenght)
            {
                return null;
            }
            return new PhoneNumber(value);
        }

        [GeneratedRegex(Pattern)]
        private static partial Regex PhoneNumberRegex();

    }
}
