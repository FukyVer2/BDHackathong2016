using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using UnityEngine.UI;

public class BaseGameController : MonoSingleton<BaseGameController>
{

    public string categoryID; //category hien tai dang choi
    public string wordID; //tu hien tai dang choi
	public ManagerTargetAsset teamRedTargets;//
	public ManagerTargetAsset teamBlueTargets;//
	public ManagerTargetAsset teamRed2Targets;//
	public ManagerTargetAsset teamBlue2Targets;//
    //
    public BaseCategory baseCategory; //Nhom tu hien tai dang choi
    public BaseWordController baseWordController; //Quan ly tu 
    public UIScoreController scoreController;

	public UIWordEffect uiWordEffect;
	public UIPhoto uiPhoto;

	public Image imgTimer;
	//
    public BaseModeType baseModeType; //Kieu choi la: single hay multi
	public BaseModeLevel baseModeLevel;//muc do choi. De - Binh Thuong - Kho'

	public GameObject gameObjTimer;

	public float timer;
	private float TIME_DEFAULT;
	private const float TIMER_INTERVAL = 0.5f;
	public bool isSequence;

    public bool gameLose;
    
	public BaseWord baseWord;
	public StringBuilder answerWord;
	int scoreRed = 0;
	int scoreBlue = 0;
    //

    void Awake()
    {
        BaseLoadData.Instance.InitData();
    }
    void Start()
    {
		gameLose = false;

		//Tam thoi comment
		uiPhoto.Reset ();


        //baseWordController.uiPhoto.Reset();
        BaseScreenController.Instance.Show(BaseScreenType.BS_GAME_START);

		//Tam thoi comment

		teamRedTargets.DisableImgTargetInChilds ();
		teamBlueTargets.DisableImgTargetInChilds ();
		//teamRed2Targets.DisableImgTargetInChilds ();
		//teamBlue2Targets.DisableImgTargetInChilds ();

		//Tam thoi Comment

		gameObjTimer.SetActive (false);
        
		//Not me
	//	GameInit();
    }
	

    public void GameRestart()
    {
        uiPhoto.UIPhotoSprite = null;
        uiWordEffect.Reset();
        scoreController.Reset();
    }

	public void GameStart()
	{
		isSequence = false;

		switch (this.baseModeLevel) {
		case BaseModeLevel.EASY:
			gameObjTimer.SetActive(false);
			break;
		case BaseModeLevel.NORMAL:
			gameObjTimer.SetActive(true);
			timer = 60;
			TIME_DEFAULT = 60;
			StartCoroutine (RunGameWithTimer ());
			break;
		case BaseModeLevel.HARD:
			gameObjTimer.SetActive(true);
			timer = 60;
			TIME_DEFAULT = 60;
			isSequence = true;
			StartCoroutine (RunGameWithTimer ());
			break;
		default:
			break;
		}

	}

	public IEnumerator RunGameWithTimer()
	{
		//Debug.Log ("Timer = " + timer);
		imgTimer.fillAmount = timer / TIME_DEFAULT;
		yield return new WaitForSeconds (TIMER_INTERVAL);
		timer -= TIMER_INTERVAL;
#if UNITY_EDITOR
		Debug.Log ("Timer = " + timer);
#endif
		//Update UI Timer
		if (timer <= 0) {
			GameOver ();
		} else {
			StartCoroutine(RunGameWithTimer());
		}
	}

    public void GameInit()
    {
		//teamRedTargets.EnableImgTargetInChilds ();
        //baseWordController.uiPhoto.Reset();
		if (this.baseModeType == BaseModeType.SINGLE_MODE) {
			teamRedTargets.EnableImgTargetInChilds ();
			//teamRed2Targets.E
			teamBlueTargets.DisableImgTargetInChilds();
		} else {
			if (this.baseModeType == BaseModeType.MULTI_MODE)
			{
				teamRedTargets.EnableImgTargetInChilds ();
				teamBlueTargets.EnableImgTargetInChilds ();
			}
		}

        //baseWordController.ReloadData();
#if UNITY_EDITOR
		Debug.Log("Game Init");
#endif
		//StartCoroutine (baseWordController.ReloadData ());
		//baseWordController.ReloadData ();
		//this.baseWordController.WordChanged ();
        gameLose = false;
    }

	public void PlayGameWithNewWord() {
		baseWord = this.baseWordController.WordChanged ();
#if UNITY_EDITOR
		Debug.Log("Base Word " + baseWord.wordContent);
#endif
		if (baseWord != null)
		{
			Sprite photoSprite = ResourceLoader.GetPictureSprite(baseWord.wordPhoto.Trim());
			uiPhoto.PhotoChanged(photoSprite);
			uiWordEffect.ReloadData();
			//uiWordEffect.ReloadData();
		}
		else
		{

			#if UNITY_EDITOR
			Debug.Log("Hinh nhu khong co tu nay thi phai");
			#endif

			BaseTeamType baseTeamType = scoreController.GetTeamWin();
			switch (baseTeamType)
			{
			case BaseTeamType.NONE:
				break;
			case BaseTeamType.TEAM_RED:
				BaseScreenController.Instance.ShowPopup(BaseScreenType.BS_GAME_WIN_RED);
				break;
			case BaseTeamType.TEAM_BLUE:
				BaseScreenController.Instance.ShowPopup(BaseScreenType.BS_GAME_WIN_BLUE);
				break;
			default:
				break;
			}
		}
	}

