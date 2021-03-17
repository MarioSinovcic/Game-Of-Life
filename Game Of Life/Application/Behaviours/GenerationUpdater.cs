using System.Linq;
using Game_Of_Life.Domain;
using Game_Of_Life.Domain.Interfaces;

namespace Game_Of_Life.Application.Behaviours
{
    public class GenerationUpdater
    {
        private readonly IRuleFactory _ruleFactory; //should be injected

        public GenerationUpdater(IRuleFactory ruleFactory)
        {
            _ruleFactory = ruleFactory;
        }

        public Grid CreateNewGeneration(Grid grid)
        {
            var newGeneration = new Grid(grid.Height, grid.Width);

            for (var i = 0; i < grid.Width; i++)
            {
                for (var j = 0; j < grid.Height; j++)
                {
                    newGeneration.CellGrid[j, i].CellStatus = EvaluateRules(grid, j, i);
                    //newGeneration.CellGrid[j, i].CellStatus = CheckUnderpopulationRule(grid, j, i);
                }
            }
            return newGeneration;
        }

        private CellStatus EvaluateRules(Grid grid, int y, int x)
        {
            var rules = _ruleFactory.GetRules();

            if (rules.Any(rule => rule.EvaluateRule(grid, y, x)))
            {
                return grid.CellGrid[y, x].FlippedCellStatus();
            }
            return grid.CellGrid[y, x].CellStatus;
        }
    }
}