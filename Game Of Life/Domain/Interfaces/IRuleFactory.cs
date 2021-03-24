using System.Collections.Generic;

namespace Game_Of_Life.Domain.Interfaces
{
    public interface IRuleFactory
    {
        public IEnumerable<ISurvivalCondition> GetRules();
    }
}