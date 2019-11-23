using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ImmortalShadows.Items.ShadowMiniBoss;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.NPCs.ShadowMiniBoss
{
	[AutoloadBossHead]
	public class ShadowMiniBoss : ModNPC
	{

		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shadow Wraith");
		}

		public override void SetDefaults() 
		{
			npc.aiStyle = 56;
			npc.lifeMax = 45000;
			npc.damage = 200;
			npc.defense = 32;
			npc.knockBackResist = 0f;
			npc.width = 28;
			npc.height = 52;
			npc.value = Item.buyPrice(0, 18, 0, 0);
			npc.npcSlots = 2f;
			npc.boss = true;
			npc.lavaImmune = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath6;
			music = 25;
			npc.scale = 1.5f;
			
			npc.buffImmune[20] = true;
			npc.buffImmune[70] = true;
			npc.buffImmune[31] = true;
			npc.buffImmune[24] = true;
			npc.buffImmune[44] = true;
			npc.buffImmune[30] = true;
			npc.buffImmune[69] = true;
		}
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) 
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}
		
		public override void NPCLoot() 
		{
			Item.NewItem(npc.getRect(), ItemType<ShadowChunk>(), 15);
		}

		public override void OnHitPlayer(Player player, int damage, bool crit) 
		{
			if (Main.rand.NextBool(3)) 
			{
				player.AddBuff(BuffID.Darkness, 600, true);
			}
		}
	}
}