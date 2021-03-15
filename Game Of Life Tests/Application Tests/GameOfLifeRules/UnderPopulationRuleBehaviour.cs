using Game_Of_Life.Application.Behaviours;
using Game_Of_Life.Application.Interfaces;
using Game_Of_Life.Domain;
using NUnit.Framework;

namespace Game_Of_Life_Tests.Application_Tests
{
    public class GameOfLifeRuleBehaviour
    {
        private GenerationUpdater _generationUpdater;
        private IGameSetup _gameSetupHandler;
        
        private static readonly object[] InitialGenerations = 
        {
            new [,]{{"o"}, {"x"}, {"o"}},  //case 1
            new [,]{{"o", "o", "o"}, {"o", "o", "x"}, {"o", "o", "o"}},  //case 2
            new [,]{{"o", "o", "o"}, {"o", "x","o"}, {"o", "o", "o"}},   //case 3
            new [,]{{"o", "o", "o", "o"}, {"o", "o", "o", "o"}, {"o", "o", "o", "o"}}   //case 4
        }; 

        [SetUp]
        public void Setup()
        { 
            _generationUpdater = new GenerationUpdater();
            _gameSetupHandler = new GameSetupHandler();
        }
        
        [Test]
        public void ShouldKillSingleLiveCell()
        {
            var initialGeneration = new[,] {{"o", "o", "o"}, {"o", "x", "o"}, {"o", "o", "o"}};
            var grid = _gameSetupHandler.CreateInitialGrid(initialGeneration);
            var result = _generationUpdater.CreateNewGeneration(grid);

            Assert.AreEqual(CellStatus.Dead, result.CellGrid[1,1].CellStatus);
        }
        
        [Test]
        public void ShouldKillSingleLiveCell2()
        {
            var initialGeneration = new[,] {{"o", "o", "o"}, {"o", "o", "o"}, {"o", "o", "x"}};
            var grid = _gameSetupHandler.CreateInitialGrid(initialGeneration);
            var result = _generationUpdater.CreateNewGeneration(grid);

            Assert.AreEqual(CellStatus.Dead, result.CellGrid[0,0].CellStatus);
            Assert.AreEqual(CellStatus.Dead, result.CellGrid[2,2].CellStatus);
        }
    }
}