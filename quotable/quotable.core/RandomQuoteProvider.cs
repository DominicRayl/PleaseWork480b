using System;
using System.Collections.Generic;
using System.Text;

namespace quotable.core
{
    /// <summary>
    /// Interfaced used by Simple and Default random quote providers. (I have no idea how I should have commented this one)
    /// </summary>
    public interface RandomQuoteProvider
    {
       IEnumerable<string> quotez(long numOfQuotes);
        
    }
}
