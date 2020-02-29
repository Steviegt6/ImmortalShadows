using ImmortalShadows.Items;
using ImmortalShadows.NPCs;
using ImmortalShadows.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using static Terraria.ModLoader.ModContent;

namespace ImmortalShadows
{
	public class ImmortalWorld : ModWorld
	{
		public static bool downedShadowAmalg;
		public static bool downedBoulderBoss;
		public static bool downedShadowEye;

		public override void Initialize() 
		{
			downedShadowAmalg = false;
			downedBoulderBoss = false;
			downedShadowEye = false;
		}

		public override TagCompound Save() 
		{
			var downed = new List<string>();
			if (downedShadowAmalg) 
			{
				downed.Add("shadowAmalg");
			}

			if (downedBoulderBoss)
			{
				downed.Add("boulderBoss");
			}

			if (downedShadowEye)
			{
				downed.Add("downedShadowEye");
			}

			return new TagCompound 
			{
				["downed"] = downed,
			};
		}

		public override void Load(TagCompound tag) 
		{
			var downed = tag.GetList<string>("downed");
			downedShadowAmalg = downed.Contains("shadowAmalg");
			downedBoulderBoss = downed.Contains("boulderBoss");
			downedShadowEye = downed.Contains("downedShadowEye");
		}

		public override void LoadLegacy(BinaryReader reader) 
		{
			int loadVersion = reader.ReadInt32();
			if (loadVersion == 0)
			{
				BitsByte flags = reader.ReadByte();
				downedShadowAmalg = flags[0];
				downedBoulderBoss = flags[1];
				downedShadowEye = flags[2];
			}
			else 
			{
				mod.Logger.WarnFormat("ImmortalShadows: Unknown loadVersion: {0}", loadVersion);
			}
		}

		public override void NetSend(BinaryWriter writer)
		{
			var flags = new BitsByte();
			flags[0] = downedShadowAmalg;
			flags[1] = downedBoulderBoss;
			flags[2] = downedShadowEye;
			writer.Write(flags);

			/*
			Remember that Bytes/BitsByte only have 8 entries. If you have more than 8 flags you want to sync, use multiple BitsByte:

				This is wrong:
			flags[8] = downed9thBoss; // an index of 8 is nonsense. 

				This is correct:
			flags[7] = downed8thBoss;
			writer.Write(flags);
			BitsByte flags2 = new BitsByte(); // create another BitsByte
			flags2[0] = downed9thBoss; // start again from 0
			// up to 7 more flags here
			writer.Write(flags2); // write this byte
			*/

			//If you prefer, you can use the BitsByte constructor approach as well.
			//writer.Write(saveVersion);
			//BitsByte flags = new BitsByte(downedAbomination, downedPuritySpirit);
			//writer.Write(flags);

			// This is another way to do the same thing, but with bitmasks and the bitwise OR assignment operator (the |=)
			// Note that 1 and 2 here are bit masks. The next values in the pattern are 4,8,16,32,64,128. If you require more than 8 flags, make another byte.
			//writer.Write(saveVersion);
			//byte flags = 0;
			//if (downedAbomination)
			//{
			//	flags |= 1;
			//}
			//if (downedPuritySpirit)
			//{
			//	flags |= 2;
			//}
			//writer.Write(flags);
		}

		public override void NetReceive(BinaryReader reader) 
		{
			BitsByte flags = reader.ReadByte();
			downedShadowAmalg = flags[0];
			downedBoulderBoss = flags[1];
			downedShadowEye = flags[2];
			// As mentioned in NetSend, BitBytes can contain 8 values. If you have more, be sure to read the additional data:
			// BitsByte flags2 = reader.ReadByte();
			// downed9thBoss = flags[0];
		}
	}
}
