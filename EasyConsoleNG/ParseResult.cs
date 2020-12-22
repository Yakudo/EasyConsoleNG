namespace EasyConsoleNG
{
    public struct ParseResult<T>
    {
        public string Error { get; }
        public T Value { get; }

        public ParseResult(string error, T value = default) : this()
        {
            Error = error;
            Value = value;
        }
    }

    public static class ParseResult
    { 
        public static ParseResult<T> AsSuccess<T>(T value)
        {
            return new ParseResult<T>(null, value);
        }

        public static ParseResult<T> AsError<T>(string error)
        {
            return new ParseResult<T>(error);
        }
    }
}
