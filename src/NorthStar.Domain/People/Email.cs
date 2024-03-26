using NorthStar.Domain.Abstractions;
using System.Globalization;
using System.Text.RegularExpressions;

namespace NorthStar.Domain.People;

public class Email : ValueObject
{
    public string Value { get; private set; }

    public Email(string email)
    {
        if(string.IsNullOrEmpty(email))
        {
            throw new ArgumentNullException("Email", "Email cannot be null or empty.");
        }

        if(!IsValidEmail(email))
        {
            throw new ArgumentException("Email is not valid.", "Email");
        }

        Value = email;
    }

    public static implicit operator Email(string email) => new(email);

    public override string ToString() => Value;


    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }


    private static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            // Normalize the domain
            email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                  RegexOptions.None, TimeSpan.FromMilliseconds(200));

            // Examines the domain part of the email and normalizes it.
            string DomainMapper(Match match)
            {
                // Use IdnMapping class to convert Unicode domain names.
                var idn = new IdnMapping();

                // Pull out and process domain name (throws ArgumentException on invalid)
                string domainName = idn.GetAscii(match.Groups[2].Value);

                return match.Groups[1].Value + domainName;
            }
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
        catch (ArgumentException)
        {
            return false;
        }

        try
        {
            return Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }
}