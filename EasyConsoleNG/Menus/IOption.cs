namespace EasyConsoleNG.Menus
{
    public interface IOption
    {
        string Name { get; }
        void Execute();
    }
}
