using UnityEngine;
using System.Collections;

public class PlayModeCtr : MonoBehaviour {

	public BaseModeLevel modeLevel;

	public ButtonModeCtr easyBtn;
	public ButtonModeCtr normalBtn;
	public ButtonModeCtr hardBtn;

	void Start()
	{
		modeLevel = BaseModeLevel.EASY;
		HandleButtonModeClick (1);

		GamePlayController.Instance.baseModeLevel = modeLevel;
	}

	public void HandleButtonModeClick(int mode)
	{
		DisableAll ();
		switch (mode) {
		case 1:// easy
			easyBtn.ActiveButton();
			modeLevel = BaseModeLevel.EASY;
			break;
		case 2:
			normalBtn.ActiveButton();
			modeLevel = BaseModeLevel.NORMAL;
			break;
		case 3:
			hardBtn.ActiveButton();
			modeLevel = BaseModeLevel.HARD;
			break;
		default:
			break;
		}
		GamePlayController.Instance.canChangeWord = true;
		GamePlayController.Instance.baseModeLevel = modeLevel;
	}

	public void DisableAll()
	{
		easyBtn.DisActiveButton ();
		normalBtn.DisActiveButton ();
		hardBtn.DisActiveButton ();
	}
}
