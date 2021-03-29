using System;
using System.Collections.Generic;
using System.IO;
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
        
        private static Dictionary<SetupType, IGameSetup> _setupDict = new Dictionary<SetupType, IGameSetup>()
        {
            {SetupType.Random, RandomGameSetupHandler},
            {SetupType.PathName, RandomGameSetupHandler},
            {SetupType.StringInput, StringArrayGameSetupHandler}
        };
        
        public static Grid CreateGrid(SetupType setupType)
        {
            return GenerateInitialGrid(setupType);
        }
        
        public static Grid CreateGridFromArray(SetupType setupType, string[,] initArray)
        {
            _setupDict[SetupType.StringInput] = new StringArrayGameSetupHandler(initArray);
            return GenerateInitialGrid(setupType);
        }

        public static Grid CreateGameFromJsonFile(SetupType setupType, string pathname) //should take in a string of json
        {
            if (string.IsNullOrEmpty(pathname) || string.IsNullOrWhiteSpace(pathname))
            {
                throw new ApplicationException("Invalid path");
            }
            
            try
            {
                File.Exists(pathname); 
                _setupDict[SetupType.PathName] = new PathNameGameSetupHandler(pathname); //ui should handle reading json
                return GenerateInitialGrid(setupType);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Invalid path", e);
            }
        }

        private static Grid GenerateInitialGrid(SetupType setupType)
        {
            return _setupDict[setupType].CreateInitialGrid();
        }
    }
}