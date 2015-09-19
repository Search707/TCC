using UnityEngine;
using System;
using System.Collections;

public class BattleSoloPlayerActionManager : MonoBehaviour
{
	public event Action<ShipGun> onSelectPlayerShipGun;
	public event Action<PlayerAction, ShipGun> onSetPlayerBattleAction;
    public event Action<ShipGun> onRemovePlayerBattleAction;

	public enum PlayerAction
	{
		IDLE,
		ATTACK,
		CAST_SPELL
	}

	public void DelegatePlayerAction(BattleSoloSceneManager.SceneStatus p_sceneStatus, BattleSoloInputManager.PlayerTouchInput p_touchInput, GameObject p_objectTouched)
	{
        switch (p_touchInput)
		{
			case BattleSoloInputManager.PlayerTouchInput.SHIP_GUN:
				OnTouchShipGun(p_sceneStatus, p_objectTouched.GetComponent<ShipGun>());
			break;
            case BattleSoloInputManager.PlayerTouchInput.REMOVE_TARGET:
                OnTouchRemoveTarget(p_sceneStatus, p_objectTouched);
            break;
		}
	}

	private void OnTouchShipGun(BattleSoloSceneManager.SceneStatus p_sceneStatus, ShipGun p_shipGun)
	{
		switch(p_shipGun.owner)
		{
			case Ship.Owner.PLAYER:
				switch(p_sceneStatus)
				{
					case BattleSoloSceneManager.SceneStatus.IDLE:
					case BattleSoloSceneManager.SceneStatus.PLAYER_SHIP_GUN_SELECTED:
						if(onSelectPlayerShipGun != null) onSelectPlayerShipGun(p_shipGun);
					break;
				}
			break;
			case Ship.Owner.FOE:
				switch(p_sceneStatus)
				{
					case BattleSoloSceneManager.SceneStatus.PLAYER_SHIP_GUN_SELECTED:
						if(onSetPlayerBattleAction != null) onSetPlayerBattleAction(PlayerAction.ATTACK, p_shipGun);
					break;
				}
			break;
		}
	}

    private void OnTouchRemoveTarget(BattleSoloSceneManager.SceneStatus p_sceneStatus, GameObject p_removeTarget)
    {
        switch (p_sceneStatus)
        {
            case BattleSoloSceneManager.SceneStatus.IDLE:
                ShipGunSight __shipGunTarget = p_removeTarget.transform.parent.GetComponent<ShipGunSight>();

                __shipGunTarget.targetDisplay.SetPosition(1, __shipGunTarget.transform.position);
                __shipGunTarget.transform.GetChild(0).gameObject.SetActive(false);

                if (onRemovePlayerBattleAction != null) onRemovePlayerBattleAction(__shipGunTarget.shipGun);
            break;
        }
    }
}
