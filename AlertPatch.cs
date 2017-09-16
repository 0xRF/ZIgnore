using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Harmony;
using SDG.Unturned;
using UnityEngine;
using Rocket.API;
using Rocket.Unturned;
using Rocket.Core;
using Rocket.Unturned.Player;

namespace ZIgnore
{

    [HarmonyPatch(typeof(Zombie))]
    [HarmonyPatch("alert")]
    [HarmonyPatch(new Type[] { typeof(Player)})]
    static class AlertPatch
    {
        private static bool bCanToggleIgnore => Main.Instance.Configuration.Instance.bCanToggleIgnore;
        private static bool bZombiesIgnoreEverything => Main.Instance.Configuration.Instance.bZombiesIgnoreEveryting;

        private static bool ZombieGetsAlerted = true;

        //Remember returning true means the zombie gets alerted
        static bool Prefix(Player newPlayer)
        {
            if (bZombiesIgnoreEverything)
                return !ZombieGetsAlerted;

            UnturnedPlayer player = UnturnedPlayer.FromPlayer(newPlayer);

            if (!bCanToggleIgnore && player.HasPermission("z.ignore"))
                return !ZombieGetsAlerted;

            if (Main.Instance.IgnoredPlayers.Contains(player.Player))
                return !ZombieGetsAlerted;

            return ZombieGetsAlerted;
        }
    }

    [HarmonyPatch(typeof(Zombie))]
    [HarmonyPatch("alert")]
    [HarmonyPatch(new Type[] { typeof(Vector3), typeof(bool) })]
    static class AlertPatch2
    {
        private static bool bZombiesIgnoreEverything => Main.Instance.Configuration.Instance.bZombiesIgnoreEveryting;
        private static bool ZombieGetsAlerted = true;

        static bool Prefix(Vector3 newPosition, bool isStartling)
        {
            if (bZombiesIgnoreEverything)
                return !ZombieGetsAlerted;

            return ZombieGetsAlerted;
        }

    }



}
