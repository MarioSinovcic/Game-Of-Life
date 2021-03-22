using System.IO;
using Game_Of_Life.Application.Behaviours.Setup.DTOs;
using Game_Of_Life.Domain;
using Game_Of_Life.Domain.Enums;
using Newtonsoft.Json;

namespace Game_Of_Life.Application.Behaviours.Setup
{
    public class PathNameGameSetupHandler
    {
        public Grid CreateInitialGrid(string pathName)
        {
            if(File.Exists(pathName))
            {
                using (StreamReader r = new StreamReader(pathName))
                {
                    var jsonInput = JsonConvert.DeserializeObject<InputInfoDTO>(r.ReadToEnd());

                    var gridWidth = jsonInput.InitialGrid.GetLength(1);
                    var gridHeight = jsonInput.InitialGrid.GetLength(0);

                    var cellGrid = new Cell[gridHeight,gridWidth];
            
                    for (var i = 0; i < gridWidth; i++)
                    {
                        for (var j = 0; j < gridHeight; j++)
                        {
                            var cellStatus = GetCellStatus(jsonInput.InitialGrid[j,i], jsonInput.LiveCellChar);
                            cellGrid[j,i] = new Cell(cellStatus);
                        }
                    }
            
                    return new Grid(gridHeight, gridWidth, cellGrid);
                }
            }
            return null;
        }

        private CellStatus GetCellStatus(string value, string liveCellChar)
        {
            return string.Equals(value, liveCellChar) ? CellStatus.Alive : CellStatus.Dead;
        }
    }
}