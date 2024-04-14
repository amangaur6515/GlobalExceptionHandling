
namespace GlobalExceptionHandling.Services
{
    public class CustomException : ICustomException
    {
        public async Task<bool> GetData()
        {
            throw new Exception("exception raised");
            return true;
        }
    }
}
