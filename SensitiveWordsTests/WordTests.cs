

namespace SensitiveWordsTests
{
    public class Tests
    {

        [Test]
        public void WhenMessageHasBadWords_WordsAreMasked()
        {
            //SELECT * FROM, BY and Tables should be masked 
            string expected = "************* BOB*******s";
            IWordService dummyWordService = new DummyWordService();
            WordMasker wordMasker = new WordMasker(dummyWordService);
            string actual = wordMasker.Mask("SELECT * FROM BOBBYTables").Result;
            Assert.That(actual, Is.EqualTo(expected));
            Assert.Pass();
        }
    }
}