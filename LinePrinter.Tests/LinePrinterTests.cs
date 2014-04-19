using System.Linq;
using NUnit.Framework;

namespace LinePrinter.Tests
{
    [TestFixture]
    public class LinePrinterTests
    {
        [Test]
        public void SplitIntoLines_twoLinesWordsUnderCharLimit_Returns2Lines()
        {
            string input = "hello hi hello hi";
            int charLimit = 8;

            var result = new LineSplitter().SplitIntoLines(input, charLimit).ToArray();

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("hello hi", result[0]);

        }

        [Test]
        public void SplitIntoLines_oneWordUnderLimit_OneLine()
        {
            string input = "ab ab ac";
            int charLimit = 8;

            var result = new LineSplitter().SplitIntoLines(input, charLimit).ToArray();

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(input, result.First());
        }

        [Test]
        public void SplitIntoLines_lastWordExceedsCharLimit_CarriesOverToNewLine()
        {
            string input = "hello hello hello hi";
            int charLimit = 8;

            var result = new LineSplitter().SplitIntoLines(input, charLimit).ToArray();

            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("hello hi", result[2]);
        }

        [Test]
        public void SplitIntoLines_wordExceedsCharLimit_wordSplitRemainderCarriesOver()
        {
            string input = "hellohelloo";
            int charLimit = 8;

            var result = new LineSplitter().SplitIntoLines(input, charLimit).ToArray();

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("hellohel", result[0]);
            Assert.AreEqual("loo", result[1]);
        }

        [Test]
        public void SplitIntoLines_wordExceedsCharLimitByNTimes_RemaindersCarryOverToNewLines()
        {
            string input = "hellohelloo";
            int charLimit = 4;

            var result = new LineSplitter().SplitIntoLines(input, charLimit).ToArray();

            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("hell", result[0]);
            Assert.AreEqual("ohel", result[1]);
            Assert.AreEqual("loo", result[2]);
        }

        [Test]
        public void SplitIntoLines_lastWordOnLineLongerThenCharLimit_WordSplitIntoMultipleLines()
        {
            string input = "hello hhhhhhhhhhhhhhh he";
            int charLimit = 7;

            var result = new LineSplitter().SplitIntoLines(input, charLimit).ToArray();
            Assert.AreEqual(4, result.Length);
            Assert.AreEqual("hello", result.First());
            Assert.AreEqual("h he", result.Last());
        }

        [Test]
        public void SplitIntoLines_textContainsMultipleSpaces_spaceTreatedAsWord()
        {
            string input = "hello  hi hello";
            int charLimit = 5;

            var result = new LineSplitter().SplitIntoLines(input, charLimit).ToArray();

            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(" hi", result[1]);
        }

        [Test]
        public void SplitIntoLinesRecur_twoLinesWordsUnderCharLimit_Returns2Lines()
        {
            string input = "hello hi hello hi";
            int charLimit = 8;

            var result = new LineSplitter().SplitIntoLinesRecur(input, charLimit).ToArray();

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("hello hi", result[0]);

        }

        [Test]
        public void SplitIntoLinesRecur_lastWordExceedsCharLimit_CarriesOverToNewLine()
        {
            string input = "hello hello hello hi";
            int charLimit = 8;

            var result = new LineSplitter().SplitIntoLinesRecur(input, charLimit).ToArray();

            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("hello hi", result[2]);
        }

        [Test]
        public void SplitIntoLinesRecur_wordExceedsCharLimit_wordSplitRemainderCarriesOver()
        {
            string input = "hellohelloo";
            int charLimit = 8;

            var result = new LineSplitter().SplitIntoLines(input, charLimit).ToArray();

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("hellohel", result[0]);
            Assert.AreEqual("loo", result[1]);
        }

        [Test]
        public void SplitIntoLinesRecur_wordExceedsCharLimitByNTimes_RemaindersCarryOverToNewLines()
        {
            string input = "hellohelloo";
            int charLimit = 4;

            var result = new LineSplitter().SplitIntoLines(input, charLimit).ToArray();

            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("hell", result[0]);
            Assert.AreEqual("ohel", result[1]);
            Assert.AreEqual("loo", result[2]);
        }

        [Test]
        public void SplitIntoLinesRecur_lastWordOnLineLongerThenCharLimit_WordSplitIntoMultipleLines()
        {
            string input = "hello hhhhhhhhhhhhhhh he";
            int charLimit = 7;

            var result = new LineSplitter().SplitIntoLines(input, charLimit).ToArray();
            Assert.AreEqual(4, result.Length);
            Assert.AreEqual("hello", result.First());
            Assert.AreEqual("h he", result.Last());
        }

        [Test]
        public void SplitIntoLinesRecur_textContainsMultipleSpaces_spaceTreatedAsWord()
        {
            string input = "hello  hi hello";
            int charLimit = 5;

            var result = new LineSplitter().SplitIntoLines(input, charLimit).ToArray();

            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(" hi", result[1]);
        }

    }
}
