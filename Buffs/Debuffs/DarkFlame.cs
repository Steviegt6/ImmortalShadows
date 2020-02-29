using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ImmortalShadows;

namespace ImmortalShadows.Buffs.Debuffs
{
	public class DarkFlame : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Dark Inferno");
			Description.SetDefault("Losing life");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<ImmortalPlayer>().darkFlame = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<ImmortalNPC>().darkFlame = true;
		}
	}
}
