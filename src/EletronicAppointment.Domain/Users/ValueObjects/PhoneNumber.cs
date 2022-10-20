using System.Text.RegularExpressions;

namespace EletronicAppointment.Domain.Users.ValueObjects;

public struct PhoneNumber : IEquatable<PhoneNumber>
{
    private string _text;
    public PhoneNumber(string text)
    {
        var reg = new Regex("^\\+?[1-9][0-9]{7,14}$");
        
        if (!reg.IsMatch(text))
            throw new Exception("Invalid email");

        this._text = text;
    }

    public override bool Equals(object other)
    {
        if (other is PhoneNumber EmailAddressObj)
        {
            return this.Equals(EmailAddressObj);
        }
        return false;
    }
    public static implicit operator PhoneNumber(string text) => new PhoneNumber(text);
    public static implicit operator string(PhoneNumber Description) => Description._text;
    public override int GetHashCode() => this._text.GetHashCode(StringComparison.OrdinalIgnoreCase);
    public static bool operator ==(PhoneNumber left, PhoneNumber right) => left.Equals(right);
    public static bool operator !=(PhoneNumber left, PhoneNumber right) => !(left == right);
    public override string ToString() => this._text;
    public bool Equals(PhoneNumber other) => this._text == other._text;
}