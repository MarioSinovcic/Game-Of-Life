using System;
using System.Collections.Generic;
using Game_Of_Life.Application.Enums;
using Game_Of_Life.Application.Interfaces;
using Game_Of_Life.Domain;

namespace Game_Of_Life.Application.Behaviours.Setup
{
    public class GameSetupFactory
    {
        private static readonly RandomGameSetupHandler RandomGameSetupHandler = new RandomGameSetupHandler();
        private static PathNameGameSetupHandler PathNameGameSetupHandler;
        private static StringArrayGameSetupHandler StringArrayGameSetupHandler;

        private Dictionary<SetupType, IGameSetup> _setupDict = new Dictionary<SetupType, IGameSetup>()
        {
            {SetupType.Random, RandomGameSetupHandler},
            {SetupType.PathName, RandomGameSetupHandler},
            {SetupType.StringInput, StringArrayGameSetupHandler}
        };

        private readonly SetupType _setupType;
        
        public GameSetupFactory(SetupType setupType)
        {
            _setupType = setupType;
        }
        
        public GameSetupFactory(SetupType setupType, string[,] initArray)
        {
            _setupType = setupType;
            _setupDict[SetupType.PathName] = new StringArrayGameSetupHandler(initArray);
        }

        public GameSetupFactory(SetupType setupType, string pathname)
        {
            _setupType = setupType;
            if (string.IsNullOrEmpty(pathname))
            {
                _setupDict[SetupType.PathName] = new RandomGameSetupHandler();
            }
            else
            {
                _setupDict[SetupType.PathName] = new PathNameGameSetupHandler(pathname);
            }
        }

        public Grid GenerateInitialGrid()
        {
            return _setupDict[_setupType].CreateInitialGrid();
        }
    }
}