using System.Collections.Generic;
using System.Linq;
using Game_Of_Life.Domain.Interfaces;

namespace Game_Of_Life.Domain.GameRules
{
    public class ClassicRuleFactory : IRuleFactory
    {
        private IEnumerable<IRule> _rules;
        
        public ClassicRuleFactory()
        {
            _rules = Enumerable.Empty<IRule>();
            PopulateRulesList();
        }

        public IEnumerable<IRule> GetRules()
        {
            return _rules;
        }

        private void PopulateRulesList()
        {
            var overPopulationRule = new OverpopulationRule();
            var underpopulationRule = new UnderpopulationRule();
            var revivalRule = new RevivalRule();
            _rules = new List<IRule>{overPopulationRule, underpopulationRule, revivalRule};
        }
    }
}