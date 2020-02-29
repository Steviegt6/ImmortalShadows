using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImmortalShadows.Items.ShadowAmalg;
using ImmortalShadows.Items.Placeable;
using ImmortalShadows.Items.Armor.Masks;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.NPCs.ShadowAmalg.DarkAmalg
{
	[AutoloadBossHead]
	public class DarkAmalg : ModNPC
	{
		private int ai;
		private int attackTimer = 0;
		private bool fastSpeed = false;

		private bool stunned;
		private int stunnedTimer;

		private int frame = 0;
		private double counting;

		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Dark Amalgamation");
			Main.npcFrameCount[npc.type] = 6;
		}

		public override void SetDefaults() 
		{
			npc.width = 24;
			npc.height = 58;
			npc.boss = true;
			npc.aiStyle = -1;
			npc.lifeMax = 70000;
			npc.damage = 170;
			npc.defense = 20;
			npc.knockBackResist = 0f;
			npc.value = Item.buyPrice(gold: 18);
			npc.lavaImmune = true;
			npc.noTileCollide = true;
			npc.noGravity = true;			
			npc.HitSound = SoundID.NPCHit55;
			npc.DeathSound = SoundID.NPCHit54;
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Amalg");
            npc.scale = 1.5f;

			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.Venom] = true;
			npc.buffImmune[BuffID.Confused] = true; 
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Frostburn] = true;
			npc.buffImmune[BuffID.Ichor] = true;
			npc.buffImmune[BuffID.ShadowFlame] = true;
            npc.buffImmune[BuffID.Daybreak] = true;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 100000; /*(int)(npc.lifeMax * 0.75f * bossLifeScale);*/
            npc.damage = 210; /*(int)(npc.damage * 0.75f);*/
            npc.defense = 24;
        }


        public override void AI()
        {
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            npc.rotation = 0.0f;
            npc.netAlways = true;
            npc.TargetClosest(true);
            if (npc.life >= npc.lifeMax)
                npc.life = npc.lifeMax;
            if (npc.target < 0 || npc.target == 255 || player.dead || !player.active)
            {
                npc.TargetClosest(false);
                npc.direction = 1;
                npc.velocity.Y = npc.velocity.Y - 0.1f;
                if (npc.timeLeft > 20)
                {
                    npc.timeLeft = 20;
                    return;
                }
            }
            if (Main.dayTime)
            {
                npc.TargetClosest(false);
                npc.direction = 1;
                npc.velocity.Y = npc.velocity.Y - 0.1f;
                if (npc.timeLeft > 20)
                {
                    npc.timeLeft = 20;
                    return;
                }
            }
            if (stunned)
            {
                npc.velocity.X = 0.0f;
                npc.velocity.Y = 0.0f;
                stunnedTimer++;
                if (stunnedTimer >= 100)
                {
                    stunned = false;
                    stunnedTimer = 0;
                }
            }
            ai++;
            npc.ai[0] = (float)ai * 1f;
            int distance = (int)Vector2.Distance(target, npc.Center);
            if ((double)npc.ai[0] < 300)
            {
                frame = 0;
                MoveTowards(npc, target, (float)(distance > 300 ? 13f : 7f), 30f);
                npc.netUpdate = true;
            }
            else if ((double)npc.ai[0] >= 300 && (double)npc.ai[0] < 450.0)
            {
                stunned = true;
                frame = 1;
                MoveTowards(npc, target, (float)(distance > 300 ? 13f : 7f), 30f);
                npc.netUpdate = true;
            }
            else if ((double)npc.ai[0] >= 450.0)
            {
                frame = 0;
                stunned = false;
                if (!fastSpeed)
                {
                    fastSpeed = true;
                }
                else
                {
                    if ((double)npc.ai[0] % 50 == 0)
                    {
                        float speed = 12f;
                        Vector2 vector = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                        float x = player.position.X + (float)(player.width / 2) - vector.X;
                        float y = player.position.Y + (float)(player.height / 2) - vector.Y;
                        float distance2 = (float)Math.Sqrt(x * x + y * y);
                        float factor = speed / distance2;
                        npc.velocity.X = x * factor;
                        npc.velocity.Y = y * factor;
                    }
                }
                npc.netUpdate = true;
            }
            if ((double)npc.ai[0] % (Main.expertMode ? 100 : 150) == 0 && !stunned && !fastSpeed)
            {
                attackTimer++;
                if (attackTimer <= 2)
                {
                    frame = 2;
                    npc.velocity.X = 0f;
                    npc.velocity.Y = 0f;
                    Vector2 shootPos = npc.Center;
                    float accuracy = 5f * (npc.life / npc.lifeMax);
                    Vector2 shootVel = target - shootPos + new Vector2(Main.rand.NextFloat(-accuracy, accuracy), Main.rand.NextFloat(-accuracy, accuracy));
                    shootVel.Normalize();
                    shootVel *= 7.5f;
                    for (int i = 0; i < (Main.expertMode ? 5 : 3); i++)
                    {
                        Projectile.NewProjectile(shootPos.X + (float)(-100 * npc.direction) + (float)Main.rand.Next(-40, 41), shootPos.Y - (float)Main.rand.Next(-50, 40), shootVel.X, shootVel.Y, ProjectileType<Projectiles.ShadowAmalgProj>(), npc.damage / 3, 5f);
                    }
                }
                else
                {
                    attackTimer = 0;
                }
            }

            if ((double)npc.ai[0] >= 650.0)
            {
                ai = 0;
                npc.alpha = 0;
                npc.ai[2] = 0;
                fastSpeed = false;
            }

        }

        public override void FindFrame(int frameHeight)
        {
            if (frame == 0)
            {
                counting += 1.0;
                if (counting < 8.0)
                {
                    npc.frame.Y = 0;
                }
                else if (counting < 16.0)
                {
                    npc.frame.Y = frameHeight;
                }
                else if (counting < 24.0)
                {
                    npc.frame.Y = frameHeight * 2;
                }
                else if (counting < 32.0)
                {
                    npc.frame.Y = frameHeight * 3;
                }
                else
                {
                    counting = 0.0;
                }
            }
            else if (frame == 1)
            {
                npc.frame.Y = frameHeight * 4;
            }
            else
            {
                npc.frame.Y = frameHeight * 5;
            }
        }

        private void MoveTowards(NPC npc, Vector2 playerTarget, float speed, float turnResistance)
        {
            var move = playerTarget - npc.Center;
            float length = move.Length();
            if (length > speed)
            {
                move *= speed / length;
            }
            move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
            length = move.Length();
            if (length > speed)
            {
                move *= speed / length;
            }
            npc.velocity = move;
        }

		public override void BossLoot(ref string name, ref int potionType)
		{
			potionType = ItemID.SuperHealingPotion;
		}

		public override void OnHitPlayer(Player player, int damage, bool crit) 
		{
			if (Main.rand.NextBool(3)) 
			{
				player.AddBuff(BuffID.Blackout, 300);
                player.AddBuff(BuffType<Buffs.Debuffs.DarkFlame>(), 120);
            }
		}

        public override bool CheckDead()
        {
            npc.active = false;
            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<DarkAmalg2>());
            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, NPCType<ShadowEye>());
            Main.NewText("You are growing increasingly annoying.", 191, 0, 0);
            return false;
        }
    }
}