using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace WolfHeroMod
{
	public class WolfHeroMod : Mod
	{
		public WolfHeroMod()
		{
		}
		
		// Other Code
		
		public override void AddRecipeGroups()
		{
			// Creates a new recipe group
			RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + "GoldBar", new int[]
			{
				ItemID.GoldBar,
				ItemID.PlatinumBar
			});
			// Registers the new recipe group with the specified name
			RecipeGroup.RegisterGroup("WolfHeroMod:GoldBars", group);
		}
		public override void Load() {
			// All code below runs only if we're not loading on a server
			if (!Main.dedServ) {
				// Add certain equip textures
				AddEquipTexture(new Items.Armor.NeffHead(), null, EquipType.Head, "NeffHead", "WolfHeroMod/Items/Armor/NeffCostume_Head");
				AddEquipTexture(new Items.Armor.NeffBody(), null, EquipType.Body, "NeffBody", "WolfHeroMod/Items/Armor/NeffCostume_Body", "WolfHeroMod/Items/Armor/NeffCostume_Arms");
				AddEquipTexture(new Items.Armor.NeffLegs(), null, EquipType.Legs, "NeffLeg", "WolfHeroMod/Items/Armor/NeffCostume_Legs");

			}
		}
	}
}