using PhoenixPoint.Modding;

namespace FreeAmmoAndGrenades
{
    public class Configuration : ModConfig
    {
		[ConfigField(text: "Ammo is free to manufacture, and provides no scrap", description: "Please be sure to restart the game after changing these settings, to reload the mod")]
		public bool AmmoIsFree = true;

		[ConfigField(text: "Grenades are free to manufacture and provide no scrap", description: "Please be sure to restart the game after changing these settings, to reload the mod")]
		public bool GrenadesAreFree = true;
	}
}