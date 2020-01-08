using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ImmortalShadows.NPCs
{
	public class RoboZombie : ModNPC
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Mechanical Zombie");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
		}

		public override void SetDefaults() 
		{
			npc.width = 18;
			npc.height = 40;
			npc.damage = 20;
			npc.defense = 10;
			npc.lifeMax = 60;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath14;
			npc.value = 60f;
			npc.knockBackResist = 0.7f;
			npc.aiStyle = 3;
			aiType = NPCID.Zombie;
			animationType = NPCID.Zombie;
			banner = Item.NPCtoBanner(NPCID.Zombie);
			bannerItem = Item.BannerToItem(banner);
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.6f);
		}

		public override void NPCLoot()
        {
	        Item.NewItem(npc.getRect(), ItemID.StoneBlock, 6);
        }
	}
}
