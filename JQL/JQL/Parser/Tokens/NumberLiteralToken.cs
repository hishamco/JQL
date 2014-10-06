namespace JQL
{
    internal sealed class NumberLiteralToken : LiteralToken
    {
        private readonly int literal;

        internal new int Literal { get { return literal; } }

        internal NumberLiteralToken(Span span, int literal) : base(TokenType.NumberLiteral, span,literal)
        {
            this.literal = literal;
        }
    }
}
