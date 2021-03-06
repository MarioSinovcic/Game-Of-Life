using System;
using Game_Of_Life.Application.Behaviours.Setup;
using Game_Of_Life.Application.Interfaces;
using NUnit.Framework;

namespace Game_Of_Life_Tests.Domain_Tests
{
    public class CountingNeighboursTests
    {
        private IGameSetup _gameSetupHandler;

        [Test]
        public void ShouldCountNeighboursCorrectlyForASmallGridWithNoNeighbours()
        {
            var initialGeneration = new[,] {{"o", "o", "o"}, {"o", "x", "o"}, {"o", "o", "o"}};
            _gameSetupHandler = new StringArrayGameSetupHandler(initialGeneration);
            var grid = _gameSetupHandler.CreateInitialGrid();

            Assert.AreEqual(grid.GetAliveNeighbours(1 ,1), 0);
        }
        
        [Test]
        public void ShouldCountNeighboursCorrectlyForASmallGridWithFourNeighbours()
        {
            var initialGeneration = new[,] {{"o", "x", "o"}, {"x", "x", "x"}, {"o", "x", "o"}};
            _gameSetupHandler = new StringArrayGameSetupHandler(initialGeneration);
            var grid = _gameSetupHandler.CreateInitialGrid();

            Assert.AreEqual(grid.GetAliveNeighbours(0 ,1), 4);
        }

        
        [Test]
        public void ShouldCountNeighboursCorrectlyForASmallGridWithOneNeighbour()
        {
            var initialGeneration = new[,] {{"o", "o", "o"}, {"o", "x", "x"}, {"o", "o", "o"}};
            _gameSetupHandler = new StringArrayGameSetupHandler(initialGeneration);
            var grid = _gameSetupHandler.CreateInitialGrid();

            Assert.AreEqual(grid.GetAliveNeighbours(1 ,1), 1);
        }
        
        [Test]
        public void ShouldCountNeighboursCorrectlyForAGridWithNoNeighbours()
        {
            var initialGeneration = new[,] {{"o", "o", "o", "x"}, {"o", "o", "o", "o"}, {"o", "x", "o","o"}, {"o", "o", "o","o"}};
            _gameSetupHandler = new StringArrayGameSetupHandler(initialGeneration);
            var grid = _gameSetupHandler.CreateInitialGrid();

            Assert.AreEqual(grid.GetAliveNeighbours(0 ,3), 0);
        }
        
        [Test]
        public void ShouldCountNeighboursCorrectlyForAGridWithTwoNeighbours()
        {
            var initialGeneration = new[,] {{"o", "o", "o", "o"}, {"x", "o", "o", "x"}, {"o", "x", "o","x"}, {"o", "o", "o","o"}};
            _gameSetupHandler = new StringArrayGameSetupHandler(initialGeneration);
            var grid = _gameSetupHandler.CreateInitialGrid();

            Assert.AreEqual(grid.GetAliveNeighbours(1 ,3), 2);
        }

        [Test]
        public void ShouldThrowErrorIfInputIsOutOfBounds()
        {
            var initialGeneration = new[,] {{"o", "o", "o"}, {"o", "x", "o"}, {"o", "o", "o"}};
            _gameSetupHandler = new StringArrayGameSetupHandler(initialGeneration);
            var grid = _gameSetupHandler.CreateInitialGrid();

            Assert.Throws<IndexOutOfRangeException>(() => grid.GetAliveNeighbours(2 ,3));
        }
        
    }
}