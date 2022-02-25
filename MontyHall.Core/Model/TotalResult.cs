using System.Collections.Generic;
using System.Linq;

namespace MontyHall.Core.Model
{
    public class TotalResult
    {
        public ICollection<bool> Results { get; }

        public TotalResult()
        {
            Results = new List<bool>();
        }

        public override string ToString()
        {
            return $"Correct attempts = {Results.Count(x => x)} and incorrect attempts = {Results.Count(x => !x)}";
        }
    }
}
