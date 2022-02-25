using MontyHall.Core.Model;

namespace MontyHall.Infrastructure.Services
{
    public class RoundService : IRoundService
    {
        public TotalResult Execute(bool reselect, int attempts)
        {
            var res = new TotalResult();

            for (var i = 0; i < attempts; i++)
            {
                var round = new Round();
                round.Start();
                if (reselect)
                {
                    round.Reselect();
                }
                res.Results.Add(round.Finalize());
            }

            return res;
        }
    }
}
