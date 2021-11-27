using System;

namespace WordSearch
{
    public class Result : IEquatable<Result>
    {
        public string Word { get; set; }
        public Tuple<int,int> StartPoint { get; set; }
        public Tuple<int,int> EndPoint { get; set; }

        public bool Equals(Result other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Word == other.Word && Equals(StartPoint, other.StartPoint) && Equals(EndPoint, other.EndPoint);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Result)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Word, StartPoint, EndPoint);
        }

        public static bool operator ==(Result left, Result right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Result left, Result right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"{Word} found at ({StartPoint.Item1},{StartPoint.Item2}) to ({EndPoint.Item1}, {EndPoint.Item2})";
        }
    }
}