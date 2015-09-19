using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour
{
	public enum BuildingType
	{
		NONE,
		MERCENARY_GUILD
	}

	public BuildingType buildingType = BuildingType.NONE;
}
