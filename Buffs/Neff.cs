using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace WolfHeroMod.Buffs
{
	public class Neff : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Neff!");
			Description.SetDefault("Speed and Damage buffs.");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			canBeCleared = false;
		}

		public override void Update(Player player, ref int buffIndex) {
			WolfHeroPlayer p = player.GetModPlayer<WolfHeroPlayer>();

			// We use blockyAccessoryPrevious here instead of blockyAccessory because UpdateBuffs happens before UpdateEquips but after ResetEffects.
			if (p.NeffAccessoryPrevious) {
				p.NeffPower = true;
				player.jumpSpeedBoost += 1.5f;
				player.maxRunSpeed += 0.15f;
				player.statDefense += 2;
				player.moveSpeed += 0.10f;
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}
