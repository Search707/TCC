using UnityEngine;
using System.Collections;

public class BattleSoloSceneManager : MonoBehaviour
{
	public enum SceneStatus
	{
		IDLE,
		PLAYER_SHIP_GUN_SELECTED
	}

	public SceneStatus sceneStatus;
}
