using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows
{
	public class ImmortalNPC : GlobalNPC
    {
        public bool darkFlame = false;

		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}

		public override void ResetEffects(NPC npc)
		{
			darkFlame = false;
		}

		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			if (darkFlame)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 1600;
				if (damage < 2)
				{
					damage = 200;
				}
			}
		}

		public override void DrawEffects(NPC npc, ref Color drawColor)
		{
			if (darkFlame)
			{
				if (Main.rand.Next(4) < 3)
				{
					int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, DustType<Dusts.DarkFlame>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					if (Main.rand.Next(4) == 0)
					{
						Main.dust[dust].noGravity = false;
						Main.dust[dust].scale *= 0.5f;
					}
				}
				Lighting.AddLight(npc.position, 0.1f, 0.2f, 0.7f);
			}
		}
	}
}