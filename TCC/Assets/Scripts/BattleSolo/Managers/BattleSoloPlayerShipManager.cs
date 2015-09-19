using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleSoloPlayerShipManager : MonoBehaviour
{
	public Ship playerShip;

	private ShipGun _selectedShipGun; public ShipGun selectedShipGun{ get{ return _selectedShipGun; } }

	public void SetSelectedShipGun(ShipGun p_shipGun)
	{
		if (_selectedShipGun == null)
		{
			_selectedShipGun = p_shipGun;
			p_shipGun.Highlight();
		} 
		else
		{
			_selectedShipGun.DefaultLight();

			_selectedShipGun = p_shipGun;
			p_shipGun.Highlight();
		}
	}

	public int GetTotalActionsBonus()
	{
		return playerShip.captain.bonusActions;
	}
}
