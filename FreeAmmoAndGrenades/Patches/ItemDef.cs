using HarmonyLib;
using PhoenixPoint.Common.Core;
using PhoenixPoint.Common.Entities.Items;

namespace FreeAmmoAndGrenades.Patches.ItemDefPatches
{
    [HarmonyPatch(typeof(ItemDef), "get_ManufacturePrice")]
	class ManufacturePrice
	{
        static void Postfix(ItemDef __instance, ref ResourcePack __result)
        {
            if ((Geoscape.Mod.GetAmmoIsFree() && Geoscape.Mod.IsManufacturableItemDefAmmo(__instance)) || 
                (Geoscape.Mod.GetGrenadesAreFree() && Geoscape.Mod.IsManufacturableItemDefGrenade(__instance)))
			{
                __result = new ResourcePack(new ResourceUnit[]
                {
                    new ResourceUnit(ResourceType.Tech, 0),
                    new ResourceUnit(ResourceType.Materials, 0),
                    new ResourceUnit(ResourceType.Mutagen, 0),
                    new ResourceUnit(ResourceType.LivingCrystals, 0),
                    new ResourceUnit(ResourceType.Orichalcum, 0),
                    new ResourceUnit(ResourceType.ProteanMutane, 0)
                });                
            }			
		}
	}

	[HarmonyPatch(typeof(ItemDef), "get_ScrapPrice")]
    class ScrapPrice
	{
        static void Postfix(ItemDef __instance, ref ResourcePack __result)
        {
            if ((Geoscape.Mod.GetAmmoIsFree() && Geoscape.Mod.IsManufacturableItemDefAmmo(__instance)) ||
                (Geoscape.Mod.GetGrenadesAreFree() && Geoscape.Mod.IsManufacturableItemDefGrenade(__instance)))
            {
                __result = new ResourcePack(new ResourceUnit[]
				{
					new ResourceUnit(ResourceType.Tech, 0),
					new ResourceUnit(ResourceType.Materials, 0),
					new ResourceUnit(ResourceType.Mutagen, 0),
					new ResourceUnit(ResourceType.LivingCrystals, 0),
					new ResourceUnit(ResourceType.Orichalcum, 0),
					new ResourceUnit(ResourceType.ProteanMutane, 0)
				});
            }
		}
	}
}