
namespace Entities.Exceptions
{
    public sealed class BadAgeRequestException : Exception
    {
        public BadAgeRequestException() : base("Max age can't be less than min age.")
        {

        }
    }
}
