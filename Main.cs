using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SDG.Unturned;
using Rocket.Core.Plugins;
using Harmony;
using RLog = Rocket.Core.Logging.Logger;
using Rocket.Core.Commands;
using Rocket.API;
using Rocket.API.Collections;
using Rocket.Unturned.Player;

namespace ZIgnore
{
    public class Main : RocketPlugin<Config>
    {
        internal static Main Instance;
        private HarmonyInstance hInstance;

        public List<Player> IgnoredPlayers = new List<Player>();

        public override TranslationList DefaultTranslations
            => new TranslationList()
                {
                    {"disable","Zombies will now sense you" },
                    {"enable", "Zombies can't sense you anymore" }
                };


        string toggleOn = "bCanToggleIgnore is on which means players can enable/disable beeing sensed by zombies with /zi /zignore with the szZombieIgnorePermission";
        string toggleOff = "bCanToggleIgnore is off which means zombies will ignore players with the permissions of szZombieIgnorePermission";
        string addingToPerms = "Example :S<Permission>z.ignore</Permission>";
        protected override void Load()
        {

            Instance = this;
            hInstance = HarmonyInstance.Create("ZIgnore");
            hInstance.PatchAll(Assembly.GetExecutingAssembly());

#if DEBUG
            RLog.Log("bCanToggleIgnore " + Configuration.Instance.bCanToggleIgnore, ConsoleColor.Cyan);
            RLog.Log("bZombiesIgnoreEveryting" + Configuration.Instance.bZombiesIgnoreEveryting, ConsoleColor.Cyan);
#endif

            RLog.Log("Loaded ZIgnore!, Enjoy *wink* *wink*", ConsoleColor.Green);
        }
    }
}
