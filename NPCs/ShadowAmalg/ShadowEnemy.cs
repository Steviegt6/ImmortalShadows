using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.NPCs.ShadowAmalg
{
    public class ShadowEnemy : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Orb");
        }

        public override void SetDefaults()
        {
            npc.width = 26;
            npc.height = 26;
            npc.aiStyle = 44;
            npc.aiStyle = 5;
            npc.damage = 94;
            npc.defense = 10;
            npc.lifeMax = 5000;
            npc.HitSound = SoundID.NPCHit2;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.knockBackResist = 0f;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;

            npc.buffImmune[BuffID.Confused] = true;
            npc.buffImmune[BuffID.OnFire] = true;
            npc.buffImmune[BuffID.ShadowFlame] = true;
        }
    }
}