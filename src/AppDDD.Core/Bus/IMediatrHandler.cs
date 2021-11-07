using AppDDD.Core.Messages;
using System.Threading.Tasks;

namespace AppDDD.Core.Bus
{
    public interface IMediatrHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
    }
}