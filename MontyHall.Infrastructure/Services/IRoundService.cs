using MontyHall.Core.Model;

namespace MontyHall.Infrastructure.Services
{
    public interface IRoundService
    {
        public TotalResult Execute(bool reselect, int attempts);
    }
}
