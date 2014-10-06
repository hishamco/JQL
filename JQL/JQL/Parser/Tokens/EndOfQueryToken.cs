namespace JQL
{
    internal sealed class EndOfQueryToken : Token
    {
        internal EndOfQueryToken(Span span) : base(TokenType.EndOfQuery, span)
        {
            
        }
    }
}
