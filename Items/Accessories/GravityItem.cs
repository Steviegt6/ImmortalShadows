using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ImmortalShadows.Items.Accessories
{
    public class GravityItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gravity Globe EX");
            Tooltip.SetDefault("Gravity no longer affects you");
        }
        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 26;
            item.value = Item.sellPrice(gold: 30);
            item.rare = 12;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            Player.jumpHeight = 20;
			player.noFallDmg = true;
			player.gravity = 0;
			player.canCarpet = false;
			player.rocketTime = 0;
			player.wingTime = 0f;
			player.maxRunSpeed = 10f;
			player.maxFallSpeed = 20f;
			if (player.controlUp || player.controlJump)
			{
				if (player.velocity.Y > 0f)
				{
					player.velocity.Y = 0f;
				}
				if (player.velocity.Y < -10f)
				{
					player.velocity.Y -= 0.03f;
				}
				else{player.velocity.Y -= 0.5f;}
			}
			else if (player.controlDown)
			{
				if (player.velocity.Y < 0f)
				{
					player.velocity.Y = 0f;
				}
				if (player.velocity.Y > 10f)
				{
					player.velocity.Y += 0.03f;
				}
				else{player.velocity.Y += 0.5f;}
			}
			else
			{
				player.velocity.Y = 0f;
			}
			if (player.controlLeft && !player.controlRight)
			{
				if (player.velocity.X > 0f)
				{
					player.velocity.X = 0f;
				}
				if (player.velocity.X < -10f)
				{
					player.velocity.X -= 0.03f;
				}
				else{player.velocity.X -= 0.5f;}
			}
			else if (player.controlRight && !player.controlLeft)
			{
				if (player.velocity.X < 0f)
				{
					player.velocity.X = 0f;
				}
				if (player.velocity.X > 10f)
				{
					player.velocity.X += 0.03f;
				}
				else{player.velocity.X += 0.5f;}
			}
			else
			{
				player.velocity.X = 0f;
			}
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe (mod);
			recipe.AddIngredient(ItemID.GravityGlobe, 2);
			recipe.AddIngredient(mod.ItemType("ShadowChunk"), 30);
			recipe.AddIngredient(ItemID.LunarBar, 15);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
