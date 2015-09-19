using UnityEngine;
using System;
using System.Collections;

public class BattleSoloInputManager : MonoBehaviour
{
	public event Action<PlayerTouchInput, GameObject> onTouchUp;

	public enum PlayerTouchInput
	{
		SHIP_GUN,
        REMOVE_TARGET
	}

	private RaycastHit2D _hit;

	void Update()
	{
		if(Input.GetMouseButtonUp(0))
		{
			 _hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up);

			if (_hit.transform != null)
			{
				Touchble __touchble = _hit.transform.GetComponent<Touchble>();

				if(__touchble != null && __touchble.canTouch)
				{
					switch(_hit.transform.tag)
					{
						case "ShipGun":
							if(onTouchUp != null) onTouchUp(PlayerTouchInput.SHIP_GUN, _hit.transform.gameObject);
						break;
                        case "RemoveTargetDisplay":
                            if (onTouchUp != null) onTouchUp(PlayerTouchInput.REMOVE_TARGET, _hit.transform.gameObject);
                        break;
					}
				}
			}
		}
	}
}
