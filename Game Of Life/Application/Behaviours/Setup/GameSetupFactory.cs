using Game_Of_Life.Domain;

namespace Game_Of_Life.Application.Behaviours
{
    public static class GameSetupFactory
    {
        private static readonly StringArrayGameSetupHandler StringArrayGameSetupHandler = new StringArrayGameSetupHandler();
        private static readonly RandomGameSetupHandler RandomGameSetupHandler = new RandomGameSetupHandler();

        public static Grid SetupGame(string [,] initBoard)
        {
            return StringArrayGameSetupHandler.CreateInitialGrid(initBoard);
        }
        
        public static Grid SetupGame()
        {
            return RandomGameSetupHandler.CreateInitialGrid();
        }
    }
}