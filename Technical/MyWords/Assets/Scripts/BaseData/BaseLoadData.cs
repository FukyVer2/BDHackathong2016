using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BaseLoadData : MonoSingleton<BaseLoadData> {

	public const string WORD_PATH = "Data/wordData";
    public const string CATEGORY_PATH = "Data/categoryData";
    public const string WORD_PHOTO_PATH = "";
    public const string CATEGORY_PHOTO_PATH = "";
    //
    public List<BaseWord> myWordData = new List<BaseWord>();
    public List<BaseCategory> myCategoryData = new List<BaseCategory>();
    public Dictionary<string, Sprite> myWordPhoto = new Dictionary<string,Sprite>(); //string: Ten Sprite, Sprite: buc hinh tuong ung
    public Dictionary<string, Sprite> myCategoryPhoto = new Dictionary<string, Sprite>(); //string: Ten Sprite, Sprite: buc hinh tuong ung

    void Start()
    {
        InitData();
    }

    public void InitData()
    {
        //
        ResourceLoader.InitData();
        //Load word from file
        List<List<string>> dataValue = FileLoader.LoadDataFromFile(WORD_PATH);
        BaseWord baseWord;
#if UNITY_EDITOR
		Debug.Log ("Data Value count = " + dataValue.Count);
#endif
        foreach (var word in dataValue)
        {
			Debug.Log("Word = " + word.Count);
			if(word.Count > 5)
			{
				baseWord = new BaseWord();
				baseWord.categoryID = word[1].Trim();
				baseWord.wordID = word[0].Trim();
                baseWord.wordContent = word[2].Trim();
                baseWord.wordPhoto = word[3].Trim();
                baseWord.wordSound = word[4];
				baseWord.countChar = int.Parse(word[5].Trim());
				baseWord.countFinish = 0;//int.Parse(word[6]);
				baseWord.countLose = 0;//int.Parse(word[7]);;
				myWordData.Add(baseWord);
			}
            
        }
        //Load category
        dataValue = FileLoader.LoadDataFromFile(CATEGORY_PATH);
        BaseCategory baseCategory;
        foreach (var word in dataValue)
        {
            baseCategory = new BaseCategory();
			baseCategory.parentID = word[0].Trim(); ;
            baseCategory.categoryID = word[1].Trim(); ;
            baseCategory.categoryContent = word[2].Trim(); ;
            baseCategory.categoryPhoto = word[3].Trim(); ;
            myCategoryData.Add(baseCategory);
        }
        //Load word photo

    }

	public void UpdateBaseWordByWordID(string wordID, bool isWin)
	{
		BaseWord baseWord = myWordData.Find (x => x.wordID == wordID);
		if (isWin) {
			baseWord.countFinish++;
		}else{
			baseWord.countLose++;
		}

		//WriteFileWordData ();
	}

	[ContextMenu("Write Data")]
	public void WriteFileWordData()
	{
		List<string> listData = new List<string> ();
		string header = "WordID	CategoryID	WordContent	WordPhoto	Sound	Count	CountTrue	CountFalse";
		listData.Add (header);
		foreach (BaseWord baseWord in this.myWordData) {
			string word = baseWord.ConvertToString();
			listData.Add(word);
		}

		FileLoader.WriteDataToFile (WORD_PATH, listData);
	}
}


