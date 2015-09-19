using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class BattleSoloBattleManager : MonoBehaviour
{
    public event Action onPlayerBattleActionSeted;
    public event Action onPlayerBattleActionRemoved;
    public event Action onPlayerBattleActionsFull;

    private int _actionIdGiver = 1;
    public int actionIdGiver
    {
        get { return _actionIdGiver; }
    }

	public struct BattleTurnInfo
	{
        public int id;
		public BattleSoloPlayerActionManager.PlayerAction playerAction;
		public object[] actionData;

		public BattleTurnInfo(int p_id, BattleSoloPlayerActionManager.PlayerAction p_playerAction, object[] p_actionData)
		{
            this.id = p_id;
			this.playerAction = p_playerAction;
			this.actionData = p_actionData;
		}
	}

	private List<BattleTurnInfo?> _battleActions { get; set; }

	void Start()
	{
		_battleActions = new List<BattleTurnInfo?>();
	}

	public void SetPlayerBattleAction(BattleTurnInfo p_battleTurnInfo, int p_totalActionsAllowded)
	{
		_battleActions.Add(p_battleTurnInfo);

        ShipGun __playerShipGun = p_battleTurnInfo.actionData[0] as ShipGun;

        __playerShipGun.actionId = _actionIdGiver;

        SetPlayerTargetDisplay (__playerShipGun, p_battleTurnInfo.actionData[1] as ShipGun);
		SetPlayerShipGunSelectionStatus(__playerShipGun, ShipGun.SelectionStatus.ON_QUEUE);

        _actionIdGiver++;
		if(onPlayerBattleActionSeted != null) onPlayerBattleActionSeted();
		if(p_totalActionsAllowded == _battleActions.Count && onPlayerBattleActionsFull != null) onPlayerBattleActionsFull();
	}

    public void RemovePlayerBattleAction(ShipGun p_shipGun)
    {
        BattleTurnInfo? __battleActionToRemove = null;
        
        _battleActions.ForEach(__battleAction => { if (__battleAction.Value.id == p_shipGun.actionId) __battleActionToRemove = __battleAction; });

        if (__battleActionToRemove != null)
        {
            p_shipGun.actionId = 0;
            p_shipGun.selectionStatus = ShipGun.SelectionStatus.IDLE;

            _battleActions.Remove(__battleActionToRemove);
        }

        Debug.Log("Battle action removed");

        if(onPlayerBattleActionRemoved != null) onPlayerBattleActionRemoved();
    }

	private void SetPlayerShipGunSelectionStatus(ShipGun p_playerShipGun, ShipGun.SelectionStatus p_selectionStatus)
	{
		p_playerShipGun.selectionStatus = p_selectionStatus;
		p_playerShipGun.DefaultLight();
	}

	private void SetPlayerTargetDisplay(ShipGun p_playerShipGun, ShipGun p_foeShipGun)
	{
		Debug.Log(p_foeShipGun.shipGunType);

        p_playerShipGun.shipGunTarget.removeTargetDisplay.SetActive(true);

		p_playerShipGun.shipGunTarget.targetDisplay.SetPosition(0, p_playerShipGun.shipGunTarget.transform.position);
		p_playerShipGun.shipGunTarget.targetDisplay.SetPosition(1, p_foeShipGun.shipGunTarget.transform.position);
	}
}
