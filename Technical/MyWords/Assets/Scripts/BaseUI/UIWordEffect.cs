using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;

public class UIWordEffect : MonoBehaviour {

    public const int WORD_LENGHT = 11;
    public List<UIWord> uiWords;
    public List<UIWordWrong> uiWrongWords;
    public List<UIWordPrefab> uiPrefabWords = new List<UIWordPrefab>();
    public int elementIndex;
    //

	public GridLayoutGroup grid; 
	public GridLayoutGroup gridWordWrong;

    public void OnSlotChanged()
    {
		string keyWord = GamePlayController.Instance.answerWord.ToString ();
		if (keyWord != null)
        {
            if (keyWord.Length <= WORD_LENGHT)
            {
                for (int i = 0; i < WORD_LENGHT; i++)
                {
                    if (i < keyWord.Length)
                    {
                        uiWords[i].Show();

						if(keyWord[i] != '*')
						{
							uiWords[i].WordText = keyWord[i].ToString().ToUpper();
							uiWords[i].wordContent.SetActive(true);
							uiWords[i].wordContentText.gameObject.SetActive(true);
						}else {
							uiWords[i].wordContentText.gameObject.SetActive(false);
							uiWords[i].wordContent.SetActive(false);
						}
                    }
                    else
                    {
                        uiWords[i].Hide();
                    }
                }

                for (int j = 0; j < uiWrongWords.Count; j++)
                {
					//Active So tu co the sai. 
					int countWordWrong = GamePlayController.Instance.baseModeLevel == BaseModeLevel.EASY ? 10 : 5;
					if(j < countWordWrong) //(keyWord.Length / 2 + 1)
                    {
                        uiWrongWords[j].IsActive = true;
                        uiWrongWords[j].IsUse = false;
                    }
                    else
                    {
                        uiWrongWords[j].IsActive = false;
                        uiWrongWords[j].IsUse = false;
                    }
                }
                //
                //EndTween(0.25f);
                //Sang Test
                Debug.Log("Da goi cho nay");
                GamePlayController.Instance.CompleteChangeWord();
            }
            else
            {
#if UNITY_EDITOR
                Debug.Log("Tu nay qua dai roi");
#endif
            }
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log("Khong lay duoc tu roi");
#endif
        }
    }

    //Reset data
    public void Reset()
    {
        foreach (var uiPrefabWord in uiPrefabWords)
        {
            uiPrefabWord.DestroyWord();
        }
        uiPrefabWords.Clear();
		foreach (UIWord uiWord in uiWords) {
			uiWord.StopItween();
		}
    }
	
    [ContextMenu("Reload Data")]
    public void ReloadData()
    {
        BaseWord baseWord = GamePlayController.Instance.baseWord;
		ChangeGridLayout (baseWord.wordContent.Length);
        if (baseWord != null)
        {
            OnSlotChanged();
        }
        Reset();
    }
        
    public GameObject uiWordPrefab;

    public void UpdateScoreValue(string keyWord, out int _scoreRed, out int _scoreBlue)
    {
        _scoreRed = 0;
        _scoreBlue = 0;
        if (keyWord.Length <= WORD_LENGHT)
        {
            for (int i = 0; i < keyWord.Length; i++)
            {
                switch (uiWords[i].UIWordType)
                {
                    case UIWordType.NONE:
                        break;
                    case UIWordType.RED:
                        _scoreRed += uiWords[i].WordScore;
                        break;
                    case UIWordType.BLUE:
                        _scoreBlue += uiWords[i].WordScore;
                        break;
                    case UIWordType.ACTIVE:
                        break;
                    case UIWordType.DEACTIVE:
                        break;
                    default:
                        break;
                }
            }
        }
    }

    //Dung 1 ki tu trong Tu
	public void DoneCharacterWithTeam(char character, int index, BaseTeamType team)
	{
		uiWords [index].UIWordType = team == BaseTeamType.TEAM_RED ? UIWordType.RED : UIWordType.BLUE;
		uiWords [index].WordText = character.ToString ().ToUpper ();
		uiWords [index].WordScore = 2;
		uiWords [index].index = index;
        uiWords[index].OnWordValueChanged();
        GamePlayController.Instance.CheckWord(character.ToString(), index);
	}

