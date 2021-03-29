using Game_Of_Life.Application.Behaviours.Setup;
using Game_Of_Life.Application.Enums;
using Game_Of_Life.Domain.Enums;
using Game_Of_Life.Domain.GameRules;
using Game_Of_Life.Port;
using NUnit.Framework;

namespace Game_Of_Life_Tests.Port_Tests
{
    public class IntegrationTests
    {

        [Test]
        public void ShouldReturnRandomGridWithNullInput()
        {
            var ruleFactory = new ClassicRuleFactory();
            var gameController = new GameController(ruleFactory);
            var result = gameController.SetupGame();

            Assert.NotNull(result.CellGrid[0,5]);
        }

        [Test]
        public void ShouldReturnCorrectNewGridGeneration()
        {
            var initialGeneration = new[,] {{"o", "o", "o"}, {"o", "x", "o"}, {"o", "o", "o"}};
            var grid = GameSetupFactory.CreateGridFromArray(SetupType.StringInput, initialGeneration);
            var ruleFactory = new ClassicRuleFactory();
            var gameController = new GameController(ruleFactory);
            var result = gameController.IterateGame(grid);

            Assert.AreEqual(result.CellGrid[1,1].CellStatus, CellStatus.Dead);
        }
        
        //TODO: create tests for new controller style (errors, etc.)
    }
}