using System;

namespace Playground.Models
{
    public struct EnumStruct : IEquatable<EnumStruct>
    {
        public Enum1 Enum1 { get; }
        public Enum2 Enum2 { get; }
        public Enum3 Enum3 { get; }
        public Enum4 Enum4 { get; }

        public EnumStruct(Enum1 enum1, Enum2 enum2, Enum3 enum3, Enum4 enum4)
        {
            Enum1 = enum1;
            Enum2 = enum2;
            Enum3 = enum3;
            Enum4 = enum4;
        }

        public bool Equals(EnumStruct other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Enum1 == other.Enum1
                   && Enum2 == other.Enum2
                   && Enum3 == other.Enum3
                   && Enum4 == other.Enum4;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((EnumStruct)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Enum1.GetHashCode();
                hashCode = (hashCode * 397) ^ Enum2.GetHashCode();
                hashCode = (hashCode * 397) ^ Enum3.GetHashCode();
                hashCode = (hashCode * 397) ^ Enum4.GetHashCode();
                return hashCode;
            }
        }
    }
}
