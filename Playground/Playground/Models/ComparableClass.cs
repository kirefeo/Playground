using System;

namespace Playground.Models
{
    class ClassWithIdentifier
    {
        public int Value { get; set; }
        public Identifier Identifier { get; set; }
    }

    public class ComparableClass : IEquatable<ComparableClass>
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public int Value { get; set; }

        public bool Equals(ComparableClass other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Number == other.Number
                   && string.Equals(Name, other.Name)
                   && string.Equals(Code, other.Code)
                   && Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ComparableClass)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Number;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Code != null ? Code.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Value;
                return hashCode;
            }
        }
    }

    class Identifier : IEquatable<Identifier>
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public bool Equals(Identifier other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Number == other.Number
                   && string.Equals(Name, other.Name)
                   && string.Equals(Code, other.Code);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Identifier)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Number;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Code != null ? Code.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
