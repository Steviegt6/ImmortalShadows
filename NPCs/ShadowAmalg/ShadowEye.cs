using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.NPCs.ShadowAmalg
{
    [AutoloadBossHead]
    public class ShadowEye : ModNPC
    {
        private Player player;
        private float speed;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Eye");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.EyeofCthulhu];
        }


        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            if (NPC.downedMoonlord)
            {
                npc.lifeMax = 28000;
                npc.damage = 90;
                npc.defense = 18;
            }
            else
            {
                npc.lifeMax = 16000;
                npc.damage = 50;
                npc.defense = 5;
            }
            npc.knockBackResist = 0f;
            npc.width = 100;
            npc.height = 100;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit13;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.boss = true;
            music = MusicID.GoblinInvasion;

            npc.buffImmune[BuffID.Poisoned] = true;
            npc.buffImmune[BuffID.Confused] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.ShadowFlame] = true;

            bossBag = ItemType<Items.ShadowAmalg.ShadowEyeBag>();
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            if (NPC.downedMoonlord)
            {
                npc.lifeMax = 48000;
                npc.damage = 170;
                npc.defense = 24;
            }
            else
            {
                npc.lifeMax = 32000;
                npc.damage = 90;
                npc.defense = 8;
            }
        }

        public override void AI()
        {
            Target();

            DespawnHandler();

            Move(new Vector2(0, -100f));
            npc.ai[1] -= 1f;
            if (npc.ai[1] <= 0f)
            {
                Shoot();
            }
        }

        private void Target()
        {
            player = Main.player[npc.target];
        }

        private void Move(Vector2 offset)
        {
            speed = 8f;
            Vector2 moveTo = player.Center + offset;
            Vector2 move = moveTo - npc.Center;
            float magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            float turnResistance = 10f;
            move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
            magnitude = Magnitude(move);
            if (magnitude > speed)
            {
                move *= speed / magnitude;
            }
            npc.velocity = move;
        }

        private void DespawnHandler()
        {
            if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
                if (!player.active || player.dead)
                {
                    npc.velocity = new Vector2(0f, -10f);
                    if (npc.timeLeft > 10)
                    {
                        npc.timeLeft = 10;
                    }
                    return;
                }
            }
        }

        private void Shoot()
        {
            int type = ProjectileType<Projectiles.ShadowEyeProj>();
            Main.PlaySound(SoundID.Item33);
            Vector2 velocity = player.Center - npc.Center;
            float magnitude = Magnitude(velocity);
            if (magnitude > 0)
            {
                velocity *= 20f / magnitude;
            }
            else
            {
                velocity = new Vector2(0f, 5f);
            }
            Projectile.NewProjectile(npc.Center, velocity, type, npc.damage, 1f);
            npc.ai[1] = 200f;
        }

        private float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 1;
            npc.frameCounter %= 20;
            int frame = (int)(npc.frameCounter / 2.0);
            if (frame >= Main.npcFrameCount[npc.type]) frame = 0;
            npc.frame.Y = frame * frameHeight;

            RotateNPCToTarget();
        }

        private void RotateNPCToTarget()
        {
            if (player == null) return;
            Vector2 direction = npc.Center - player.Center;
            float rotation = (float)Math.Atan2(direction.Y, direction.X);
            npc.rotation = rotation + ((float)Math.PI * 0.5f);
        }

        public override void NPCLoot()
        {
            if (Main.rand.NextBool(10))
            {
                Item.NewItem(npc.getRect(), ItemType<Items.Placeable.ShadowEyeTrophy>());
            }
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {
                if (Main.rand.NextBool(7))
                {
                    Item.NewItem(npc.getRect(), ItemType<Items.Armor.Masks.ShadowEyeMask>());
                }
                Item.NewItem(npc.getRect(), ItemID.SoulofNight, 16 + Main.rand.Next(15));
            }
            if (!ImmortalWorld.downedShadowEye)
            {
                ImmortalWorld.downedShadowEye = true;
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.WorldData);
                }
            }
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.GreaterHealingPotion;
        }
    }
}