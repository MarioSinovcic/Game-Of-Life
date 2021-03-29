using System;
using System.IO;
using Game_Of_Life.Application.Behaviours.Setup;
using Game_Of_Life.Application.Enums;
using Game_Of_Life.Domain.Enums;
using NUnit.Framework;

namespace Game_Of_Life_Tests.Application_Tests
{
    public class AlternateGridSetupTests 
    {
        [Test]
        public void ShouldCreateRandomGridIfNullInputIsGiven()
        {
            var result = GameSetupFactory.CreateGrid(SetupType.Random);

            Assert.AreNotEqual(null, result.CellGrid[0,0]);
        }
        
        [Test]
        public void ShouldCreateGridIfInputPathInputIsGiven()
        {
            const string inputPath = "/Users/mario.sinovcic/Documents/Acceleration/Katas/Game Of Life/Game Of Life/Game Of Life Tests/TestData/TestData1.json";
            var result = GameSetupFactory.CreateGameFromJsonFile(SetupType.PathName, inputPath);

            Assert.AreEqual(result.CellGrid[0,0].CellStatus, CellStatus.Alive);
            Assert.AreEqual(result.CellGrid[0,1].CellStatus, CellStatus.Dead);
        }
        
        [Test]
        public void ShouldReturnErrorIfPathIsInvalid()
        {
            const string inputPath = "";
            Assert.Throws<ApplicationException>(() => GameSetupFactory.CreateGameFromJsonFile(SetupType.PathName, inputPath));
        }
    }
}