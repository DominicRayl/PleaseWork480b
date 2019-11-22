using System.Collections.Generic;

namespace quotable.core
{
    /// <summary>
    /// The author of a quote
    /// </summary>
    public sealed class Author
    {
        /// <summary>
        /// This is what makes the authot unique. I know it makes me feel unique.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The first name of the author
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the author
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The relation of document to author
        /// </summary>
        public ICollection<QuoteAuthor> QuoteAuthor { get; set; }
    }
}