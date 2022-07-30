using PhoenixPoint.Modding;

namespace FreeAmmoAndGrenades
{
    public class Configuration : ModConfig
    {
        [ConfigField(description: "Ammo is free to manufacture, and provides no scrap.")]
		public bool AmmoIsFree = false;

		[ConfigField(description: "Grenades are free to manufacture and provide no scrap.")]
		public bool GrenadesAreFree = false;
	}
}
