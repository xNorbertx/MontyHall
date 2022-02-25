using MontyHall.Infrastructure.Services;
using System.Linq;
using Xunit;

namespace MontyHall.Tests
{
    //test that reselect provides a 1/2 chance of guesses correctly whereas no reselect provides a 1/3 chance 
    public class ExecutionTests
    {
        private readonly int Attempts = 100000;
        private readonly IRoundService RoundService;

        public ExecutionTests()
        {
            RoundService = new RoundService();
        }

        [Theory]
        [InlineData(true, 0.5)]
        [InlineData(false, 0.333333)]
        public void TestRoundService(bool reselect, decimal chance)
        {
            var res = RoundService.Execute(reselect, Attempts);

            //base upper and lower range on 1/100th of total attempts (need to check if that is statistically correct)
            var upperRange = (Attempts * chance) + (Attempts / 100);
            var lowerRange = (Attempts * chance) - (Attempts / 100);

            //try this 10 times
            for (var i = 0; i < 10; i++)
            {
                Assert.InRange(res.Results.Count(x => x), lowerRange, upperRange);
            }
        }
    }
}
