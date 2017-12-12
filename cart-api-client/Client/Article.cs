using System;

namespace Client
{
    /// <summary>
    /// Represents Item in the shop
    /// </summary>
    public class Article : IEquatable<Article>
    {
        /// <summary>
        /// Gets or sets the identifier of the Article.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Determines whether the specified <see cref="Client.Article"/> is equal to the current <see cref="T:Client.Article"/>.
        /// </summary>
        /// <param name="other">The <see cref="Client.Article"/> to compare with the current <see cref="T:Client.Article"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="Client.Article"/> is equal to the current
        /// <see cref="T:Client.Article"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(Article other)
        {
            if (other == null)
                return false;

            if (this == other)
                return true;

            return GetHashCode() == other.GetHashCode();
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="T:Client.Article"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
        {
            return Id;
        }
    }
}
