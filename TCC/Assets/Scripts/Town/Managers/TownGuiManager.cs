using UnityEngine;
using UnityEngine.UI;

using System;
using System.Collections;
using System.Collections.Generic;

public class TownGuiManager : MonoBehaviour
{
	public enum UIButtons
	{
		GAME_WORLD
	}

	public enum Panels
	{
		HIRE_MERCENARIES
	}

	public enum PanelButtons
	{
		HIRE_WARRIOR,
		HIRE_ARCHER
	}

	public event Action<UIButtons> onClickUIButton;
	public event Action<PanelButtons> onClickPanelButton;

	public List<Panel> _gameGUIPanels = new List<Panel> ();

	public void OnClickGuiBtn(Button p_button)
	{
		switch(p_button.tag)
		{
			case "UIButton":
				OnClickUIButton(p_button);
			break;
			case "Panel":
				OnClickPanelButton(p_button);
			break;
		}
	}

	private void OnClickUIButton(Button p_button)
	{
		switch(p_button.name)
		{
			case "GameWorld":
				if(onClickUIButton != null) onClickUIButton(UIButtons.GAME_WORLD);
			break;
		}
	}

	private void OnClickPanelButton(Button p_button)
	{
		switch(p_button.name)
		{
			case "HireWarrior":
				if(onClickPanelButton != null) onClickPanelButton(PanelButtons.HIRE_WARRIOR);
			break;
			case "HireArcher":
				if(onClickPanelButton != null) onClickPanelButton(PanelButtons.HIRE_ARCHER);
			break;
		}
	}
}
