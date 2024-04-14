using System.Diagnostics;

namespace GlobalExceptionHandling.Services
{
    public interface ICustomException
    {
        Task<bool> GetData();
    }
}
