using System.Text.RegularExpressions;

namespace src; 

public static class StringValidationExtensions
{
    public static bool IsValidEgyptianPhone(this string? value)
    {
        return value != null && Regex.IsMatch(value, @"^(01[0125]\d{8}|\+20 1[0125]\d{8})$");
    }
    public static bool IsValidEgyptianNationalId (this string? value) 
    {
        return value != null && Regex.IsMatch(value, @"^[23]\d{13}$");
    }
}
