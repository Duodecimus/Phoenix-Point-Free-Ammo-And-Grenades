using HarmonyLib;
using PhoenixPoint.Modding;

namespace FreeAmmoAndGrenades
{
	/// <summary>
	/// This is the main mod class. Only one can exist per assembly.
	/// If no ModMain is detected in assembly, then no other classes/callbacks will be called.
	/// </summary>
	public class ModMain : PhoenixPoint.Modding.ModMain
    {
		public override bool CanSafelyDisable => true;

		public static ModMain Main { get; private set; }

		public new Configuration Config => (Configuration)base.Config;

		public new Harmony HarmonyInstance => (Harmony)base.HarmonyInstance;

		public new Geoscape GeoscapeMod => (Geoscape)base.GeoscapeMod;

		public override void OnModEnabled() {

			Main = this;
			HarmonyInstance.PatchAll(GetType().Assembly);
		}

		public override void OnModDisabled() {
			HarmonyInstance.UnpatchAll(HarmonyInstance.Id);
			Main = null;
		}
	}
}
