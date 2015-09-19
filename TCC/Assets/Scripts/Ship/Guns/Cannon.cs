using UnityEngine;
using System.Collections;

public class Cannon : ShipGun
{
	void Start()
	{
		_shipGunType = Type.CANNON;

		_maxHp = GameData.Cannon.maxHp;
		_baseDamage = GameData.Cannon.baseDamage;
		_actionTime = GameData.Cannon.actionTime;
	}
}
