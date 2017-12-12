using System;

namespace Client
{
    //ToDo add comments
    public class Article : IEquatable<Article>
    {
        public int Id
        {
            get;
            set;
        }

        public bool Equals(Article other)
        {
            if (other == null)
                return false;

            if (this == other)
                return true;

            return GetHashCode() == other.GetHashCode();
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
