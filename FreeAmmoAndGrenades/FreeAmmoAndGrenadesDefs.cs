using Base.Core;
using Base.Defs;
using PhoenixPoint.Common.Core;
using PhoenixPoint.Common.Entities.GameTags;
using PhoenixPoint.Common.Entities.Items;

using FreeAmmoAndGrenades;
public class FreeAmmoAndGrenadesDefs
{
    internal static readonly DefRepository Repo = GameUtl.GameComponent<DefRepository>();
    public static void Change_AmmoAndGrenades(ModMain Main)
    {
        // defining variables
        SharedData shared = GameUtl.GameComponent<SharedData>();
        GameTagDef GrenadeTag = (GameTagDef)Repo.GetDef("318dd3ff-28f0-1bb4-98bc-39164b7292b6"); // GrenadeItem_TagDef
        GameTagDef AmmoTag = shared.SharedGameTags.AmmoTag;
        // loop over all item defs in the repo
        int Count = 0;
        Main.Logger.LogInfo($"Free Ammo and Grenades: Beginning updating items");
        foreach (ItemDef ItemDef in Repo.GetAllDefs<ItemDef>())
        {
            // All hand thrown grenades (only these weapon defs ends with "Grenade_WeaponDef" <- checked by tag)
            if (ItemDef.Tags.Contains(GrenadeTag) && Main.Config.GrenadesAreFree) 
            {
                //Main.Logger.LogInfo(System.String.Concat($"Applying Grenade Discount to: ", ItemDef.name));
                Count++;
                ItemDef.ManufactureMaterials = 0;
                ItemDef.ManufactureTech = 0;
                ItemDef.ManufactureMutagen = 0;
                ItemDef.ManufactureLivingCrystals = 0;
                ItemDef.ManufactureOricalcum = 0;
                ItemDef.ManufactureProteanMutane = 0;
            }
            else if (ItemDef.Tags.Contains(AmmoTag) && Main.Config.AmmoIsFree)
            {
                //Main.Logger.LogInfo(System.String.Concat($"Applying Ammo Discount to: ", ItemDef.name));
                Count++;
                ItemDef.ManufactureMaterials = 0;
                ItemDef.ManufactureTech = 0;
                ItemDef.ManufactureMutagen = 0;
                ItemDef.ManufactureLivingCrystals = 0;
                ItemDef.ManufactureOricalcum = 0;
                ItemDef.ManufactureProteanMutane = 0;
            }
            //else
            //{
            //Main.Logger.LogInfo(System.String.Concat($"Skipping item: ", ItemDef.name));
            //}
        }
        Main.Logger.LogInfo(System.String.Format("Free Ammo and Grenades: Finished updating {0} items", Count));
    }
}