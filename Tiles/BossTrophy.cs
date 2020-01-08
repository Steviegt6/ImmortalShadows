using ImmortalShadows.Items.Placeable;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Tiles
{
	public class BossTrophy : ModTile
	{
		public override void SetDefaults() 
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleWrapLimit = 36;
			TileObjectData.addTile(Type);
			dustType = 7;
			disableSmartCursor = true;
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Trophy");
			AddMapEntry(new Color(120, 85, 60), name);
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY) 
		{
			int item = 0;
			switch (frameX / 54) 
			{
				case 0:
					item = ItemType<ShadowAmalgTrophy>();
					break;
				case 1:
					item = ItemType<BoulderBossTrophy>();
					break;
			}
			if (item > 0) 
			{
				Item.NewItem(i * 16, j * 16, 48, 48, item);
			}
		}
	}
}