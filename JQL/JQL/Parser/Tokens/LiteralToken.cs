namespace JQL
{
    internal class LiteralToken : Token
    {
        private readonly object literal;

        internal object Literal { get { return literal; } }

        internal LiteralToken(TokenType type, Span span, object literal) : base(type, span)
        {
            this.literal = literal;
        }
    }
}
