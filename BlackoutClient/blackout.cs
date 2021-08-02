using System;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace BlackoutClient
{
    public class blackout : BaseScript
    {
        public blackout()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
        }
        private void OnClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return;
            RegisterCommand("poweroff", new Action<int, List<object>, string>((source, args, raw) =>
            {

                    TriggerEvent("chat:addMessage", new
                    {
                        color = new[] { 255, 0, 0 },
                        args = new[] { "[Blackout]Blackout mode: Enabled" }
                    });
                    SetArtificialLightsState(true);
                    SetArtificialLightsStateAffectsVehicles(false);
            }), false);

            RegisterCommand("poweron", new Action<int, List<object>, string>((source, args, raw) =>
            { 

            TriggerEvent("chat:addMessage", new
                    {
                        color = new[] { 255, 0, 0 },
                        args = new[] { "[Blackout]Blackout mode: Disabled" }
                    });
                    SetArtificialLightsState(false);
                    SetArtificialLightsStateAffectsVehicles(false);
            }), false);       
        }
    }
}
