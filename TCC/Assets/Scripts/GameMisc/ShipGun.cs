using UnityEngine;
using System.Collections;

public class ShipGun : MonoBehaviour
{
	public enum Type
	{
		CANNON,
		SMALL_CANNON
	}

	public enum SelectionStatus
	{
		IDLE,
		ON_QUEUE
	}

	public SelectionStatus selectionStatus{ get; set; }

	protected Ship.Owner _owner; public Ship.Owner owner{ get{ return _owner; } }
	protected Type _shipGunType; public Type shipGunType{ get{ return _shipGunType; } }

	protected int _id;
	protected int _maxHp;
	protected int _baseDamage;
	protected float _actionTime;

    public int actionId;
	public ShipGunSight shipGunTarget;
	public SpriteRenderer sprite;
	public Color highlightColor;

	public void Initialize(int p_id, Ship.Owner p_owner)
	{
		_id = p_id;
		_owner = p_owner;
	}

	public void Highlight()
	{
		sprite.color = highlightColor;
	}

	public void DefaultLight()
	{
		sprite.color = Color.white;
	}
}
