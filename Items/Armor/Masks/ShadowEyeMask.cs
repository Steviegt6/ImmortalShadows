using Terraria.ModLoader;

namespace ImmortalShadows.Items.Armor.Masks
{
    [AutoloadEquip(EquipType.Head)]
    public class ShadowEyeMask : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Eye Mask");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 20;
			item.rare = 1;
			item.vanity = true;
		}

		public override bool DrawHead()
		{
			return false;
		}
	}
}