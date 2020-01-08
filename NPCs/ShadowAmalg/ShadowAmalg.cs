using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using System.IO;
using Terraria.ModLoader;
using ImmortalShadows.Items.ShadowAmalg;
using ImmortalShadows.Items.Placeable;
using ImmortalShadows.Items.Armor.Masks;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.NPCs.ShadowAmalg
{
	[AutoloadBossHead]
	public class ShadowAmalg : ModNPC
	{

		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shadow Amalgamation");
		}

		public override void SetDefaults() 
		{
			npc.aiStyle = 56;
			npc.lifeMax = 50000;
			npc.damage = 250;
			npc.defense = 50;
			npc.knockBackResist = 0f;
			npc.width = 28;
			npc.height = 52;
			npc.value = Item.buyPrice(0, 18, 0, 0);
			npc.boss = true;
			npc.lavaImmune = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit54;
			npc.DeathSound = SoundID.NPCDeath59;
			npc.scale = 1.5f;
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/AM2R/musGenesis");
			
			npc.buffImmune[20] = true;
			npc.buffImmune[70] = true;
			npc.buffImmune[31] = true;
			npc.buffImmune[24] = true;
			npc.buffImmune[44] = true;
			npc.buffImmune[30] = true;
			npc.buffImmune[69] = true;
			npc.buffImmune[153] = true;
		}
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) 
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}

		public override void NPCLoot()
		{
			if (Main.rand.NextBool(10))
			{
				Item.NewItem(npc.getRect(), ItemType<ShadowAmalgTrophy>());
			}
			else 
			{
				if (Main.rand.NextBool(7))
				{
					Item.NewItem(npc.getRect(), ItemType<ShadowAmalgMask>());
				}
				Item.NewItem(npc.getRect(), ItemType<ShadowChunk>(), 18 + Main.rand.Next(8));
				Item.NewItem(npc.getRect(), ItemID.SuperHealingPotion, 5 + Main.rand.Next(6));
			}
			if (!ShadowWorld.downedShadowAmalg)
			{
				ShadowWorld.downedShadowAmalg = true;
				if (Main.netMode == NetmodeID.Server)
				{
					NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
				}
			}
		}

		public override void OnHitPlayer(Player player, int damage, bool crit) 
		{
			if (Main.rand.NextBool(3)) 
			{
				player.AddBuff(BuffID.Blackout, 300, true);
				player.AddBuff(BuffID.Slow, 300);
				player.AddBuff(BuffID.ShadowFlame, 120);
			}
		}
	}
}