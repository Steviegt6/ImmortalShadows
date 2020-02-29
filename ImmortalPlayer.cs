using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ImmortalShadows
{
	public class ImmortalPlayer : ModPlayer
	{
		public bool shadowLightPet;
		public bool shadowMinion;
		public bool babyMpet;

		public bool darkFlame = false;

		public override void ResetEffects()
		{
			shadowLightPet = false;
			shadowMinion = false;
			babyMpet = false;

			darkFlame = false;
	    }

		public override void UpdateDead()
		{
			darkFlame = false;
	    }

		public override void UpdateBadLifeRegen()
		{
			if (darkFlame)
			{
				if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				player.lifeRegen -= 50;
			}
		}		
	}  
}