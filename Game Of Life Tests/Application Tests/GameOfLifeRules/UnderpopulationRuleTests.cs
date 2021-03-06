using Game_Of_Life.Application.Behaviours;
using Game_Of_Life.Application.Behaviours.Setup;
using Game_Of_Life.Application.Interfaces;
using Game_Of_Life.Domain.Enums;
using Game_Of_Life.Domain.GameRules;
using NUnit.Framework;

namespace Game_Of_Life_Tests.Application_Tests.GameOfLifeRules
{
    public class UnderpopulationRuleTests
    {
        private GenerationUpdater _generationUpdater;
        private IGameSetup _gameSetupHandler;

        [SetUp]
        public void Setup()
        { 
            var classicRuleFactory = new ClassicRuleFactory();
            _generationUpdater = new GenerationUpdater(classicRuleFactory.GetRules());
        }
        
        [Test]
        public void ShouldKillSingleLiveCellInMiddle()
        {
            var initialGeneration = new[,] {{"o", "o", "o"}, {"o", "x", "o"}, {"o", "o", "o"}};
            _gameSetupHandler = new StringArrayGameSetupHandler(initialGeneration);
            var grid = _gameSetupHandler.CreateInitialGrid();
            var result = _generationUpdater.CreateNewGeneration(grid);

            Assert.AreEqual(CellStatus.Dead, result.CellGrid[0,1].CellStatus);
            Assert.AreEqual(CellStatus.Dead, result.CellGrid[1,1].CellStatus);
        }
        
        [Test]
        public void ShouldKillSingleLiveCellOnEdge()
        {
            var initialGeneration = new[,] {{"o", "o", "o"}, {"o", "o", "o"}, {"o", "o", "x"}};
            _gameSetupHandler = new StringArrayGameSetupHandler(initialGeneration);
            var grid = _gameSetupHandler.CreateInitialGrid();
            var result = _generationUpdater.CreateNewGeneration(grid);

            Assert.AreEqual(CellStatus.Dead, result.CellGrid[0,0].CellStatus);
            Assert.AreEqual(CellStatus.Dead, result.CellGrid[2,2].CellStatus);
        }
        
        [Test]
        public void ShouldKillSingleLiveCellOnLargeBoard()
        {
            var initialGeneration = new[,] {{"x", "x", "o", "o", "o"}, {"o", "o", "o", "o", "o"}, {"x", "o", "o", "o", "x"}};
            _gameSetupHandler = new StringArrayGameSetupHandler(initialGeneration);
            var grid = _gameSetupHandler.CreateInitialGrid();
            var result = _generationUpdater.CreateNewGeneration(grid);

            Assert.AreEqual(CellStatus.Dead, result.CellGrid[1,3].CellStatus);
            Assert.AreEqual(CellStatus.Dead, result.CellGrid[1,2].CellStatus);
        }
        
        [Test]
        public void ShouldKillSingleLiveCellOnTheEdgeOfALargeBoard()
        {
            var initialGeneration = new[,] {{"o", "o", "o", "o", "o"}, {"o", "o", "o", "o", "o"}, {"o", "o", "o", "o", "x"}};
            _gameSetupHandler = new StringArrayGameSetupHandler(initialGeneration);
            var grid = _gameSetupHandler.CreateInitialGrid();
            var result = _generationUpdater.CreateNewGeneration(grid);

            Assert.AreEqual(CellStatus.Dead, result.CellGrid[2,2].CellStatus);
            Assert.AreEqual(CellStatus.Dead, result.CellGrid[2,4].CellStatus);
        }
    }
}