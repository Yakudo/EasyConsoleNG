namespace EasyConsoleNG
{
    public interface IOption
    {
        string Name { get; }
        void Execute();
    }
}
