using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ExampleMod.Items
{
	class InfiniteChestKey : ModItem
	{
		public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Infinite Golden Key");
            Tooltip.SetDefault("Unlock ALL of the chests!"
			    + "\nNot consumable");
        }	
		
		public override void SetDefaults() 
		{
			item.CloneDefaults(ItemID.GoldenKey);
			item.width = 14;
			item.height = 20;
			item.maxStack = 1;
			item.consumable = false;
			item.rare = 1;
			item.value = Item.sellPrice(silver: 10);
		}
	}
}
