using UnityEngine;
using System.Collections;
//using Vuforia;

public class UIGameStart : MonoBehaviour {

	//public VuforiaBehaviour vuforiaControl;
	public GameObject popupChooseLevel;

    public void gameStartHandleEvent(int _mode)
    {
		switch (_mode) {
		case 0:
			BaseGameController.Instance.baseModeType = BaseModeType.SINGLE_MODE;
			//popupChooseLevel.SetActive (true);
			ShowPopupChooseLevel();
//                BaseScreenController.Instance.Show(BaseScreenType.BS_WORLD_MAP);
//                ListBank.Instance.onStart();
			break;
		case 1:
			BaseGameController.Instance.baseModeType = BaseModeType.MULTI_MODE;
			//popupChooseLevel.SetActive (true);
			ShowPopupChooseLevel();
//                BaseScreenController.Instance.Show(BaseScreenType.BS_WORLD_MAP);
//                ListBank.Instance.onStart();
			break;
		case 2:
			//vuforiaControl.Set
                //Chuyen sang man hinh huong dan nguoi choi
			break;
		default:
			break;
		}

		SoundManager.Instance.PlaySoundWithType(AudioType.TOUCH);
	}

	public void ShowPopupChooseLevel()
	{
		popupChooseLevel.SetActive (true);
	}

	public void HidePopupChooseLevel()
	{
		popupChooseLevel.SetActive (false);
	}

	public void BntChooseLevel(int level)
	{
		switch (level) 
		{
		case 1:
			BaseGameController.Instance.baseModeLevel = BaseModeLevel.EASY;
			BaseScreenController.Instance.Show(BaseScreenType.BS_WORLD_MAP);
			ListBank.Instance.onStart();
			break;
		case 2:
			BaseGameController.Instance.baseModeLevel = BaseModeLevel.NORMAL;
			BaseScreenController.Instance.Show(BaseScreenType.BS_WORLD_MAP);
			ListBank.Instance.onStart();
			break;
		case 3:
			BaseGameController.Instance.baseModeLevel = BaseModeLevel.HARD;
			BaseScreenController.Instance.Show(BaseScreenType.BS_WORLD_MAP);
			ListBank.Instance.onStart();
			break;
		default:
			break;
		}
		SoundManager.Instance.PlaySoundWithType(AudioType.TOUCH);
	}
}
