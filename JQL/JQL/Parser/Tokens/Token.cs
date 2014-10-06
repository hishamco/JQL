namespace JQL
{
    internal abstract class Token
    {
        private readonly TokenType type;
        private readonly Span span;

        internal TokenType Type { get { return type; } }
        internal Span Span { get { return span; } }

        internal Token(TokenType type, Span span)
        {
            this.type = type;
            this.span = span;
        }
    }
}
