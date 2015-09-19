using UnityEngine;
using System;
using System.Collections;

public class TownInputManager : MonoBehaviour
{
	public event Action<Building> onTouchBuilding;

	private RaycastHit2D _hit;

	void Update()
	{
		if(Input.GetMouseButtonUp(0))
		{
			_hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);

			if (_hit.transform == null)
				return;

			switch(_hit.transform.tag)
			{
				case "Building":
					if(onTouchBuilding != null) onTouchBuilding(_hit.transform.GetComponent<Building>());
				break;
			}
		}
	}
}
