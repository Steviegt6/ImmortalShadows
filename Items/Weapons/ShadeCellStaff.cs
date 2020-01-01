using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ImmortalShadows.Items.Weapons
{
	public class ShadeCellStaff : ModItem
	{
		public override void SetStaticDefaults()		
		{
			DisplayName.SetDefault("Shade Cell Staff");
			Tooltip.SetDefault("Summons a shade cell to fight for you.");
		}

		public override void SetDefaults() 
		{
			item.damage = 275;
			item.summon = true;
			item.mana = 10;
			item.width = 44;
			item.height = 44;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.sellPrice(gold: 30);
			item.rare = 11;
			item.UseSound = SoundID.Item44;
			item.shoot = mod.ProjectileType("ShadeCell");
			item.shootSpeed = 10f;
			item.buffType = mod.BuffType("ShadeCell");
			item.buffTime = 3600;
		}

		public override bool AltFunctionUse(Player player) 
		{
			return true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) 
		{
			return player.altFunctionUse != 2;
		}

		public override bool UseItem(Player player) 
		{
			if (player.altFunctionUse == 2) 
			{
				player.MinionNPCTargetAim();
			}
			return base.UseItem(player);
		}
		
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StardustCellStaff);
			recipe.AddIngredient(ItemID.StardustDragonStaff);
			recipe.AddIngredient(mod.ItemType("ShadowChunk"), 30);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
