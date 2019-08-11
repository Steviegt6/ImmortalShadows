using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ImmortalShadows.Tiles
{
	public class ShadeStone : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			drop = mod.ItemType("ShadeStone");
			AddMapEntry(new Color(13, 13, 13));
			minPick = 200;
		}
	}
}