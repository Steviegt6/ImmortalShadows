using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
                        shop.item[nextSlot].SetDefaults(mod.ItemType("BasicBlade"));
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
                        shop.item[nextSlot].SetDefaults(mod.ItemType("BasicBlade"));  
                        nextSlot++;
                    }

                    break;
            }
        }
    }
}
