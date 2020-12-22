using System;
using System.Threading.Tasks;

namespace EasyConsoleNG
{
    public interface IAsyncOption
    {
        string Name { get; }
        Task Execute();
    }
}
