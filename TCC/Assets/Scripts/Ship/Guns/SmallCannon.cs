using UnityEngine;
using System.Collections;

public class SmallCannon : ShipGun
{
	void Start()
	{
		_shipGunType = Type.SMALL_CANNON;

		_maxHp = GameData.SmallCannon.maxHp;
		_baseDamage = GameData.SmallCannon.baseDamage;
		_actionTime = GameData.SmallCannon.actionTime;
	}
}
