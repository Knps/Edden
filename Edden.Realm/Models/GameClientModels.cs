using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edden.realm.Network.Game;

namespace Edden.realm.Models
{
    public class GameClientInfoModel
    {
        public GameState State { get; set; }

        public long ServerId { get; set; }

        public GameClientInfoModel()
        {
            ServerId = -1;
            State = GameState.OffLine;
        }
    }
}
