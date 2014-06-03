using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Edden.core;
using Edden.core.Extentions;
using Edden.core.Models;
using Edden.core.Network;
using Edden.realm.Models;
using Edden.realm.Models.Event;
using Edden.realm.Network.Game.Message;
using KnpsToolkit.KnpsNetwork;

namespace Edden.realm.Network.Game
{
    public enum GameState
    {
        OnBackup = 2,
        OnLine = 1,
        OffLine = 0,
        OnMaintenace = 3
    }

    public class GameClient : KnpsClient
    {
        public delegate void StateChangedDelegate(GameState state);

        public event StateChangedDelegate StateChanged;

        protected virtual void OnStateChanged(GameState state)
        {
            StateChangedDelegate handler = StateChanged;
            if (handler != null) handler(state);
        }

        private readonly MessageManagerGame _mManager;

        public GameClientInfoModel Infos { get; set; }

        public GameManager Manager { get; set; }

        private GameState _state = GameState.OffLine;

        public GameState State
        {
            get { return _state; }
            set { _state = value; OnStateChanged(value); }
        }

        public GameClient()
        {
            Infos = new GameClientInfoModel();
            _mManager = new MessageManagerGame(this);
            _mManager.InitMessages();
            _mManager.Log.NewMessage += Log_NewMessage;
            _mManager.Log.NewException += Log_NewException;
        }

        private void Log_NewException(Exception ex)
        {
            Manager.RCore.Log.WriteException(ex);
        }

        private void Log_NewMessage(MessageLogModel message)
        {
            if(Manager == null) return;

            Manager.RCore.Log.Write(message);
        }

        public void InitManager(GameManager manager)
        {
            Manager = manager;
        }

        public void Manage(string packet)
        {
            _mManager.Parse(Encoding.UTF8.GetBytes(packet));
        }

        public void UpdateState(GameState state)
        {
            OnStateChanged(state);
        }
    }
}
