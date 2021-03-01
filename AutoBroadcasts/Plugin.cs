using System;
using System.Linq;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Loader;
using System.Reflection;

using PlayerEv = Exiled.Events.Handlers.Player;
using ServerEv = Exiled.Events.Handlers.Server;
using MEC;
using System.Collections;
using System.Collections.Generic;

namespace AutoBroadcasts
{
    public class Plugin : Plugin<Config>
    {
        private static readonly Lazy<Plugin> LazyInstance = new Lazy<Plugin>(() => new Plugin());
        public static Plugin Instance => LazyInstance.Value;

        public override PluginPriority Priority => PluginPriority.Low;

        public override string Name { get; } = "AutoBroadcasts";
        public override string Author { get; } = "Cwaniak U.G";
        public override Version Version => new Version(1, 0, 0);

        public override void OnEnabled()
        {
            base.OnEnabled();
            Exiled.Events.Handlers.Server.WaitingForPlayers += OnWaitingForPlayers;
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            Exiled.Events.Handlers.Server.WaitingForPlayers -= OnWaitingForPlayers;
        }

        public IEnumerator<float> Broadcast()
        {
            for (; ; )
            {
                    Map.Broadcast(Plugin.Instance.Config.Text_duration, Plugin.Instance.Config.Text);

                yield return Timing.WaitForSeconds(Plugin.Instance.Config.Delay);
            }
        }

        public void OnWaitingForPlayers()
        {
            Timing.RunCoroutine(Broadcast());
        }
    }
}
