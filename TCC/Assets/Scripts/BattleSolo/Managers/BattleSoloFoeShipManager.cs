using UnityEngine;
using System.Collections;

public class BattleSoloFoeShipManager : MonoBehaviour
{
	public Ship foeShip;
	
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
}
