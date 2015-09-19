using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ship : MonoBehaviour
{
	public enum Owner
	{
		PLAYER,
		FOE
	}

	public Captain captain;
	public Transform ShipGuns;
	public Owner owner;

	private int _idGiver = 0;
	private int _hp;
	private Dictionary<int, ShipGun> _shipGuns = new Dictionary<int, ShipGun>();

	void Start()
	{
		LoadCannons ();
	}

	private void LoadCannons()
	{
		foreach(Transform loop_shipGun in ShipGuns)
		{
			ShipGun __shipGun = loop_shipGun.GetComponent<ShipGun>();

			__shipGun.Initialize(_idGiver, owner);

			_shipGuns.Add(_idGiver, __shipGun);
			
			_idGiver++;
		}
	}
}
