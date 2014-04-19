using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinePrinter
{
    public class LineSplitter
    {
        public IEnumerable<string> SplitIntoLines(string text, int maxChars)
        {
            var wordTokens = text.Split(' ');

            List<string> remainingTokens = wordTokens.ToList();

            while (remainingTokens.Any())
            {
                yield return GetLine(remainingTokens.ToList(), maxChars, out remainingTokens);
            }
        }

        public IEnumerable<string> SplitIntoLinesRecur(string text, int maxChars)
        {
            var wordTokens = text.Split(' ');

            return GetLinesRecur(wordTokens.ToList(), maxChars);
        } 

        private string GetLine(List<string> wordTokens, int maxChars, out List<string> remainingTokens)
        {
            var lineWordTokens = GetLineWordTokens(wordTokens, maxChars, out remainingTokens);

            return CreateStringFrom(lineWordTokens);
        }

        private static IEnumerable<string> GetLinesRecur(List<string> wordTokens, int maxChars)
        {
            if (!wordTokens.Any()) return new List<string>();

            List<string> remainingTokens;

            var lineWordTokens = GetLineWordTokens(wordTokens, maxChars, out remainingTokens);

            var lines = new List<string> {CreateStringFrom(lineWordTokens)};

            lines.AddRange(GetLinesRecur(remainingTokens, maxChars));

            return lines;
        }

        private static IEnumerable<string> GetLineWordTokens(List<string> wordTokens, int maxChars, out List<string> remainingTokens)
        {
            int wordCount = 0;

            var lineWordTokens = wordTokens.TakeWhile(word =>
            {
                wordCount += word.Length + 1;
                return wordCount <= maxChars + 1;
            }).ToList();

            //handle word exceeds maxChars
            if (!lineWordTokens.Any())
            {
                string word = wordTokens.First();
                var partialToken = word.Substring(0, maxChars);
                lineWordTokens.Add(partialToken);
                remainingTokens = wordTokens.Skip(1).ToList();
                remainingTokens.Insert(0, word.Substring(maxChars));
            }
            else
            {
                remainingTokens = wordTokens.Skip(lineWordTokens.Count()).ToList();
            }

            return lineWordTokens;
        }

        private static string CreateStringFrom(IEnumerable<string> wordTokens)
        {
            var buffer = new StringBuilder();

            wordTokens.Aggregate(buffer, (stringBuilder, word) =>
            {
                stringBuilder.Append(word);
                stringBuilder.Append(' ');
                return stringBuilder;
            });

            buffer.Remove(buffer.Length - 1, 1);

            return buffer.ToString();
        }
    }
}
