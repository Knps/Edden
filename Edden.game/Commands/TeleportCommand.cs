using System.Collections.Generic;
using System.Linq;
using KnpsToolkit.KnpsCommand;

namespace Edden.game.Commands
{
    public class TeleportCommand : KnpsCommand
    {
        private int _mapId;
        private int _cellId;
        private List<string> _characters; 

        public TeleportCommand()
        {
            Id = "teleport";
            _cellId = -1;
            _mapId = -1;
            _characters = new List<string>();
        }

        public override void OnExecute()
        {
            
        }

        public override void Parse(string data)
        {
            var cmdSplited = data.Split(' ');

            if (cmdSplited.Length != 3 || !int.TryParse(cmdSplited[0], out _mapId) ||
                !int.TryParse(cmdSplited[1], out _cellId)) return;

            _characters = cmdSplited[2].Split(',').ToList();
            CanExecute = true;
        }

        public override string OnHelp()
        {
            return "[mapID] [cellID] [characterName1, characterName2, ..., n]";
        }
    }
}
