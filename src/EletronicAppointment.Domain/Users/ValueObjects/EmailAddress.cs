using System.Text.RegularExpressions;

namespace EletronicAppointment.Domain.Users.ValueObjects;

public struct EmailAddress : IEquatable<EmailAddress>
{
    private string _text;
    public EmailAddress(string text)
    {
        var reg = new Regex("^\\S+@\\S+\\.\\S+$");
        
        if (!reg.IsMatch(text))
            throw new Exception("Invalid email");

        this._text = text;
    }

    public override bool Equals(object other)
    {
        if (other is EmailAddress EmailAddressObj)
        {
            return this.Equals(EmailAddressObj);
        }
        return false;
    }
    public static implicit operator EmailAddress(string text) => new EmailAddress(text);
    public static implicit operator string(EmailAddress Description) => Description._text;
    public override int GetHashCode() => this._text.GetHashCode(StringComparison.OrdinalIgnoreCase);
    public static bool operator ==(EmailAddress left, EmailAddress right) => left.Equals(right);
    public static bool operator !=(EmailAddress left, EmailAddress right) => !(left == right);
    public override string ToString() => this._text;
    public bool Equals(EmailAddress other) => this._text == other._text;
}