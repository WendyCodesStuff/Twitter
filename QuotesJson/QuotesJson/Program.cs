using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.IO;

// GET WRITING QUOTES FROM BRAINYQUOTE.COM AND PUT ONES OF <= 140 CHARS IN JSON FILE

// Download Brainy Quotes HTML
// Trawl the text getting quotes that are <= 140 chars
// Add them to JSON string
// Save JSON

namespace QuotesJson
{
    class Program
    {
        const long MaxChars = 140;

        static void Main(string[] args)
        {
            IEnumerable<string> listOfQuotes = new List<string>(); 

            // Loop through each html page of quotes, grabbing useable quotes
            for (int i = 1; i <= 39; i++)
            {
                // Get the HTML
                WebClient client = new WebClient();
                string url = "https://www.brainyquote.com/topics/writing-quotes_" + i;
                String htmlCode = client.DownloadString(url);

                // Get list of quotes
                if (listOfQuotes.Any())
                {
                    // Get more quotes
                    listOfQuotes = listOfQuotes.Concat(EnumerateQuotes(htmlCode));
                }
                else
                {
                    // Must be our first run, so no need to concat
                    listOfQuotes = EnumerateQuotes(htmlCode);
                }

             }

            // Create JSON from list of quotes
            string newJson = CreateJSON(listOfQuotes);

            // Insert newly creating JSON into JSON file
            InsertJSON(newJson);

            Console.WriteLine("Complete");

        }

        // Get list of quotes from HTML
        public static IEnumerable<string> EnumerateQuotes(string html)
        {
            int pointer = 0;
            string openQuote = "title=" + (char)34 + "view quote" + (char)34 + ">";
            string openAuthor = "title=" + (char)34 + "view author" + (char)34 + ">";
            string closeQuote = "</a>";
         
            // As long as we still have quotes to collect
            while (html.Substring(pointer).Contains(openQuote))
            {
                // Quote start
                int quoteStart = html.IndexOf(openQuote, pointer, StringComparison.CurrentCulture) + openQuote.Length;

                // Quote end
                int quoteEnd = html.IndexOf(closeQuote, quoteStart, StringComparison.CurrentCulture) + openQuote.Length;
                int quoteLength = quoteEnd - quoteStart - openQuote.Length;

                // Get quote
                string quote = html.Substring(quoteStart, quoteLength);

                // Author start
                int authorStart = html.IndexOf(openAuthor, quoteEnd, StringComparison.CurrentCulture) + openAuthor.Length;

                // Author end
                int authorEnd = html.IndexOf(closeQuote, authorStart, StringComparison.CurrentCulture);

                int authorLength = authorEnd - authorStart;

                // Get author
                string author = html.Substring(authorStart, authorLength);

                // Make full quote, replacing &#39 with apostrophe
                string fullQuote = ("'" + quote + "' - " + author).Replace("&#39;", "'");
               
                // Only return tweetable quotes
                if (fullQuote.Length <= MaxChars)
                    yield return fullQuote;

                // Move pointer to end of author
                pointer = authorEnd;
            }

        }

        // Create JSON
        public static string CreateJSON(IEnumerable<string> list)
        {
            string newJson = "";
            string startJson = "{\"text\":\"";
            string endJson = "\"},\n";

            // Create internal JSON string from list (ie, {"text":<QUOTE>},)
            foreach(string quote in list)
            {
                newJson += startJson + quote + endJson;
            }

            return newJson;
        }

        // Write to JSON
        public static void InsertJSON(string jsonToInsert)
        {
            // Read JSON from original file
            string path = "jsonTweets.json";
            string originalJson = File.ReadAllText(path);
            string firstChunk = "{ \"tweets\":[";
            string remainingChunk = "{" + originalJson.Substring(firstChunk.Length);

            // Insert new JSON
            string newJsonText = firstChunk + jsonToInsert + remainingChunk;

            // Save to file
            File.WriteAllText(path, newJsonText);

        }




    }
}
