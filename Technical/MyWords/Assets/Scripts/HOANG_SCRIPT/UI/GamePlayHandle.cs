using UnityEngine;
using System.Collections;

public class GamePlayHandle : MonoBehaviour {

	public GameObject gameStart;
	public GameObject gamePlay;
	public GameObject backgroundPlay;
	public GameObject buttonPause;
	public GameObject gamePause;
	public GameObject gameLibrary;
	public GameObject gameArchiment;

	public GameObject scoreRed;
	public GameObject scoreBlue;
	public GameObject bnt_Library;

	public void Start()
	{
		ShowGameStart ();
	}

	void DisableAll()
	{
		gameStart.SetActive (false);
		gamePlay.SetActive (false);
		backgroundPlay.SetActive (false);
		buttonPause.SetActive (false);
		gamePause.SetActive (false);
		gameLibrary.SetActive (false);
		gameArchiment.SetActive (false);
	}

	void ShowGameStart()
	{
		DisableAll ();
		gameStart.SetActive (true);
	}

	void ShowGamePlay(bool isEnable)//isEnable to show Button pause
	{
		DisableAll ();
		gamePlay.SetActive (true);
		if (isEnable) {
			buttonPause.SetActive (true);
		} else {
			backgroundPlay.SetActive(true);
		}

	}

	void PlaySoundButtonTouch()
	{
		SoundManager.Instance.PlaySoundWithType(AudioType.TOUCH);
	}

	public void BntPauseGame()
	{
		ShowGamePlay (false);
		gamePause.SetActive (true);
		backgroundPlay.SetActive(true);
		GamePlayController.Instance.DisActiveManagerTarget ();
		PlaySoundButtonTouch ();
	}

	public void BntGameHome()
	{
		GamePlayController.Instance.ExitGame ();
		ShowGameStart ();
		backgroundPlay.SetActive(false);
		PlaySoundButtonTouch ();
	}

	public void BntExit()
	{
		ShowGamePlay (true);
		backgroundPlay.SetActive(false);
		GamePlayController.Instance.CheckChangeLibrary ();
		GamePlayController.Instance.ActiveManagerTarget ();
		PlaySoundButtonTouch ();
	}

	public void BntLibrary()
	{
		ShowGamePlay (false);
		gameLibrary.SetActive (true);
		PlaySoundButtonTouch ();
	}

	public void BntArchiment()
	{
		ShowGamePlay (false);
		gameArchiment.SetActive (true);
		PlaySoundButtonTouch ();
	}

	public void BntSinglePlay()
	{
		ShowGamePlay (true);

		GamePlayController.Instance.baseModeType = BaseModeType.SINGLE_MODE;
		GamePlayController.Instance.GameRestart ();
		GamePlayController.Instance.GameInit();

		ShowGameWithPlayMode (BaseModeType.SINGLE_MODE);
		PlaySoundButtonTouch ();
	}

	public void BntVersusPLay()
	{
		ShowGamePlay (true);
		GamePlayController.Instance.baseModeType = BaseModeType.MULTI_MODE;
		GamePlayController.Instance.GameRestart ();
		GamePlayController.Instance.GameInit();

		ShowGameWithPlayMode (BaseModeType.MULTI_MODE);
		PlaySoundButtonTouch ();
	}

	public void BntJunior()
	{
		GamePlayController.Instance.baseModeType = BaseModeType.JUNIOR_MODE;
		GamePlayController.Instance.GameInit();
		GamePlayController.Instance.GameRestart ();

		ShowGamePlay (true);
		ShowGameWithPlayMode (BaseModeType.JUNIOR_MODE);
		PlaySoundButtonTouch ();
	}

	public void ShowGameWithPlayMode(BaseModeType modeType)
	{
		switch (modeType) {
		case BaseModeType.SINGLE_MODE:
			scoreRed.SetActive(false);
			scoreBlue.SetActive(true);
			bnt_Library.SetActive(true);
			break;
		case BaseModeType.MULTI_MODE:
			scoreRed.SetActive(true);
			scoreBlue.SetActive(true);
			bnt_Library.SetActive(true);
			break;
		case BaseModeType.JUNIOR_MODE:
			scoreRed.SetActive(true);
			scoreBlue.SetActive(true);
			bnt_Library.SetActive(false);
			GamePlayController.Instance.libraryCtr.ClearLibrary();
			break;
		default:
			break;
		}
	}

	public void BntRestartGame()
	{
		ShowGamePlay (true);
		backgroundPlay.SetActive(false);
		GamePlayController.Instance.RestartGame ();
		PlaySoundButtonTouch ();
	}

}
