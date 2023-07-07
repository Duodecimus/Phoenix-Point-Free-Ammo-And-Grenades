using PhoenixPoint.Modding;
using System;

namespace FreeAmmoAndGrenades
{
	public class Geoscape : ModGeoscape
    {
        private static bool runFlag = true;
        /// <summary>
        /// Called when Geoscape starts.
        /// </summary>
        public override void Init()
        {
            if (runFlag) // run only once per game load
            {
                runFlag = false;
                try
                {
                    FreeAmmoAndGrenadesDefs.Change_AmmoAndGrenades((ModMain)base.Main);
                }
                catch (Exception e)
                {
                    Main.Logger.LogInfo(e.Message);
                }
            }
            base.Init();
        }
    }
}