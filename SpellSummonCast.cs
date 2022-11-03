using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThunderRoad; // Required

namespace SummonSpell
{
	public class SpellSummonCast : SpellCastCharge
	{
		// The ID of the item you want to spawn
		public string ItemID = "DaggerCommon";
		                       // ^^This is the Daggers item ID
		public override void Fire(bool active)
		{
			base.Fire(active);
			if (active)
			{
				Catalog.GetData<ItemData>(ItemID).SpawnAsync(i =>
				{
					i.transform.position = spellCaster.ragdollHand.transform.position;

					// Grabs the items handle when it's summoned 
					spellCaster.ragdollHand.Grab(i.GetMainHandle(spellCaster.ragdollHand.side));

					// This is so after the item is summoned the spell isn't still there
					Fire(false);
					spellCaster.isFiring = false;
					currentCharge = 0;
				});
			}
		}
	}
}


