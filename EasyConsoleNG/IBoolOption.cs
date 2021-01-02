namespace EasyConsoleNG
{
    public interface IBoolOption
    {
        bool MatchesFalse(string value);
        bool MatchesTrue(string value);
    }
}