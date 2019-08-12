using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmortalShadows.Buffs
{
    public class ShadowBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Shadow Power");
            Description.SetDefault("Grants +10 defense"
			    + "\nGrants water breathing"
				+ "\nIncreases life regen"
				+ "\n50% increased movement speed"
				+ "\nIncreases max life by 50"
				+ "\n15% increased critical strike chance"
				+ "\n15% increased damage"
				+ "\n+2 max minions");
				
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 10;
			
			player.lifeRegen += 4;
			
			player.moveSpeed += 0.50f;
			
			player.gills = true;
			
			player.statLifeMax2 += 50;
			
			player.maxMinions += 2;
            player.minionDamage += 0.15f;

            player.meleeCrit += 15;
            player.meleeDamage += 0.15f;

            player.rangedCrit += 15;
            player.rangedDamage += 0.15f;

            player.thrownCrit += 15;
            player.thrownDamage += 0.15f;

            player.magicCrit += 15;
            player.magicDamage += 0.15f;
        }
    }
}
