using System;
using System.Threading.Tasks;

namespace EasyConsoleNG.Menus
{
    public interface IAsyncOption
    {
        string Name { get; }
        Task Execute();
    }
}
