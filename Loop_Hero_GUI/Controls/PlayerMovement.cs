using Loop_Hero_GUI.Entity;
using Loop_Hero_GUI.MapSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loop_Hero_GUI.Controls
{
    public class PlayerMovement
    {
        private Player _player;

        private int _index;
        
        public PlayerMovement(Player player)
        {
            _player = player;
            _index = 1;
        }

        public string? Movement(MapDrawer map)
        {
            var mapForMovement = map.CalculatedMap;
            if (_index % mapForMovement?.Count == 0)
            {
                _index = 0;
            }
            if (_player.Movement && mapForMovement != null)
            {
                int positionX = _player.PositionX - 90 - mapForMovement[_index]?.PositionX ?? 0;
                int positionY = _player.PositionY - 90 - mapForMovement[_index]?.PositionY ?? 0;
                if (positionX == 0 && positionY == 0) 
                {
                    if (mapForMovement[_index]?.Enemies != null && mapForMovement[_index]?.Enemies?.Count > 0 &&
                        !_player.Movement) 
                        {
                            _player.Movement = true;
                        _player.ActualTileIndex = _index;
                        }
                    _index++;
                }
                if (positionX < 0 &&  positionY == 0) 
                {
                    return "right";
                } else if (positionX > 0 && positionY == 0) 
                {
                    return "left";
                } else if (positionX == 0 && positionY < 0)
                {
                    return "down";
                } else if (positionX == 0 && positionY > 0)
                {
                    return "up";
                }
            }
            return "";
        }
    }

}
