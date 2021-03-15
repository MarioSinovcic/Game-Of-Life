using Game_Of_Life.Application.Behaviours;
using Game_Of_Life.Application.Interfaces;
using Game_Of_Life.Domain;
using NUnit.Framework;

namespace Game_Of_Life_Tests.Application_Tests
{
    public class GridSetupBehaviour
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

            Assert.AreEqual(initialGenerations.GetLength(0), result.Width);
            Assert.AreEqual(initialGenerations.GetLength(1), result.Height);
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
            Assert.AreEqual(CellStatus.Alive, result.CellGrid[1,0].CellStatus);
            Assert.AreEqual(CellStatus.Dead, result.CellGrid[0,1].CellStatus);
            Assert.AreEqual(CellStatus.Alive, result.CellGrid[1,2].CellStatus);
            Assert.AreEqual(CellStatus.Dead, result.CellGrid[2,1].CellStatus);
        }
        
        [Test]
        public void ShouldCreateAGridWithTheAccurateCellStatusesOnUnevenYAxisBoard()
        {
            var initialGeneration = new[,] {{"o", "o", "o", "x"}, {"o", "o", "o", "o"}, {"x", "o", "x", "o"}};
            var result = _gameSetupHandler.CreateInitialGrid(initialGeneration);

            Assert.AreEqual(CellStatus.Alive, result.CellGrid[0,3].CellStatus);
            Assert.AreEqual(CellStatus.Dead, result.CellGrid[1,0].CellStatus);
            Assert.AreEqual(CellStatus.Dead, result.CellGrid[0,2].CellStatus);
            Assert.AreEqual(CellStatus.Alive, result.CellGrid[2,2].CellStatus);
            Assert.AreEqual(CellStatus.Alive, result.CellGrid[2,0].CellStatus);
        }
        
        [Test]
        public void ShouldCreateAGridWithTheAccurateCellStatusesOnUnevenXAxisBoard()
        {
            var initialGeneration = new[,] {{"o", "o"}, {"o", "o"}, {"x", "o"}, {"o", "o"}, {"o", "x"}};
            var result = _gameSetupHandler.CreateInitialGrid(initialGeneration);

            Assert.AreEqual(CellStatus.Dead, result.CellGrid[0,1].CellStatus);
            Assert.AreEqual(CellStatus.Dead, result.CellGrid[1,0].CellStatus);
            Assert.AreEqual(CellStatus.Alive, result.CellGrid[2,0].CellStatus);
            Assert.AreEqual(CellStatus.Dead, result.CellGrid[3,1].CellStatus);
            Assert.AreEqual(CellStatus.Alive, result.CellGrid[4,1].CellStatus);
        }
    }
}