using System;

namespace JQL
{
    internal sealed class Parser :IDisposable
    {
        private readonly Lexer lexer;


        public Parser(Lexer lexer)
        {
            this.lexer = lexer;
        }

        private Token ReadToken()
        {
            var enumerator = lexer.Tokens.GetEnumerator();
            enumerator.MoveNext();
            return enumerator.Current;
        }

        internal void Parse()
        {
            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
