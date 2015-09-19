using UnityEngine;
using System.Collections;

public class BattleSolo : MonoBehaviour
{
	public BattleSoloSceneManager sceneManager;
	public BattleSoloGuiManager guiManager;
	public BattleSoloInputManager inputManager;
	public BattleSoloPlayerActionManager playerActionManager;
	public BattleSoloPlayerShipManager playerShipManager;
	public BattleSoloFoeShipManager foeShipManager;
	public BattleSoloBattleManager battleManager;

    private int _startActionsAvaliable = 2;

	void Start()
	{
		//-----INPUT-----
		inputManager.onTouchUp += HandleOnTouchUp;

        //-----GUI-----
        guiManager.onClickStartButton += HandleOnClickStartButton;

		//-----PLAYER ACTION-----
		playerActionManager.onSelectPlayerShipGun += HandleOnSelectPlayerShipGun;
		playerActionManager.onSetPlayerBattleAction += HandleOnSetPlayerBattleAction;
        playerActionManager.onRemovePlayerBattleAction += HandleOnRemovePlayerBattleAction;

		//----BATTLE ACTION----
		battleManager.onPlayerBattleActionSeted += HandleOnPlayerBattleActionSeted;
        battleManager.onPlayerBattleActionRemoved += HandleOnPlayerBattleActionRemoved;
        battleManager.onPlayerBattleActionsFull += HandleOnPlayerBattleActionsFull;
	}

    //-----------------------------HANDLERS-----------------------------

    //--------INPUT-----------

    void HandleOnTouchUp(BattleSoloInputManager.PlayerTouchInput p_touchInput, GameObject p_objectTouched)
    {
        playerActionManager.DelegatePlayerAction(sceneManager.sceneStatus, p_touchInput, p_objectTouched);
    }

    //--------GUI-----------

    void HandleOnClickStartButton()
    {
        Debug.Log("Start Turn");
    }

    //-----PLAYER ACTION-----

    void HandleOnSelectPlayerShipGun(ShipGun p_shipGun)
    {
        playerShipManager.SetSelectedShipGun(p_shipGun);
        sceneManager.sceneStatus = BattleSoloSceneManager.SceneStatus.PLAYER_SHIP_GUN_SELECTED;
        Debug.Log("Player gun selected.");
    }

    void HandleOnSetPlayerBattleAction(BattleSoloPlayerActionManager.PlayerAction p_playerAction, ShipGun p_foeShipGun)
    {
        if (playerShipManager.selectedShipGun.selectionStatus == ShipGun.SelectionStatus.IDLE)
        {
            BattleSoloBattleManager.BattleTurnInfo __battleTurnInfo = new BattleSoloBattleManager.BattleTurnInfo(battleManager.actionIdGiver, p_playerAction, new object[2]{
                playerShipManager.selectedShipGun,
                p_foeShipGun
            });

            battleManager.SetPlayerBattleAction(__battleTurnInfo, playerShipManager.GetTotalActionsBonus() + _startActionsAvaliable);
        }
    }

    void HandleOnRemovePlayerBattleAction(ShipGun p_shipGun)
    {
        battleManager.RemovePlayerBattleAction(p_shipGun);
    }

    //--------BATTLE ACTION-----------

    void HandleOnPlayerBattleActionSeted()
	{
		sceneManager.sceneStatus = BattleSoloSceneManager.SceneStatus.IDLE;
		Debug.Log("Player battle action Attack seted.");
	}

    void HandleOnPlayerBattleActionRemoved()
    {
        guiManager.SetUIButtonActive(BattleSoloGuiManager.UIButtons.START, false);
    }

    void HandleOnPlayerBattleActionsFull()
    {
        guiManager.SetUIButtonActive(BattleSoloGuiManager.UIButtons.START, true);
    }

}
