using Game_Of_Life.Application.Behaviours;
using Game_Of_Life.Application.Interfaces;
using Game_Of_Life.Domain;
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
            _generationUpdater = new GenerationUpdater();
            _gameSetupHandler = new GameSetupHandler();
        }
        
        [Test]
        public void ShouldKillLiveCellWithFourNeighbours()
        {
            var initialGeneration = new[,] {{"o", "x", "o"}, {"o", "x", "x"}, {"x", "x", "x"}};
            var grid = _gameSetupHandler.CreateInitialGrid(initialGeneration);
            var result = _generationUpdater.CreateNewGeneration(grid);
            
            Assert.AreEqual(CellStatus.Dead, result.CellGrid[0,1].CellStatus);
        }
        
        [Test]
        public void ShouldKillLiveCellWithDirectNeighbours()
        {
            var initialGeneration = new[,] {{"o", "x", "o"}, {"x", "x", "x"}, {"o", "x", "o"}};
            var grid = _gameSetupHandler.CreateInitialGrid(initialGeneration);
            var result = _generationUpdater.CreateNewGeneration(grid);
            
            Assert.AreEqual(CellStatus.Dead, result.CellGrid[1,1].CellStatus);
        }
        
        [Test]
        public void ShouldNotKillLiveCellWithThreeNeighbours()
        {
            var initialGeneration = new[,] {{"x", "x", "o"}, {"o", "o", "x"}, {"o", "x", "o"}};
            var grid = _gameSetupHandler.CreateInitialGrid(initialGeneration);
            var result = _generationUpdater.CreateNewGeneration(grid);
            
            Assert.AreEqual(CellStatus.Alive, result.CellGrid[0,1].CellStatus);
        }
        
        [Test]
        public void ShouldNotKillLiveCellWithTwoNeighbours()
        {
            var initialGeneration = new[,] {{"o", "x", "o"}, {"o", "o", "x"}, {"o", "x", "o"}};
            var grid = _gameSetupHandler.CreateInitialGrid(initialGeneration);
            var result = _generationUpdater.CreateNewGeneration(grid);
            
            Assert.AreEqual(CellStatus.Alive, result.CellGrid[2,1].CellStatus);
        }

        [Test] 
        public void ShouldNotKillCorrectCellsOverMultipleGenerations()
        {
            var initialGeneration = new[,] {{"x", "o", "x", "o"}, {"o", "x", "x", "o"}, {"o", "o", "o", "o"}};
            var grid = _gameSetupHandler.CreateInitialGrid(initialGeneration);
            var firstGen = _generationUpdater.CreateNewGeneration(grid);
            var result = _generationUpdater.CreateNewGeneration(firstGen);
            
            Assert.AreEqual(CellStatus.Dead, result.CellGrid[0,0].CellStatus);
            Assert.AreEqual(CellStatus.Alive, result.CellGrid[0,2].CellStatus);
            Assert.AreEqual(CellStatus.Alive, result.CellGrid[1,1].CellStatus);
            Assert.AreEqual(CellStatus.Alive, result.CellGrid[1,2].CellStatus);
        }
    }
}