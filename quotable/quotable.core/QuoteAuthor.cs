namespace quotable.core
{
    /// <summary>
    /// Represents the many-to-many relation between documents and authors
    /// </summary>
    public class QuoteAuthor
    {
        /// <summary>
		/// The ID of the quote related to the author.
		/// </summary>
		public long QuoteId { get; set; }
        /// <summary>
        /// The quote related to the author.
        /// </summary>
        public Quote Quote { get; set; }

        /// <summary>
        /// The ID of the author related to the quote.
        /// </summary>
        public long AuthorId { get; set; }
        /// <summary>
        /// The author related to the quote.
        /// </summary>
        public Author Author { get; set; }
    }
}