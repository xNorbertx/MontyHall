using System;
using System.Collections.Generic;
using System.Linq;

namespace MontyHall.Core.Helpers
{
    public static class RandomExtensions
    {
        public static int NextExcept(this Random random, int maxValue, List<int> exclude)
        {
            var include = new List<int>();
            for (var i = 0; i < maxValue; i++)
            {
                if (!exclude.Contains(i))
                {
                    include.Add(i);
                }
            }

            if (include.Count == 0)
            {
                throw new ArgumentException($"No available random number between 0 and {maxValue} that is not in the excluded array");
            }

            var index = random.Next(include.Count);

            return include.ElementAt(index);            
        }
    }
}
