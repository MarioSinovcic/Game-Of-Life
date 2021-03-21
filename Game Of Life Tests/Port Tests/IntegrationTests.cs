using Game_Of_Life.Application.Behaviours;
using Game_Of_Life.Application.Behaviours.Setup;
using Game_Of_Life.Domain;
using Game_Of_Life.Port;
using NUnit.Framework;

namespace Game_Of_Life_Tests.Port_Tests
{
    public class IntegrationTests
    {
        private GameController _gameController;

        [SetUp]
        public void Setup()
        { 
            var gameRules =  new ClassicRuleFactory();
            var gameSetup =  new GameSetupFactory();
            _gameController = new GameController(gameSetup, gameRules);
        }
    }
}