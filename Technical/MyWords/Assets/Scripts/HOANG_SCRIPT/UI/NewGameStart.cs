using UnityEngine;
using System.Collections;

public class NewGameStart : MonoBehaviour {

	public void BntGameStartHandle(int _mode)
	{
		switch (_mode) {
		case 0:
			GamePlayController.Instance.baseModeType = BaseModeType.SINGLE_MODE;
			BaseScreenController.Instance.Show(BaseScreenType.BS_GAME_PLAY);
			//                ListBank.Instance.onStart();
			break;
		case 1:
			GamePlayController.Instance.baseModeType = BaseModeType.MULTI_MODE;
			BaseScreenController.Instance.Show(BaseScreenType.BS_GAME_PLAY);
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
}
