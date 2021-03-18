using Game_Of_Life.Application.Behaviours;
using Game_Of_Life.Application.Interfaces;
using Game_Of_Life.Domain.Enums;
using NUnit.Framework;

namespace Game_Of_Life_Tests.Application_Tests
{
    public class AlternateGridSetupTests 
    {
        private RandomGameSetupHandler _gameSetupHandler;

        [SetUp]
        public void Setup()
        { 
            _gameSetupHandler = new RandomGameSetupHandler(); 
        }
        
    }
}