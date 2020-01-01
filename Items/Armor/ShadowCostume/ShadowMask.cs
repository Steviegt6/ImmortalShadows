using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ImmortalShadows.Items.Armor.ShadowCostume
{
	[AutoloadEquip(EquipType.Head)]
	public class ShadowMask : ModItem
	{
		public override void SetDefaults() 
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(silver: 20);
			item.rare = 1;
			item.vanity = true;
		}
		
		public override bool DrawHead() 
		{
			return false;
		}
	}
}