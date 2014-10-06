using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JQL
{
    internal sealed class Lexer : IDisposable
    {
        private readonly string query;
        private readonly StringReader reader;
        private int column;
        private const char EOQ = (char)65535;
        private const string ValidCharacters = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ[]:,\"";
        private readonly List<Token> tokens;

        private char LookAhead
        {
            get { return (char)reader.Peek(); }
        }

        internal IEnumerable<Token> Tokens
        {
            get
            {
                return tokens;
            }
        }

        internal Lexer(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentNullException("query");
            this.query = query;
            reader = new StringReader(query);
            tokens = new List<Token>();
            column = 1;
        }

        private char ReadChar()
        {
            ++column;
            return (char)reader.Read();
        }

        internal void Scan()
        {
            while (LookAhead != EOQ)
            {
                int start = column;
                if (Char.IsLetter(LookAhead))
                {
                    string name = ReadIdentifier();
                    tokens.Add(new IdentifierToken(SpanFrom(start), name));
                }
                else if (Char.IsDigit(LookAhead))
                {
                    int number = ReadNumber();
                    tokens.Add(new NumberLiteralToken(SpanFrom(start), number));
                }
                else
                    switch (LookAhead)
                    {
                        case '"':
                            string @string = ReadString();
                            tokens.Add(new StringLiteralToken(SpanFrom(start), @string));
                            break;
                        case ']':
                        case '[':
                        case ':':
                        case ',':
                            char punctuator = LookAhead;
                            ReadChar();
                            tokens.Add(new PunctuatorToken(SpanFrom(start), punctuator));
                            break;
                        case ' ':
                        case '\t':
                            SkipWhiteSpace();
                            break;
                        default:
                            throw new InvalidTokenException(string.Format("The token '{0}' is invalid.", ReadUnknown()));
                    }
            }
            tokens.Add(new EndOfQueryToken(Span.Empty));
        }

        private string ReadUnknown()
        {
            StringBuilder lexem = new StringBuilder();
            do
            {
                lexem.Append(ReadChar());
            } while (ValidCharacters.Contains(LookAhead) == false);
            return lexem.ToString();
        }

        private string ReadIdentifier()
        {
            StringBuilder lexem = new StringBuilder();
            do
            {
                lexem.Append(ReadChar());
            }
            while (Char.IsLetterOrDigit(LookAhead));
            return lexem.ToString();
        }
        private int ReadNumber()
        {
            StringBuilder lexem = new StringBuilder();
            do
            {
                lexem.Append(ReadChar());
            } while (Char.IsDigit(LookAhead));
            return Convert.ToInt32(lexem.ToString());
        }

        private string ReadString()
        {
            StringBuilder lexem = new StringBuilder();
            ReadChar();
            do
            {
                lexem.Append(ReadChar());
            } while (LookAhead != '"');
            return lexem.ToString();
        }

        private void SkipWhiteSpace()
        {
            do
            {
                ReadChar();
            } while (Char.IsWhiteSpace(LookAhead));
        }

        private Span SpanFrom(int start)
        {
            return new Span() { Start = start, End = column - 1 };
        }

        public void Dispose()
        {
            reader.Dispose();
        }
    }
}