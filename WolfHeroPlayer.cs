using WolfHeroMod.Buffs;
using WolfHeroMod.Dusts;
using WolfHeroMod.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;

namespace WolfHeroMod
{
	// ModPlayer classes provide a way to attach data to Players and act on that data. ExamplePlayer has a lot of functionality related to 
	// several effects and items in WolfHeroMod. See SimpleModPlayer for a very simple example of how ModPlayer classes work.
	public class WolfHeroPlayer : ModPlayer
	{
		// These 5 relate to ExampleCostume.
		public bool NeffAccessoryPrevious;
		public bool NeffAccessory;
		public bool NeffHideVanity;
		public bool NeffForceVanity;
		public bool NeffPower;		
		public override void ResetEffects() {
			NeffAccessoryPrevious = NeffAccessory;
			NeffAccessory = NeffHideVanity = NeffForceVanity = NeffPower = false;
		}		
		public override void UpdateVanityAccessories() {
			for (int n = 13; n < 18 + player.extraAccessorySlots; n++) {
				Item item = player.armor[n];
				if (item.type == ItemType<Items.Armor.NeffCostume>()) {
					NeffHideVanity = false;
					NeffForceVanity = true;
				}
			}
		}
		public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff) {
			// Make sure this condition is the same as the condition in the Buff to remove itself. We do this here instead of in ModItem.UpdateAccessory in case we want future upgraded items to set blockyAccessory
			if (NeffAccessory) {
				player.AddBuff(BuffType<Buffs.Neff>(), 60, true);
			}
		}		
		public override void FrameEffects() {
			if ((NeffPower || NeffForceVanity) && !NeffHideVanity) {
				player.legs = mod.GetEquipSlot("NeffLeg", EquipType.Legs);
				player.body = mod.GetEquipSlot("NeffBody", EquipType.Body);
				player.head = mod.GetEquipSlot("NeffHead", EquipType.Head);
			}
		}
	}
}