    void GameWin()
    {

    }

	[ContextMenu("Game Over")]
    public void GameOver()
    {
        Invoke("ShowScreenGameOver", 1.0f);
        //AR.SetActive(false);
		teamRedTargets.DisableImgTargetInChilds ();
		teamBlueTargets.DisableImgTargetInChilds ();
        gameLose = true;
    }

	public void TrackableCharacter(char character, BaseTeamType team)
	{
		if (baseWordController.completeChangeWord && !this.gameLose) {
			//uiWordEffect.GiveCharacter(character, team, this.baseModeLevel);
			GiveCharacter(character, team, this.baseModeLevel);
		}
	}

	void GiveCharacter(char _character, BaseTeamType _baseTeamType, BaseModeLevel modeLevel)
	{
		int elementIndexOf = -1;//this.uiWordEffect.GetElementIndex(_character, answerWord.ToString());
		if (elementIndexOf == -1 || modeLevel == BaseModeLevel.HARD) {
			if (baseWord != null) {
				List<int> allElementIndexOf = this.GetAllElementIndex (_character, baseWord.wordContent.Trim (), modeLevel);
				if (allElementIndexOf.Count == 0) {
					switch (_baseTeamType) {
					case BaseTeamType.NONE:
						break;
					case BaseTeamType.TEAM_RED:
						this.uiWordEffect.GetUIWordPrefab (UIWordType.RED, _character);
						break;
					case BaseTeamType.TEAM_BLUE:
						this.uiWordEffect.GetUIWordPrefab (UIWordType.BLUE, _character);
						break;
					default:
						break;
					}

					Invoke("PlaySoundWhenLoseChar", 1.5f);
				} else {
					if (_baseTeamType != BaseTeamType.NONE)
					{
						foreach (var index in allElementIndexOf) {
							answerWord.Replace ('*', _character, index, 1);
							uiWordEffect.DoneCharacterWithTeam(_character, index, _baseTeamType);
							Invoke("PlaySoundWhenWinChar", 1.5f);
							//uiWords [index].MoveUp (Check);
						}
					}else {
#if UNITY_EDITOR
						Debug.Log("Team nao m");
#endif
					}
				}
			} else {
				#if UNITY_EDITOR
				Debug.Log ("Chua co du lieu duoc chon");
				#endif
			}
		} else { 
			//Cha lam gi ca
		}
	}
	void PlaySoundWhenLoseChar()
	{
		SoundManager.Instance.PlaySoundWithType(AudioType.LOST_CHAR);
	}

	void PlaySoundWhenWinChar()
	{
		SoundManager.Instance.PlaySoundWithType(AudioType.WIN_CHAR);
	}

	int GetIndexOfNearBlank()
	{
		if (answerWord.ToString ().Contains ("*")) {
			int indexOfBlank = answerWord.ToString ().IndexOf ("*");
			return indexOfBlank;
		} else {
			return -1;
		}
	}

	public void CheckWord()
	{
		if (baseWord != null)
         {
             if (answerWord.ToString().Trim().Equals(baseWord.wordContent.Trim()))
             {
                 baseWordController.completeChangeWord = false;
                 //Dap an dung
				int _scoreRed;
				int _scoreBlue;
				uiWordEffect.UpdateScoreValue(baseWord.wordContent,out _scoreRed, out _scoreBlue);
				scoreRed = _scoreRed;
				scoreBlue = _scoreBlue;
#if UNITY_EDITOR
				Debug.Log("Score Game = " + scoreRed);
#endif
				SoundManager.Instance.PlaySoundWithType(AudioType.WIN_WORD);
				Invoke("ScoreEffect", 2.5f);
				//this.ScoreEffect();
             }
         }
	}

	public void ScoreEffect()
	{
		scoreController.Move(BaseTeamType.TEAM_RED, scoreRed);
		scoreController.Move(BaseTeamType.TEAM_BLUE, scoreBlue);
		//
		uiWordEffect.Reset();
		answerWord = new StringBuilder ();
		//BaseGameController.Instance.baseWordController.WordChanged();
#if UNITY_EDITOR
		Debug.Log ("Score effect");
#endif
		PlayGameWithNewWord ();
	}

	public List<int> GetAllElementIndex(char character, string keyWord, BaseModeLevel modeLevel)
	{
		List<int> elementIndexArr = new List<int>();
		if (modeLevel == BaseModeLevel.HARD) {
			int indexOfBlank = GetIndexOfNearBlank ();
			if (character == keyWord [indexOfBlank]) {
				elementIndexArr.Add (indexOfBlank);
			}
		} else {
			if (keyWord.Contains(character.ToString()))
			{
				for (int i = 0; i < keyWord.Length; i++)
				{
					if (keyWord[i].Equals(character))
						elementIndexArr.Add(i);
				}
			}
		}

		return elementIndexArr;
	}

    void ShowScreenGameOver()
    {
        BaseScreenController.Instance.ShowPopup(BaseScreenType.BS_GAME_OVER);
    }
}
