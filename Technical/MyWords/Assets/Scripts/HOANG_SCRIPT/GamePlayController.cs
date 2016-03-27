using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;

public class GamePlayController : MonoSingleton<GamePlayController> {

	public ManagerTargetAsset teamBlue;
	public ManagerTargetAsset teamRed;
//	public ManagerTargetAsset teamBlue2;
//	public ManagerTargetAsset teamRed2;

	public LibraryController libraryCtr;
	public BaseWordController baseWordController; //Quan ly tu 
	public UIScoreController scoreController;
	
	public UIWordEffect uiWordEffect;
	public UIPhoto uiPhoto;

	public BaseModeType baseModeType; //Kieu choi la: single hay multi
	public BaseModeLevel baseModeLevel;//muc do choi. De - Binh Thuong - Kho'

	public bool gameLose;
	public bool canChangeWord;
	
	public BaseWord baseWord;
	public StringBuilder answerWord;
	int scoreRed = 0;
	int scoreBlue = 0;
	
	public TutorialController tutorial;
	public int step;
	public const float Block_Tut_Timer = 5.0f;//Sau moi block timer se tu trong tang step
    //
    
	void Awake()
	{
		//BaseLoadData.Instance.InitData();
		baseModeLevel = BaseModeLevel.EASY;
	}

	void Start()
	{
		gameLose = false;
		canChangeWord = false;
        baseWordController.LoadData(CategoryManager.Instance.baseCategory);
	}
	

	[ContextMenu("Restart")]
	public void GameRestart()
	{
		//uiPhoto.UIPhotoSprite = null;
		uiWordEffect.Reset();
		scoreController.Reset();
	}

	public void RestartGame()
	{
		if (baseWord != null) {
			canChangeWord = false;
			tutorial.HideTutorial ();
			step = 1;
			StartCoroutine ("TutorialWithTimer");
			int wordLenght = baseWord.wordContent.Length;
			answerWord = new StringBuilder ();
			int[] arrAnswer = new int[wordLenght];
			for (int i = 0; i< wordLenght; i++) {
				arrAnswer [i] = 0;
			}
			int countCharEnable = 0;
			if (this.baseModeType == BaseModeType.JUNIOR_MODE) {
				countCharEnable = wordLenght - 1;
				;
			} else {
				countCharEnable = 0;
			}
			
			while (countCharEnable > 0) {
				int randIndex = Random.Range (0, wordLenght);
				if (arrAnswer [randIndex] == 0) {
					arrAnswer [randIndex] = 1;
					countCharEnable --;
				}
			}
			for (int i = 0; i < wordLenght; i++) {
				if (arrAnswer [i] == 1) {
					answerWord.Append (baseWord.wordContent [i]);
				} else {
					answerWord.Append ("*");
				}
			}

			uiWordEffect.ReloadData ();
		} else {
			PlayGameWithNewWord();
		}

	}

	public void GameInit()
	{
		Debug.Log("Game Init");
		//DisActiveManagerTarget ();
        //StartCoroutine (baseWordController.ReloadData (libraryCtr.GetListCategoryForGame(), this.baseModeLevel));
        //baseWordController.LoadData();
        gameLose = false;
	}

	[ContextMenu("Show Tut")]
	public void ShowTutorialWithStep()
	{
		if (baseWord != null) {
			//tutorial.ShowText(baseWord.categoryID, step);
			step++;
			if(step > 3)
			{
				StopCoroutine("TutorialWithTimer");
			}
		}
	}

	public IEnumerator TutorialWithTimer()
	{
		yield return new WaitForSeconds (Block_Tut_Timer);
		ShowTutorialWithStep ();
		Debug.Log ("Show next tutorial withn Block TIme = " + Block_Tut_Timer);
		StartCoroutine("TutorialWithTimer");
	}

	public void CheckChangeLibrary()
	{
		if (canChangeWord) {
			//this.GameRestart();
			uiWordEffect.Reset();
			this.GameInit();
			canChangeWord = false;
		}
	}

	public void ExitGame()
	{
		StopCoroutine("TutorialWithTimer");
		tutorial.HideTutorial ();
	}
	
	public void PlayGameWithNewWord() {
		baseWord = this.baseWordController.WordChanged ();
		if (baseWord != null)
		{
			//Reset step of Tutorial
			canChangeWord = false;
			tutorial.HideTutorial();
			step = 1;
			StartCoroutine("TutorialWithTimer");
			int wordLenght = baseWord.wordContent.Length;
			answerWord = new StringBuilder ();
			int[] arrAnswer = new int[wordLenght];
			for(int i = 0; i< wordLenght; i++)
			{
				arrAnswer[i] = 0;
			}
			int countCharEnable = 0;
			if(this.baseModeType == BaseModeType.JUNIOR_MODE)
			{
				countCharEnable = wordLenght - 1;;
			}else {
				countCharEnable = 0;
			}

			while(countCharEnable > 0)
			{
				int randIndex = Random.Range(0, wordLenght);
				if(arrAnswer[randIndex] == 0)
				{
					arrAnswer[randIndex] = 1;
					countCharEnable --;
				}
			}
			for(int i = 0; i < wordLenght; i++)
			{
				if(arrAnswer[i] == 1)
				{
					answerWord.Append(baseWord.wordContent[i]);
				}else{
					answerWord.Append("*");
				}
			}
			Sprite photoSprite = ResourceLoader.GetPictureSprite(baseWord.wordPhoto.Trim());
			uiPhoto.PhotoChanged(photoSprite);
			uiWordEffect.ReloadData();
		}
		else
		{
			//PlayGameWithNewWord();
            Application.LoadLevel("Cao_Scenes");
		}
	}

