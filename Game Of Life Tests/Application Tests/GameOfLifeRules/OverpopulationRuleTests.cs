using Game_Of_Life.Application.Behaviours;
using Game_Of_Life.Application.Behaviours.Setup;
using Game_Of_Life.Application.Interfaces;
using Game_Of_Life.Domain.Enums;
using Game_Of_Life.Domain.GameRules;
using NUnit.Framework;

namespace Game_Of_Life_Tests.Application_Tests.GameOfLifeRules
{
    public class OverpopulationRuleTests
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
        public void ShouldKillLiveCellWithFourNeighbours()
        {
            var initialGeneration = new[,] {{"o", "x", "o"}, {"o", "x", "x"}, {"x", "x", "x"}};
            _gameSetupHandler = new StringArrayGameSetupHandler(initialGeneration);
            var grid = _gameSetupHandler.CreateInitialGrid();
            var result = _generationUpdater.CreateNewGeneration(grid);
            
            Assert.AreEqual(CellStatus.Dead, result.CellGrid[0,1].CellStatus);
        }
        
        [Test]
        public void ShouldKillLiveCellWithDirectNeighbours()
        {
            var initialGeneration = new[,] {{"o", "x", "o"}, {"x", "x", "x"}, {"o", "x", "o"}};
            _gameSetupHandler = new StringArrayGameSetupHandler(initialGeneration);
            var grid = _gameSetupHandler.CreateInitialGrid();
            var result = _generationUpdater.CreateNewGeneration(grid);
            
            Assert.AreEqual(CellStatus.Dead, result.CellGrid[1,1].CellStatus);
        }
        
        [Test]
        public void ShouldNotKillLiveCellWithThreeNeighbours()
        {
            var initialGeneration = new[,] {{"x", "x", "o"}, {"o", "o", "x"}, {"o", "x", "o"}};
            _gameSetupHandler = new StringArrayGameSetupHandler(initialGeneration);
            var grid = _gameSetupHandler.CreateInitialGrid();
            var result = _generationUpdater.CreateNewGeneration(grid);
            
            Assert.AreEqual(CellStatus.Alive, result.CellGrid[0,1].CellStatus);
        }
        
        [Test]
        public void ShouldNotKillLiveCellWithTwoNeighbours()
        {
            var initialGeneration = new[,] {{"o", "x", "o"}, {"o", "o", "x"}, {"o", "x", "o"}};
            _gameSetupHandler = new StringArrayGameSetupHandler(initialGeneration);
            var grid = _gameSetupHandler.CreateInitialGrid();
            var result = _generationUpdater.CreateNewGeneration(grid);
            
            Assert.AreEqual(CellStatus.Alive, result.CellGrid[2,1].CellStatus);
        }
    }
}