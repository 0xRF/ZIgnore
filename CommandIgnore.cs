using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIgnore
{
    public class CommandIgnore : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "zignore";

        public string Help => "";

        public string Syntax => "";

        public List<string> Aliases => new List<string>() { "zi" };

        public List<string> Permissions => new List<string>() { "z.ignore" };

        public void Execute(IRocketPlayer caller, string[] command)
        {

            if (!Main.Instance.Configuration.Instance.bCanToggleIgnore)
                return;

            UnturnedPlayer player = caller as UnturnedPlayer;

            if (player == null)
                return;

            if (Main.Instance.IgnoredPlayers.Contains(player.Player))
            {
                UnturnedChat.Say(player, Main.Instance.Translate("disable"));
                Main.Instance.IgnoredPlayers.Remove(player.Player);
                return;
            }

            Main.Instance.IgnoredPlayers.Add(player.Player);
            UnturnedChat.Say(player, Main.Instance.Translate("enable"));
        }
    }
}
