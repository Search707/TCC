using UnityEngine;
using System.Collections;

public class Town : MonoBehaviour
{
	public TownGuiManager guiManager;
	public TownInputManager inputManager;

	void Start()
	{
		Debug.Log("Start Town.");

		//------------------------GuiManager---------------------------

		guiManager.onClickUIButton += HandleOnClickUIButton;
		guiManager.onClickPanelButton += HandleOnClickPanelButton;

		//------------------------InputManager---------------------------

		inputManager.onTouchBuilding += HandleOnTouchBuilding;

	}

	private void HandleOnClickPanelButton (TownGuiManager.PanelButtons p_buttonEnum)
	{
		switch(p_buttonEnum)
		{
			case TownGuiManager.PanelButtons.HIRE_ARCHER:
			break;
			case TownGuiManager.PanelButtons.HIRE_WARRIOR:
			break;
		}
	}

	private void HandleOnClickUIButton (TownGuiManager.UIButtons p_buttonEnum)
	{
		switch(p_buttonEnum)
		{
			case TownGuiManager.UIButtons.GAME_WORLD:
				Debug.Log("Go to game world.");
			break;
		}
	}

	private void HandleOnTouchBuilding (Building p_building)
	{
		switch(p_building.buildingType)
		{
			case Building.BuildingType.NONE:
				Debug.Log("NONE");
			break;
			case Building.BuildingType.MERCENARY_GUILD:
				Debug.Log("MERCENARY_GUILD");
			break;
		}
	}
}
