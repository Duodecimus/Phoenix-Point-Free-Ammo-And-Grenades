using PhoenixPoint.Common.Core;
using PhoenixPoint.Common.Entities.Items;
using PhoenixPoint.Modding;

namespace FreeAmmoAndGrenades
{
	public class Geoscape : ModGeoscape
    {
        private SharedData _sharedData;

        public static Geoscape Mod => ModMain.Main.GeoscapeMod;
        public new ModMain Main => (ModMain)base.Main;

        public override void Init()
        {
            _sharedData = SharedData.GetSharedDataFromGame();
        }
        
        public bool GetGrenadesAreFree()
        {
            return Main.Config.GrenadesAreFree;
        }

        public bool GetAmmoIsFree()
        {
            return Main.Config.AmmoIsFree;
        }

        public bool IsManufacturableItemDefAmmo(ItemDef item)
        {
            return item.Tags.Contains(_sharedData.SharedGameTags.AmmoTag) ||
				(item.RelatedItemDef != null && item.RelatedItemDef.Tags.Contains(_sharedData.SharedGameTags.AmmoTag));
		}

		public bool IsManufacturableItemDefGrenade(ItemDef item)
        {
            return item.name.Contains("Grenade_WeaponDef") ||
				(item.RelatedItemDef != null && item.name.Contains("Grenade_WeaponDef"));
		}

		public bool IsManufacturableItemDefAmmoOrGrenade(ItemDef item) {
            bool result = (item != null) && (IsManufacturableItemDefAmmo(item) || IsManufacturableItemDefGrenade(item));
            return result;

        }
    }

}
