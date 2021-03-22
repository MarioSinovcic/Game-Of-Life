using Game_Of_Life.Application.Behaviours.Setup;
using Game_Of_Life.Domain.Enums;
using NUnit.Framework;

namespace Game_Of_Life_Tests.Application_Tests
{
    public class AlternateGridSetupTests 
    {
        private GameSetupFactory _gameSetupFactory;

        [SetUp]
        public void Setup()
        { 
            _gameSetupFactory = new GameSetupFactory(); 
        }

        [Test]
        public void ShouldCreateRandomGridIfNullInputIsGiven()
        {
            var result = _gameSetupFactory.GenerateInitialGrid(null);

            Assert.AreNotEqual(null, result.CellGrid[0,0]);
        }
        
        [Test]
        public void ShouldCreateGridIfInputPathInputIsGiven()
        {
            var inputPaths = new[] {"/Users/mario.sinovcic/Documents/Acceleration/Katas/Game Of Life/Game Of Life/Game Of Life Tests/TestData/TestData1.json"};
            var result = _gameSetupFactory.GenerateInitialGrid(inputPaths);

            var s = "k";

            Assert.AreEqual(result.CellGrid[0,0].CellStatus, CellStatus.Alive);
            Assert.AreEqual(result.CellGrid[0,1].CellStatus, CellStatus.Dead);
        }
        
        [Test]
        public void ShouldRandomGridByDefault()
        {
            var inputPaths = new string[] { };
            
            var result = _gameSetupFactory.GenerateInitialGrid(inputPaths);

            Assert.IsNotNull(result.CellGrid[0,0]);
        }
    }
}