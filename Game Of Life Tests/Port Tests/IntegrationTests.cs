using Game_Of_Life.Application.Behaviours.Setup;
using Game_Of_Life.Domain;
using Game_Of_Life.Domain.Enums;
using Game_Of_Life.Port;
using NUnit.Framework;

namespace Game_Of_Life_Tests.Port_Tests
{
    public class IntegrationTests
    {
        private GameController _gameController;

        [SetUp]
        public void Setup()
        { 
            var gameRules =  new ClassicRuleFactory();
            var gameSetup =  new GameSetupFactory();
            _gameController = new GameController(gameSetup, gameRules);
        }
        
        [Test]
        public void ShouldReturnRandomGridWithNullInput()
        {
            var result = _gameController.SetupGame(null);

            Assert.NotNull(result.CellGrid[0,5]);
        }
        
        [Test]
        public void ShouldReturnCorrectGridWithPathNameInput()
        {
            var inputPaths = new[] {"/Users/mario.sinovcic/Documents/Acceleration/Katas/Game Of Life/Game Of Life/Game Of Life Tests/TestData/TestData1.json"};
            var result = _gameController.SetupGame(inputPaths);

            Assert.AreEqual(result.CellGrid[0,0].CellStatus, CellStatus.Alive);
            Assert.AreEqual(result.CellGrid[0,1].CellStatus, CellStatus.Dead);
        }
        
        [Test]
        public void ShouldReturnCorrectNewGridGeneration()
        {
            var initialGeneration = new[,] {{"o", "o", "o"}, {"o", "x", "o"}, {"o", "o", "o"}};
            var _gameSetupHandler = new StringArrayGameSetupHandler();
            var grid = _gameSetupHandler.CreateInitialGrid(initialGeneration);
            
            var result = _gameController.IterateGame(grid);

            Assert.AreEqual(result.CellGrid[1,1].CellStatus, CellStatus.Dead);
        }
    }
}