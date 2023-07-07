using HarmonyLib;
using System;
namespace FreeAmmoAndGrenades
{
	/// <summary>
	/// This is the main mod class. Only one can exist per assembly.
	/// If no ModMain is detected in assembly, then no other classes/callbacks will be called.
	/// </summary>
	public class ModMain : PhoenixPoint.Modding.ModMain
    {
		public override bool CanSafelyDisable => false;
		
		public static ModMain Main { get; private set; }

		public new Configuration Config => (Configuration)base.Config;

		public new Harmony HarmonyInstance => (Harmony)base.HarmonyInstance;

		public new Geoscape GeoscapeMod => (Geoscape)base.GeoscapeMod;

		public override void OnModEnabled()
		{
			try
			{
				Main = this;
				HarmonyInstance.PatchAll();
			}
			catch (Exception e)
			{
				Main.Logger.LogInfo(e.Message);
			}
		}

		public override void OnModDisabled()
		{
			HarmonyInstance.UnpatchAll();
			Main = null;
		}
	}
}