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
			//Debug.Log("Word = " + word.Count);
			if(word.Count > 5)
			{
				baseWord = new BaseWord();
				baseWord.categoryID = int.Parse(word[1]);
				baseWord.wordID = int.Parse(word[0]);
				baseWord.wordContent = word[2];
				baseWord.wordPhoto = word[3];
				baseWord.wordSound = word[4];
				baseWord.countChar = int.Parse(word[5]);
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
			baseCategory.iD = int.Parse(word[0]);
            baseCategory.categoryID = word[1];
            baseCategory.categoryContent = word[2];
            baseCategory.categoryPhoto = word[3];
            myCategoryData.Add(baseCategory);
        }
        //Load word photo

    }

	public void UpdateBaseWordByWordID(int wordID, bool isWin)
	{
		BaseWord baseWord = myWordData.Find (x => x.wordID == wordID);
		if (isWin) {
			baseWord.countFinish++;
		}else{
			baseWord.countLose++;
		}

		WriteFileWordData ();
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


