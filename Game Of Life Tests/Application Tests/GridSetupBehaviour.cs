using Game_Of_Life.Application.Behaviours;
using Game_Of_Life.Application.Interfaces;
using Game_Of_Life.Domain;
using NUnit.Framework;

namespace Game_Of_Life_Tests.Application_Tests
{
    public class Board
    {
        private IGameSetup _gameSetupHandler;
        private static readonly object[] InitialGenerations = 
        {
            new [,]{{"o"}, {"x"}, {"o"}},  //case 1
            new [,]{{"o", "o", "o"}, {"x", "o", "x"}, {"o", "o", "o"}},  //case 2
            new [,]{{"o", "o", "o"}, {null, null, null}, {"o", "o", "o"}},   //case 3
            new [,]{{"o", "o", "o", "x"}, {"o", "o", "o", "x"}, {"o", "o", "i", ""}}   //case 4
        }; 
        
        [SetUp]
        public void Setup()
        { 
            _gameSetupHandler = new GameSetupHandler();
        }

        [TestCaseSource(nameof(InitialGenerations))]
        public void ShouldCreateAGridWithTheCorrectDimensions(string[,] initialGenerations)
        {
            var result = _gameSetupHandler.CreateInitialGrid(initialGenerations);

            Assert.AreEqual(initialGenerations.GetLength(0), result.Height);
            Assert.AreEqual(initialGenerations.GetLength(1), result.Width);
        }
        
        [TestCaseSource(nameof(InitialGenerations))]
        public void ShouldCreateAGridWithTheCorrectNumberOfCells(string[,] initialGenerations)
        {
            var expected = initialGenerations.GetLength(0) * initialGenerations.GetLength(1);
            var result = _gameSetupHandler.CreateInitialGrid(initialGenerations);
            
            Assert.AreEqual(expected, result.CellGrid.Length);
        }
        
        [Test]
        public void ShouldCreateAGridWithTheAccurateCellStatuses()
        {
            var initialGeneration = new[,] {{"o", "o", "o"}, {"x", "o", "x"}, {"o", "o", "o"}};
            var result = _gameSetupHandler.CreateInitialGrid(initialGeneration);

            Assert.AreEqual(CellStatus.Dead, result.CellGrid[0,0].CellStatus);
            Assert.AreEqual(CellStatus.Dead, result.CellGrid[1,0].CellStatus);
            Assert.AreEqual(CellStatus.Alive, result.CellGrid[0,1].CellStatus);
            Assert.AreEqual(CellStatus.Dead, result.CellGrid[2,1].CellStatus);
        }
    }
}