    //Tao ra mot prefab
    public void GetUIWordPrefab(UIWordType _uiWordType, char _character)
    {
        int index = GetElementIndexOfWordPrefab(_character);
        if (index >= 0)
        {
            if (uiWordPrefab != null)
            {
                GameObject uiPrefab = (GameObject)Instantiate(uiWordPrefab);
                uiPrefab.GetComponent<RectTransform>().SetSize(grid.cellSize);
                uiPrefab.transform.SetParent(transform.parent);
                uiPrefab.transform.localScale = Vector3.one;
                uiPrefab.transform.position = new Vector3(0, transform.position.y, 0);
                UIWordPrefab uiWord = uiPrefab.GetComponent<UIWordPrefab>();
                //uiWord.Show();
                uiWrongWords[index].IsUse = true;
                uiWord.UIWordType = _uiWordType;
                uiWord.WordText = _character.ToString().ToUpper();
				uiWord.scaleWhenFinish = (float)gridWordWrong.cellSize.x / grid.cellSize.x;
                uiWord.MoveUp(uiWrongWords[index].transform.position, 2.5f, 2.5f, null);
                //
                uiPrefabWords.Add(uiWord);
                //
          
            }
        }
        else if(index == -2)
        {
            if (uiWordPrefab != null)
            {
                GameObject uiPrefab = (GameObject)Instantiate(uiWordPrefab);
				uiPrefab.GetComponent<RectTransform>().SetSize(grid.cellSize);
                uiPrefab.transform.SetParent(transform.parent);
                uiPrefab.transform.localScale = Vector3.one;
                uiPrefab.transform.position = new Vector3(0, transform.position.y, 0);
                UIWordPrefab uiWord = uiPrefab.GetComponent<UIWordPrefab>();
                //uiWord.Show();
                uiWord.UIWordType = _uiWordType;
                uiWord.WordText = _character.ToString().ToUpper();

				uiWord.scaleWhenFinish = (float)gridWordWrong.cellSize.x / grid.cellSize.x;
				Debug.Log("Scale When Finish = " + uiWord.scaleWhenFinish);
                uiWord.MoveUp(Vector3.zero, 2.5f, 2.5f, CheckGameOver);
                //
                uiPrefabWords.Add(uiWord);
                //

            }
            //Fail Game
        }
    }

    public void CheckGameOver()
    {
		Debug.Log ("Check Game OVer");
		GamePlayController.Instance.GameFinish(false);
    }

    private int GetElementIndexOfWordPrefab(char _character)
    {
        if (uiWrongWords != null)
        {
            for (int i = 0; i < uiWrongWords.Count; i++)
            {
                if (uiWrongWords[i].IsActive && !uiWrongWords[i].IsUse)
                    if (!uiPrefabWords.Find(x => x.WordText.Equals(_character.ToString().ToUpper())))
                    {
                        return i;
                    }
                    else
                    {
                        return -1;
                    }
               
            }
        }
        return -2;
    }

	public void ChangeGridLayout(int countChar)
	{
        if (countChar <= 4)
        {
            grid.cellSize = new Vector2(170, 170);
        }
        else
        {
            if (countChar <= 6)
            {
                grid.cellSize = new Vector2(140, 140);
            }
            else
            {
                grid.cellSize = new Vector2(85, 85);
            }

        }

        //Sang sua cho nay
//        if (countChar <= 5)
//        {
//            grid.cellSize = new Vector2(75, 75);
//            grid.spacing = new Vector2(-15, 0);
//        }
//        else
//        {
//            if (countChar <= 7)
//            {
//                grid.cellSize = new Vector2(60, 60);
//                grid.spacing = new Vector2(-12, 0);
//            }
//            else
//            {
//                grid.cellSize = new Vector2(45, 45);
//                grid.spacing = new Vector2(-8, 0);
//            }
//
//        }
	}

}
