using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace WolfHeroMod.Items.Armor
{
	// This and several other classes show off using EquipTextures to do a Merfolk or Werewolf effect. 
	// Typically Armor items are automatically paired with an EquipTexture, but we can manually use EquipTextures to achieve more unique effects.
	// There is code for this effect in many places, look in the following files for the full implementation:
	// NPCs.ExamplePerson drops this item when killed
	// Items.Armor.ExampleCostume (below) is the accessory item that sets ExamplePlayer values. Note that this item does not have EquipTypes set. This is a vital difference and key to our approach.
	// Items.Armor.BlockyHead/Body/Legs (below) are EquipTexture classes. They simply disable the drawing of the player's head/body/legs respectively when they are set as the drawn EquipTexture. One spawns dust too.
	// ExampleMod.Load() shows calling AddEquipTexture 3 times with appropriate parameters. This is how we register EquipTexture manually instead of the automatic pairing of ModItem and EquipTexture that other equipment uses.
	// Buffs.Blocky is the Buff that is shown while in Blocky mode. The buff is responsible for the actual stat effects of the costume. It also needs to remove itself when not near town npcs.
	// ExamplePlayer has 5 bools. They manage the visibility and other things related to this effect.
	// ExamplePlayer.ResetEffects resets those bool, except blockyAccessoryPrevious which is special because of the order of hooks.
	// ExamplePlayer.UpdateVanityAccessories is responsible for forcing the visual effect of our costume if the item is in a vanity slot. Note that ModItem.UpdateVanity can't be used for this because it is called too late.
	// ExamplePlayer.UpdateEquips is responsible for applying the Blocky buff to the player if the conditions are met and the accessory is equipped.
	// ExamplePlayer.FrameEffects is most important. It overrides the drawn equipment slots and sets them to our Blocky EquipTextures. 
	// ExamplePlayer.ModifyDrawInfo is for some fun effects for our costume.
	// Remember that the visuals and the effects of Costumes must be kept separate. Follow this example for best results.
	public class NeffCostume : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Stone Bracelet");
			Tooltip.SetDefault("Take on the appearance of Neff!\n25% increased jump height\n10% increased maximum speed\n5% increased movement speed\n Defense increased by 2");
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 28;
			item.accessory = true;
			item.value = 1;
			item.rare = 2;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 20);
			recipe.AddIngredient(ItemID.MarbleBlock, 15);
			recipe.AddIngredient(ItemID.Emerald, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			WolfHeroPlayer p = player.GetModPlayer<WolfHeroPlayer>();
			p.NeffAccessory = true;
			if (hideVisual) {
				p.NeffHideVanity = true;
			}
		}
	}

	public class NeffHead : EquipTexture
	{
		public override bool DrawHead() {
			return false;
		}
	}

	public class NeffBody : EquipTexture
	{
		public override bool DrawBody() {
			return false;
		}
	}

	public class NeffLegs : EquipTexture
	{
		public override bool DrawLegs() {
			return false;
		}
	}
}