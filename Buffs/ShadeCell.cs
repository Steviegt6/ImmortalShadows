using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ImmortalShadows.Buffs
{
	public class ShadeCell : ModBuff
	{
		public override void SetDefaults() 
		{
			DisplayName.SetDefault("Shade Cell");
			Description.SetDefault("The shade cell will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) 
		{
			ShadowPlayer modPlayer = player.GetModPlayer<ShadowPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("ShadeCell")] > 0) 
			{
				modPlayer.shadowMinion = true;
			}
			if (!modPlayer.shadowMinion) 
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else 
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}