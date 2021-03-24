using Game_Of_Life.Application.Behaviours.Setup;
using Game_Of_Life.Application.Enums;
using Game_Of_Life.Domain;
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
            var setupFactory = new GameSetupFactory(SetupType.Random);
            var ruleFactory = new ClassicRuleFactory();
            var gameController = new GameController(setupFactory,ruleFactory);
            var result = gameController.SetupGame();

            Assert.NotNull(result.CellGrid[0,5]);
        }
        
        [Test]
        public void ShouldReturnCorrectGridWithPathNameInput()
        {
            var inputPath = "/Users/mario.sinovcic/Documents/Acceleration/Katas/Game Of Life/Game Of Life/Game Of Life Tests/TestData/TestData1.json";
            var setupFactory = new GameSetupFactory(SetupType.PathName, inputPath);
            var ruleFactory = new ClassicRuleFactory();
            var gameController = new GameController(setupFactory,ruleFactory);
            var result = gameController.SetupGame();
            
            Assert.AreEqual(result.CellGrid[0,0].CellStatus, CellStatus.Alive);
            Assert.AreEqual(result.CellGrid[0,1].CellStatus, CellStatus.Dead);
        }
        
        [Test]
        public void ShouldReturnCorrectNewGridGeneration()
        {
            var initialGeneration = new[,] {{"o", "o", "o"}, {"o", "x", "o"}, {"o", "o", "o"}};
            var setupFactory = new GameSetupFactory(SetupType.PathName, initialGeneration);
            var ruleFactory = new ClassicRuleFactory();
            var gameController = new GameController(setupFactory,ruleFactory);
            var grid = gameController.SetupGame();
            var result = gameController.IterateGame(grid);

            Assert.AreEqual(result.CellGrid[1,1].CellStatus, CellStatus.Dead);
        }
    }
}