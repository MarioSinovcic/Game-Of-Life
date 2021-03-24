using System.Collections.Generic;
using System.Linq;
using Game_Of_Life.Domain.Interfaces;

namespace Game_Of_Life.Domain.GameRules
{
    public class ClassicRuleFactory : IRuleFactory
    {
        private IEnumerable<ISurvivalCondition> _rules;
        
        public ClassicRuleFactory()
        {
            _rules = Enumerable.Empty<ISurvivalCondition>();
            PopulateRulesList();
        }

        public IEnumerable<ISurvivalCondition> GetRules()
        {
            return _rules;
        }

        private void PopulateRulesList()
        {
            var overPopulationRule = new OverpopulationSurvivalCondition();
            var underpopulationRule = new UnderpopulationSurvivalCondition();
            var revivalRule = new RevivalSurvivalCondition();
            _rules = new List<ISurvivalCondition>{overPopulationRule, underpopulationRule, revivalRule};
        }
    }
}