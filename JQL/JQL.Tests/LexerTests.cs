using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
namespace JQL.Tests
{

    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        public void GetTokensNumber()
        {
            int tokensNo;
            using (var scanner = new Lexer("Categories[]"))
            {
                scanner.Scan();
                tokensNo = scanner.Tokens.Count();
            }
            Assert.AreEqual(4, tokensNo);
        }

        [TestMethod]
        public void GetTokenSpan()
        {
            Token token;
            using (var scanner = new Lexer("Categories[]"))
            {
                scanner.Scan();
                token = scanner.Tokens.First();
            }
            Assert.AreEqual(new Span() { Start = 1, End = 10 }, token.Span);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidTokenException))]
        public void InvalidToken()
        {
            using (var scanner = new Lexer("Categories[#id]"))
            {
                scanner.Scan();
            }
        }
    }
}