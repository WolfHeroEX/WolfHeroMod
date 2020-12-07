using WolfHeroMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace WolfHeroMod.Items
{
	public class WolfClaw : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Seems useful.");
		}

		public override void SetDefaults() {
			item.damage = 15;
			item.melee = true;
			item.width = 26;
			item.height = 22;
			item.useTime = 23;
			item.useAnimation = 23;
			item.pick = 55;
			item.axe = 11;          //How much axe power the weapon has, note that the axe power displayed in-game is this value multiplied by 5
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = 10000;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("WolfHeroMod:GoldBars", 15);
			recipe.AddIngredient(ItemID.Leather, 2);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}