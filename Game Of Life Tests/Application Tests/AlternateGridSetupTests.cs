using Game_Of_Life.Application.Behaviours;
using Game_Of_Life.Application.Behaviours.Setup;
using Game_Of_Life.Application.Interfaces;
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
            var result = _gameSetupFactory.GenerateInitialGrid("inputPath"); //create dummy file

            Assert.AreNotEqual(null, result.CellGrid[0,0]);
        }
    }
}