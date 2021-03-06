using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.Items
{
	public class ShadowLightPet : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Shadow Tentacle");
			Tooltip.SetDefault("Summons a dark eye to provide light"
			    + "\nIt also gives you +50 max life");
		}

		public override void SetDefaults() 
		{
			item.damage = 0;
			item.useStyle = 1;
			item.shoot = ProjectileType<Projectiles.Pets.ShadowLightPet>();
			item.width = 26;
			item.height = 28;
			item.UseSound = SoundID.Item2;
			item.useAnimation = 20;
			item.useTime = 20;
			item.rare = 11;
			item.expert = true;
			item.noMelee = true;
			item.value = Item.sellPrice(gold: 12);
			item.buffType = BuffType<Buffs.ShadowLightPet>();
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SuspiciousLookingTentacle);
			recipe.AddIngredient(ItemType<ShadowAmalg.ShadowChunk>(), 14);
			recipe.AddIngredient(ItemID.LifeFruit, 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void UseStyle(Player player) 
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) 
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}