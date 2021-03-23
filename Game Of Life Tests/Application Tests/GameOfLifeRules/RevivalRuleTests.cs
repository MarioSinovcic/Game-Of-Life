using Game_Of_Life.Application.Behaviours;
using Game_Of_Life.Application.Behaviours.Setup;
using Game_Of_Life.Application.Interfaces;
using Game_Of_Life.Domain;
using Game_Of_Life.Domain.Enums;
using Game_Of_Life.Domain.GameRules;
using NUnit.Framework;

namespace Game_Of_Life_Tests.Application_Tests.GameOfLifeRules
{
    public class RevivalRuleTests
    {
        private GenerationUpdater _generationUpdater;
        private IGameSetup _gameSetupHandler;

        [SetUp]
        public void Setup()
        { 
            var classicRuleFactory = new ClassicRuleFactory();
            _generationUpdater = new GenerationUpdater(classicRuleFactory);
            _gameSetupHandler = new StringArrayGameSetupHandler();
        }

        [Test]
        public void ShouldReviveSingleLiveCellWithThreeNeighbours()
        {
            var initialGeneration = new[,] {{"x", "o", "o"}, {"o", "x", "o"}, {"x", "o", "o"}};
            var grid = _gameSetupHandler.CreateInitialGrid(initialGeneration);
            var result = _generationUpdater.CreateNewGeneration(grid);

            Assert.AreEqual(CellStatus.Alive, result.CellGrid[1, 0].CellStatus);
        }
        
        [Test]
        public void ShouldReviveSingleLiveCellWithThreeNeighboursOnTheEdge()
        {
            var initialGeneration = new[,] {{"o", "x", "o"}, {"o", "o", "o"}, {"x", "o", "x"}};
            var grid = _gameSetupHandler.CreateInitialGrid(initialGeneration);
            var result = _generationUpdater.CreateNewGeneration(grid);

            Assert.AreEqual(CellStatus.Alive, result.CellGrid[2, 1].CellStatus);
        }
        
        [Test]
        public void ShouldNotReviveSingleLiveCellWithTwoNeighboursOnTheEdge()
        {
            var initialGeneration = new[,] {{"o", "x", "o"}, {"o", "o", "o"}, {"o", "o", "x"}};
            var grid = _gameSetupHandler.CreateInitialGrid(initialGeneration);
            var result = _generationUpdater.CreateNewGeneration(grid);

            Assert.AreEqual(CellStatus.Dead, result.CellGrid[2, 1].CellStatus);
        }
        
        [Test]
        public void ShouldNotReviveSingleLiveCellWithFourNeighboursOnTheEdge()
        {
            var initialGeneration = new[,] {{"o", "x", "x"}, {"o", "o", "o"}, {"x", "o", "x"}};
            var grid = _gameSetupHandler.CreateInitialGrid(initialGeneration);
            var result = _generationUpdater.CreateNewGeneration(grid);

            Assert.AreEqual(CellStatus.Dead, result.CellGrid[2, 1].CellStatus);
        }
    }
}