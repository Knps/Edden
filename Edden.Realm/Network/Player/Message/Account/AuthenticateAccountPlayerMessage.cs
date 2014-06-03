using System;
using Edden.core.Network;
using Edden.core.Utils;

namespace Edden.realm.Network.Player.Message.Account
{
    public class AuthenticateAccountPlayerMessage : NetworkMessage<MessageManagerPlayer>
    {
        private string _username = "";
        private string _password = "";

        public AuthenticateAccountPlayerMessage(MessageManagerPlayer manager) : base(manager)
        {
        }

        public override string GetId()
        {
            return "WA";
        }

        public override void Handle(Packet packet)
        {
            var cSplit = packet.Content.Split('\n');

            if(cSplit.Length != 2) return;

            _username = cSplit[0];
            _password = cSplit[1];

            Manager.PClient.Infos.AccountId =
                Manager.PClient.Manager.RCore.Db.Account.Authenticate(_username, Crypt.Decode(_password, Manager.PClient.Infos.HcKey));

            if (Manager.PClient.Infos.AccountId == -1)
            {
                Manager.PClient.SendMessage("AlEf");
                return;
            }

            var pClient = Manager.PClient.Manager.Server.Clients.Find(a => a != Manager.PClient && a.Infos.AccountId == Manager.PClient.Infos.AccountId);

            if (pClient != null)
            {
                pClient.Disconnect();
                Manager.PClient.SendMessage("AlEd");
                return;
            }

            var state = Manager.PClient.Manager.RCore.Db.Account.GetStateById(Manager.PClient.Infos.AccountId);

            switch (state.Identity)
            {
                case -2:
                    Manager.PClient.SendMessage("AlEb");
                    break;

                case -1:
                    Manager.PClient.SendMessage("AlEm");
                    break;

                case 0:
                    var bannedAt = GetBannedAt(state.BannedAt);

                    if (!string.IsNullOrEmpty(bannedAt))
                    {
                        Manager.PClient.SendMessage("AlEk" + bannedAt);
                        return;
                    }

                    Manager.PClient.Infos.AuthenticateState = 2;

                    break;
            }
        }

        private static string GetBannedAt(DateTime bannedAt)
        {
            if (bannedAt <= DateTime.Now) return "";
            var banTimeSub = bannedAt.Subtract(DateTime.Now);

            return string.Format("{0}|{1}|{2}", banTimeSub.Days, banTimeSub.Hours, banTimeSub.Minutes);
        }

        protected override string GetReceiveContent()
        {
            return string.Format("Username [{0}] Password [{1}]", _username, _password);
        }

        public override void Reset()
        {
             _username = "";
             _password = "";
        }

        protected override string GetSendContent()
        {
            return string.Format("");
        }
    }
}
