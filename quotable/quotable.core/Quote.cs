using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace quotable.core
{
    /// <summary>
    /// quotes given by an author
    /// </summary>
    public sealed class Quote
    {
        /// <summary>
        /// The unique identifier for the document.
        /// </summary>

        public long Id { get; set; }

        /// <summary>
        /// The title of the document.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The collection of authors of the document
        /// </summary>
        [NotMapped]
        public IEnumerable<Author> Authors => from x in QuoteAuthor select x.Author;

        /// <summary>
        /// The relation of document to author
        /// </summary>
        public ICollection<QuoteAuthor> QuoteAuthor { get; set; } = new List<QuoteAuthor>();

    }
}