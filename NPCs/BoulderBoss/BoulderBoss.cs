using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using System.IO;
using Terraria.ModLoader;
using ImmortalShadows.Items.BoulderBoss;
using ImmortalShadows.Items.Placeable;
using ImmortalShadows.Items.Armor.Masks;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.NPCs.BoulderBoss
{
	[AutoloadBossHead]
	public class BoulderBoss : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sentient Boulder");
		}

		public override void SetDefaults()
		{
			aiType = NPCID.Tumbleweed;
			npc.aiStyle = 26;
			npc.width = 32;
			npc.height = 34;
			npc.damage = 64;
			npc.defense = 10;
			npc.lifeMax = 400;
			npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath3;
			npc.value = Item.buyPrice(0, 0, 75, 0);
			npc.knockBackResist = 0f;
			npc.boss = true;
			npc.lavaImmune = true;
			npc.behindTiles = true;
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/AM2R/musArachnus");

			npc.buffImmune[BuffID.Confused] = true;
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
				Item.NewItem(npc.getRect(), ItemType<BoulderBossTrophy>());
			}
			else 
			{
				if (Main.rand.NextBool(7))
				{
					Item.NewItem(npc.getRect(), ItemType<BoulderBossMask>());
				}
				Item.NewItem(npc.getRect(), ItemType<BoulderMaterial>(), 10);
				Item.NewItem(npc.getRect(), ItemID.StoneBlock, 6);
			}
			if (!ShadowWorld.downedBoulderBoss)
			{
				ShadowWorld.downedBoulderBoss = true;
				if (Main.netMode == NetmodeID.Server)
				{
					NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
				}
			}
		}
	}
} 
