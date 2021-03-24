using System.IO;
using Game_Of_Life.Application.Behaviours.Setup.DTOs;
using Game_Of_Life.Application.Interfaces;
using Game_Of_Life.Domain;
using Game_Of_Life.Domain.Enums;
using Newtonsoft.Json;

namespace Game_Of_Life.Application.Behaviours.Setup
{
    public class PathNameGameSetupHandler :IGameSetup
    {
        private string _pathName;

        public PathNameGameSetupHandler(string pathName)
        {
            _pathName = pathName;
        }
        
        public Grid CreateInitialGrid()
        {
            if (!File.Exists(_pathName)) return null;
            
            using var r = new StreamReader(_pathName);
            var jsonInput = JsonConvert.DeserializeObject<InputInfoDTO>(r.ReadToEnd());

            var gridWidth = jsonInput.InitialGrid.GetLength(1);
            var gridHeight = jsonInput.InitialGrid.GetLength(0);

            var cellGrid = new Cell[gridHeight,gridWidth];
            
            for (var i = 0; i < gridWidth; i++)
            {
                for (var j = 0; j < gridHeight; j++)
                {
                    var cellStatus = GetCellStatus(jsonInput.InitialGrid[j,i], jsonInput.LiveCellChar);
                    cellGrid[j,i] = new Cell{CellStatus = cellStatus};
                }
            }
            
            return new Grid(cellGrid);
        }

        private CellStatus GetCellStatus(string value, string liveCellChar)
        {
            return string.Equals(value, liveCellChar) ? CellStatus.Alive : CellStatus.Dead;
        }
    }
}