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
				+ "\nIncreases max life by 25"
				+ "\n10% increased critical strike chance"
				+ "\n10% increased damage"
				+ "\n+1 max minions");
				
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 10;
			
			player.lifeRegen += 4;
			
			player.moveSpeed += 0.50f;
			
			player.gills = true;
			
			player.statLifeMax2 += 25;

            player.allDamage += 0.10f;
			
			player.maxMinions += 1;

            player.meleeCrit += 10;
            player.rangedCrit += 10;
            player.thrownCrit += 10;
            player.magicCrit += 10;

        }
    }
}
