using System;
using System.Threading.Tasks;

namespace HelloWorld.Interfaces
{
    public interface IApiReader
    {
        void SetClient(Uri uriAddress);
        Task<string> GetMessage(int index);
    }
}
