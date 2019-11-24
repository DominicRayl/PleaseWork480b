using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace quotable.core
{
    /// <summary>
    /// The database context. This the class that will interact with the database.
    /// </summary>
    public class quotableContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public quotableContext(DbContextOptions options) : base(options)
        {

        }

        //These comments are yours, slighlty edited.
        /// <summary>
        /// Used to access quotes in the database.
        /// </summary>
        public DbSet<Quote> Quotes { get; set; }

        /// <summary>
        /// Used to access authors in the database.
        /// </summary>
        public DbSet<Author> Authors{ get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuoteAuthor>().HasKey(x => new { x.QuoteId, x.AuthorId });
        }       

    }

}
