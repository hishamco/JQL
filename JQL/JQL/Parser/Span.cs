namespace JQL
{
    internal struct Span
    {
        internal static readonly Span Empty = new Span() { Start = 0, End = 0 };

        internal int Start { get; set; }

        internal int End { get; set; }
    }
}
