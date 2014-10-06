namespace JQL
{
    internal sealed class IdentifierToken : Token
    {
        private readonly string name;

        internal string Name { get { return name; } }
        internal IdentifierToken(Span span,string name) : base(TokenType.Identifier, span)
        {
            this.name = name;
        }
    }
}
