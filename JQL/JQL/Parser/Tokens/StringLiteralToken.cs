namespace JQL
{
    internal sealed class StringLiteralToken : LiteralToken
    {
        private readonly string literal;

        internal new string Literal { get { return literal; } }

        internal StringLiteralToken(Span span, string literal) : base(TokenType.StringLiteral, span, literal)
        {
            this.literal = literal;
        }
    }
}
