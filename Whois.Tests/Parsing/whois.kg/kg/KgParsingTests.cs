using NUnit.Framework;
using Whois.Models;
using Whois.Parsers;

namespace Whois.Parsing.Whois.Kg.Kg
{
    [TestFixture]
    public class KgParsingTests : ParsingTests
    {
        private WhoisParser parser;

        [SetUp]
        public void SetUp()
        {
            SerilogConfig.Init();

            parser = new WhoisParser();
        }

        [Test]
        public void Test_not_found()
        {
            var sample = SampleReader.Read("whois.kg", "kg", "not_found.txt");
            var response = parser.Parse("whois.kg", "kg", sample);

            Assert.Greater(sample.Length, 0);
            Assert.AreEqual(WhoisResponseStatus.NotFound, response.Status);
        }

        [Test]
        public void Test_found()
        {
            var sample = SampleReader.Read("whois.kg", "kg", "found.txt");
            var response = parser.Parse("whois.kg", "kg", sample);

            Assert.Greater(sample.Length, 0);
            Assert.AreEqual(WhoisResponseStatus.Found, response.Status);
        }
    }
}
