using System;
using System.Collections.Generic;

namespace JQL
{
    internal sealed class PunctuatorToken : Token
    {
        private static readonly Dictionary<char, TokenType> PunctuatorTable = new Dictionary<char, TokenType>()
        {
            {'[', TokenType.LeftBracket},
            {']', TokenType.RightBracket},
            {':', TokenType.Colon},
            {',', TokenType.Comma}
        };

        internal PunctuatorToken(Span span, char c) : base(GetTokenType(c), span)
        {

        }

        private static TokenType GetTokenType(char c)
        {
            if (PunctuatorTable.ContainsKey(c) == false)
                throw new ArgumentOutOfRangeException("c");
            return PunctuatorTable[c];
        }
    }
}
