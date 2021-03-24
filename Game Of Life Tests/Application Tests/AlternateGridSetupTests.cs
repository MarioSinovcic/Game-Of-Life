using Game_Of_Life.Application.Behaviours.Setup;
using Game_Of_Life.Application.Enums;
using Game_Of_Life.Domain.Enums;
using NUnit.Framework;

namespace Game_Of_Life_Tests.Application_Tests
{
    public class AlternateGridSetupTests 
    {
        private GameSetupFactory _gameSetupFactory;

        [Test]
        public void ShouldCreateRandomGridIfNullInputIsGiven()
        {
            _gameSetupFactory = new GameSetupFactory(SetupType.Random);
            var result = _gameSetupFactory.GenerateInitialGrid();

            Assert.AreNotEqual(null, result.CellGrid[0,0]);
        }
        
        [Test]
        public void ShouldCreateGridIfInputPathInputIsGiven()
        {
            var inputPath =
                "/Users/mario.sinovcic/Documents/Acceleration/Katas/Game Of Life/Game Of Life/Game Of Life Tests/TestData/TestData1.json";
            _gameSetupFactory = new GameSetupFactory(SetupType.PathName,inputPath);
            var result = _gameSetupFactory.GenerateInitialGrid();

            Assert.AreEqual(result.CellGrid[0,0].CellStatus, CellStatus.Alive);
            Assert.AreEqual(result.CellGrid[0,1].CellStatus, CellStatus.Dead);
        }
        
        [Test]
        public void ShouldRandomGridByDefault()
        {
            var inputPath = "";
            _gameSetupFactory = new GameSetupFactory(SetupType.PathName,inputPath);
            var result = _gameSetupFactory.GenerateInitialGrid();

            Assert.IsNotNull(result.CellGrid[0,0]);
        }
    }
}