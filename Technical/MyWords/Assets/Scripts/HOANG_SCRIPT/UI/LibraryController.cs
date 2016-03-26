using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LibraryController : MonoBehaviour {

	List<BaseCategory> listCategory;
	public GameObject prefabCategory;
	public Transform rootCategory;

	public List<BaseCategory> listCategorySelected;
	// Use this for initialization
	void Start () {
		LoadData ();
		listCategorySelected = new List<BaseCategory> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadData()
	{
		listCategory = new List<BaseCategory> ();
		listCategory = BaseLoadData.Instance.myCategoryData;

		for(int i = 0; i < listCategory.Count; i++)
		{
			BaseCategory baseCategory = listCategory[i];

			GameObject gameObjCategory = Instantiate(prefabCategory) as GameObject;

			gameObjCategory.transform.SetParent(rootCategory);
			gameObjCategory.transform.localScale = Vector3.one;

			CategoryController categoryCtr = gameObjCategory.GetComponent<CategoryController>();
			if(categoryCtr != null)
			{
				categoryCtr.UpdateContent(baseCategory);
				categoryCtr.libraryCtr = this;
			}
		}
	}

	public void AddCategory(BaseCategory baseCategory)
	{
		if (baseCategory != null && !listCategorySelected.Contains(baseCategory)) {
			listCategorySelected.Add(baseCategory);
			GamePlayController.Instance.canChangeWord = true;
		}
	}

	public void RemoveCategory(BaseCategory baseCategory)
	{
		if (baseCategory != null && listCategorySelected.Contains(baseCategory)) {
			listCategorySelected.Remove(baseCategory);
			GamePlayController.Instance.canChangeWord = true;
		}
	}

	public void ClearLibrary()
	{
		if (listCategorySelected != null) {
			listCategorySelected.Clear();
		}
	}

	public List<BaseCategory> GetListCategoryForGame()
	{
		if (listCategorySelected.Count <= 0) {
			return listCategory;
		}

		return listCategorySelected;
	}

	//public 
}
