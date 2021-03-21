using Game_Of_Life.Domain;

namespace Game_Of_Life.Application.Behaviours.Setup
{
    public class GameSetupFactory
    {
        private static readonly StringArrayGameSetupHandler StringArrayGameSetupHandler = new StringArrayGameSetupHandler();
        private static readonly RandomGameSetupHandler RandomGameSetupHandler = new RandomGameSetupHandler();

        public Grid GenerateInitialGrid(string args)
        {
            if (string.IsNullOrEmpty(args))
            {
                return RandomGameSetupHandler.CreateInitialGrid();
            }
            else
            {
                var initialGeneration = new[,] {{"o", "x", "o"}, {"o", "x", "x"}, {"x", "x", "x"}}; //replace with pathname reading
                return StringArrayGameSetupHandler.CreateInitialGrid(initialGeneration);
            }
        }
    }
}