	public void GameFinish(bool isWin)
	{
		BaseLoadData.Instance.UpdateBaseWordByWordID (baseWord.wordID, isWin);
		SoundManager.Instance.PlaySoundWithName (answerWord.ToString ());
		//uiWordEffect.Reset();

		this.gameLose = true;//that ra day la gameFinish. Khi gameFinish = true thi khong choi game duoc nua.
		DisActiveManagerTarget ();
		Invoke ("PlayGameWithNewWord", 2.0f);
		//PlayGameWithNewWord ();
	}

	public void CompleteChangeWord()
	{
		ActiveManagerTarget ();
		baseWordController.completeChangeWord = true;
		this.gameLose = false;
        Debug.Log(baseWordController.completeChangeWord + ":....:" + this.gameLose);
	}

	public void ActiveManagerTarget()
	{
		teamBlue.EnableImgTargetInChilds ();
        teamRed.EnableImgTargetInChilds();
        //teamBlue2.EnableImgTargetInChilds ();
  //      if (this.baseModeType == BaseModeType.SINGLE_MODE) {
		//	teamRed.DisableImgTargetInChilds ();
		//	//teamRed2.EnableImgTargetInChilds ();
		//} else {
		//	teamRed.EnableImgTargetInChilds();
		//	//teamRed2.DisableImgTargetInChilds();
		//}
	}

	public void DisActiveManagerTarget()
	{
		teamBlue.DisableImgTargetInChilds ();
		teamRed.DisableImgTargetInChilds ();
		//teamBlue2.DisableImgTargetInChilds ();
		//teamRed2.DisableImgTargetInChilds ();
	}
	
	public void TrackableCharacter(char character, BaseTeamType team)
	{
        Debug.Log(baseWordController.completeChangeWord + ":....:" + this.gameLose);
        if (baseWordController.completeChangeWord && !this.gameLose) {
			GiveCharacter(character, team, this.baseModeLevel);
		}
	}

    //Sang test
    public string characterTest;
    [ContextMenu("TrackTest")]
    public void TrackTest()
    {
        //if (baseWordController.completeChangeWord && !this.gameLose)
        //{
            Debug.Log("Da chay");
            GiveCharacter(characterTest[0], BaseTeamType.TEAM_RED, this.baseModeLevel);
        //}
    }
	
	void GiveCharacter(char _character, BaseTeamType _baseTeamType, BaseModeLevel modeLevel)
	{
		StopCoroutine("TutorialWithTimer");
		//tutorial.HideTutorial ();
		int elementIndexOf = this.GetElementIndex(_character, answerWord.ToString());
		if (elementIndexOf == -1 || modeLevel == BaseModeLevel.HARD) {
			//Chua ton tai tu nay
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
							//answerWord.Replace ('*', _character, index, 1);
							//Debug.Log("Answer WOrd = " + answerWord);
							uiWordEffect.DoneCharacterWithTeam(_character, index, _baseTeamType);
							Invoke("PlaySoundWhenWinChar", 1.5f);
						}
					}else {
						Debug.Log("Team nao m");
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

	public int GetElementIndex(char _character, string _keyWord)
	{
		if (_keyWord.Contains(_character.ToString()))
		{
			return _keyWord.IndexOf(_character.ToString());
		}
		return -1;
	}
	
	public void CheckWord(string charRight, int index)
	{
		if (baseWord != null)
		{
			answerWord.Replace ("*", charRight.ToLower(), index, 1);
			if (answerWord.ToString().Trim().Equals(baseWord.wordContent.Trim()))
			{
				this.gameLose = true;
				//Dap an dung
				int _scoreRed;
				int _scoreBlue;
				uiWordEffect.UpdateScoreValue(baseWord.wordContent,out _scoreRed, out _scoreBlue);
				scoreRed = _scoreRed;
				scoreBlue = _scoreBlue;
				SoundManager.Instance.PlaySoundWithType(AudioType.WIN_WORD);
                scoreController.Move(BaseTeamType.TEAM_RED, scoreRed);
                scoreController.Move(BaseTeamType.TEAM_BLUE, scoreBlue);
                uiWordEffect.Reset();
                GameFinish(true);
            }
		}
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
