using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows.NPCs
{
    public class VanillaNPCShop : GlobalNPC
    {
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            switch (type)
            {
                case NPCID.Merchant:

                    if (Main.hardMode)
                    {
                        shop.item[nextSlot].SetDefaults(ItemType<Items.Weapons.BasicBlade>());
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemID.BreakerBlade);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemID.ClockworkAssaultRifle);
                        nextSlot++;
                        shop.item[nextSlot].SetDefaults(ItemID.LaserRifle);
                        nextSlot++;
                    }
                    else
                    {   
                        shop.item[nextSlot].SetDefaults(ItemType<Items.Weapons.BasicBlade>());  
                        nextSlot++;
                    }

                    break;
            }
        }
    }
}
