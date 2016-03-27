using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseWordController : MonoBehaviour{

	//public BaseWord baseWord;
    public BaseCategory baseCategory;
//    public UIPhoto uiPhoto;
//    public UIWordEffect uiWordEffect;
    public bool completeChangeWord;
    //private int wordIndex;
    public List<BaseWord> baseWords;

    public void LoadData(BaseCategory _baseCategory)
    {
        if (BaseLoadData.Instance.myWordData != null)
        {
            baseWords = BaseLoadData.Instance.myWordData.FindAll(x => x.categoryID.Equals(_baseCategory.categoryID));
            completeChangeWord = false;
            GamePlayController.Instance.PlayGameWithNewWord();
        }
    }

	public IEnumerator ReloadData(List<BaseCategory> listCategorySelect, BaseModeLevel modeLevel) //IEnumerator
    {
		//BaseCategory baseCategory = GamePlayController.Instance.baseCategory;
        if(baseWords != null)
            baseWords.Clear();
		int minCountChar = 0;
		int maxCountChar = 0;
		switch (modeLevel) {
		case BaseModeLevel.EASY:
			minCountChar = 3;
			maxCountChar = 6;
			break;
		case BaseModeLevel.NORMAL:
			minCountChar = 5;
			maxCountChar = 9;
			break;
		case BaseModeLevel.HARD:
			minCountChar = 6;
			maxCountChar = 11;
			break;
		default: break;
		}
		foreach (BaseCategory baseCategory in listCategorySelect) {
			List<BaseWord> listWordByCategory = BaseLoadData.Instance.myWordData.FindAll (
				x => x.categoryID == baseCategory.categoryID && x.countChar >=minCountChar && x.countChar <= maxCountChar);
			//baseWords.
			foreach(BaseWord baseWord in listWordByCategory)
			{
				baseWords.Add(baseWord);
			}
		}
		//baseWords = BaseLoadData.Instance.myWordData;//.FindAll(x=>x.categoryID.Equals(baseCategory.categoryID));
		//baseWords = BaseLoadData.Instance.myWordData.FindAll (x => x.categoryID.Equals("CA0001"));
#if UNITY_EDITOR
		Debug.Log ("Reload Data with " + baseWords.Count);
#endif
		//wordIndex = 0;
		yield return new WaitForSeconds (0.65f);
		//this.WordChanged ();
       // Invoke("WordChanged", 0.5f);
#if UNITY_EDITOR
		Debug.Log ("Reload Data");
#endif
		//Invoke ("PlayWithNewWord", 0.5f);
        completeChangeWord = false;
        GamePlayController.Instance.PlayGameWithNewWord();
        //WordChanged();
    }

//	void PlayWithNewWord()
//	{
//		BaseGameController.Instance.PlayGameWithNewWord ();
//	}

    [ContextMenu("Change word")]
    public BaseWord WordChanged()
    {
        //string categoryID = BaseGameController.Instance.categoryID;
        //string wordID = BaseGameController.Instance.wordID;
        //
        //baseWord = BaseLoadData.Instance.myWordData.Find(x => x.wordID.Equals(wordID) && x.categoryID.Equals(categoryID));
        //baseCategory = BaseLoadData.Instance.myCategoryData.Find(x => x.categoryID.Equals(categoryID));
        //Reload lai buc anh

		BaseWord baseWord;

        if (baseWords != null && baseWords.Count > 0) {
			int index = Random.Range(0, baseWords.Count);
			baseWord = baseWords[index];
			//Debug.Log("Base Word " + baseWord.wordContent);
			baseWords.Remove(baseWord);
			//baseWords.RemoveAt(index);
			//Debug.Log("Base Word " + baseWord.wordContent);
			return baseWord;
		}
        else
        {
//            BaseTeamType baseTeamType = BaseGameController.Instance.scoreController.GetTeamWin();
//            switch (baseTeamType)
//            {
//                case BaseTeamType.NONE:
//                    break;
//                case BaseTeamType.TEAM_RED:
//                    BaseScreenController.Instance.ShowPopup(BaseScreenType.BS_GAME_WIN_RED);
//                    break;
//                case BaseTeamType.TEAM_BLUE:
//                    BaseScreenController.Instance.ShowPopup(BaseScreenType.BS_GAME_WIN_BLUE);
//                    break;
//                default:
//                    break;
//            }
			//Game Over
            return null;
        }
        
//		if (baseWord != null)
//		{
//			Sprite photoSprite = ResourceLoader.GetPictureSprite(baseWord.wordPhoto.Trim());
//			uiPhoto.PhotoChanged(photoSprite);
//			uiWordEffect.ReloadData();
//			//uiWordEffect.ReloadData();
//		}
//		else
//		{
//			#if UNITY_EDITOR
//			Debug.Log("Hinh nhu khong co tu nay thi phai");
//			#endif
//		}
    }

    //Nhan mot ky tu vao tu input
    public void GiveCharacter(char _character, BaseTeamType _baseTeamType)
    {
        switch (_baseTeamType)
        {
            case BaseTeamType.NONE:
#if UNITY_EDITOR
                Debug.Log("Tu nay ko cua doi nao");
#endif
                break;
            case BaseTeamType.TEAM_RED:

                break;
            case BaseTeamType.TEAM_BLUE:
                break;
            default:
                break;
        }
    }
}
