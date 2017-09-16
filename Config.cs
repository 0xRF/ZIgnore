using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIgnore
{
    public class Config : IRocketPluginConfiguration
    {
        public bool bCanToggleIgnore;
        public bool bZombiesIgnoreEveryting;
        public void LoadDefaults()
        {
            bCanToggleIgnore = false;
            bZombiesIgnoreEveryting = false;
        }
    }
}
