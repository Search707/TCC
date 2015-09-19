using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MercenaryGuild : Building
{
	private List<int> _mercenaryPrices = new List<int>(2){ 500, 550 };

	public bool HireNewMercenary(Character.CharacterClass p_characterClass)
	{
		if(PlayerData.playerGold < _mercenaryPrices[(int)p_characterClass])
		{
			return false;
		}

		return true;
	}
}
