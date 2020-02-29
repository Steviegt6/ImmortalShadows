using System;
using ImmortalShadows.Items.ShadowAmalg;
using ImmortalShadows.Tiles;
using ImmortalShadows.Items;
using ImmortalShadows.Items.Placeable;
using ImmortalShadows.Items.Weapons;
using ImmortalShadows.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.NPCs.ShadowAmalg
{
	[AutoloadHead]
	public class ShadowNPC : ModNPC
	{
		public override string Texture => "ImmortalShadows/NPCs/ShadowAmalg/ShadowNPC";
		
		public override bool Autoload(ref string name) 
		{
			name = "Shadow Amalgamation";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shadow Amalgamation");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 1000;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 60;
			NPCID.Sets.AttackAverageChance[npc.type] = 66;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults() 
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 70;
			npc.defense = 35;
			npc.lifeMax = 750;
			npc.HitSound = SoundID.NPCHit54;
			npc.DeathSound = SoundID.NPCDeath59;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;

			npc.buffImmune[BuffID.ShadowFlame] = true;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, DustType<Dusts.ShadowDust>());
			}
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money) 
		{
			if (ImmortalWorld.downedShadowAmalg)
			{
				return true;
			}
			return false;
		}

		public override string TownNPCName() 
		{
			switch (WorldGen.genRand.Next(4)) 
			{
				case 0:
					return "Shayde";
				case 1:
					return "Shayde";
				case 2:
					return "Shayde";
				default:
					return "Shayde";
			}
		}

		public override void FindFrame(int frameHeight) 
		{
			/*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
		}

		public override string GetChat() 
		{
			int Guide = NPC.FindFirstNPC(NPCID.Guide);
			if (Guide >= 0 && Main.rand.NextBool(4)) 
			{
				return "That " + Main.npc[Guide].GivenName + " guy is useless. Why do you keep him around?";
			} 
			switch (Main.rand.Next(4)) 
			{
				case 0:
					return "Something isn't right in this world.";
				case 1:
					return "What do you want?";
				case 2:
					return "Wait, I've already been replaced? Who's this 'Dark Amalgamation'?";
				default:
					return "Why don't I have wings anymore? None of your business.";
			}
		}
		
		public override void SetChatButtons(ref string button, ref string button2) 
		{
			button = Language.GetTextValue("LegacyInterface.28");
		}
		
		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if(firstButton)
			{
				shop = true;
			}
		}
		public override void SetupShop(Chest shop, ref int nextSlot) 
		{
			shop.item[nextSlot].SetDefaults(ItemID.LunarOre);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.FragmentSolar);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.FragmentNebula);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.FragmentVortex);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.FragmentStardust);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<Items.Weapons.ShadowBullet>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<Items.Weapons.ShadowArrow>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<ShadowHealPotion>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<ShadowBuffPotion>());
			nextSlot++;
		}

		public override void NPCLoot() 
		{
			Item.NewItem(npc.getRect(), ItemType<ShadowChunk>());
		}

		public override bool CanGoToStatue(bool toKingStatue) 
		{
			return true;
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback) 
		{
			damage = 70;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) 
		{
			cooldown = 12;
			randExtraCooldown = 20;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay) 
		{			
			projType = ProjectileType<Projectiles.ShadowNPCproj>();
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) 
		{
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}
