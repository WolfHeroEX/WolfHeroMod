using WolfHeroMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace WolfHeroMod.Items
{
	public class WolfClaw2 : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Super Wolf Claw"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Its power has grown.");
		}

		public override void SetDefaults() {
			item.damage = 35;
			item.melee = true;
			item.width = 26;
			item.height = 22;
			item.useTime = 14;
			item.useAnimation = 14;
			item.pick = 100;
			item.axe = 15;          //How much axe power the weapon has, note that the axe power displayed in-game is this value multiplied by 5
			item.useStyle = 1;
			item.knockBack = 1;
			item.value = 1;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 35);
			recipe.AddIngredient(ItemID.MarbleBlock, 50);
			recipe.AddIngredient(ItemID.GraniteBlock, 50);
			recipe.AddIngredient(ItemID.Emerald, 2);
			recipe.AddIngredient(ItemType<WolfClaw>(), 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(10)) {
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustType<Sparkle>());
			}
		}
	}
}