using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CategoryManager : MonoSingleton<CategoryManager> {


    public GameObject objHouse;
    public GameObject objZoo;
    public GameObject objSchool;
    public GameObject objRestaurant;
    //
    public Transform contentPanel;
    public Text parentTitle;
    //
    public GameObject categoryPrefab;

    void Awake()
    {
        
    }
	// Use this for initialization
	void Start () {
        //objHouse.SetActive(false);
        //objZoo.SetActive(false);
        //objSchool.SetActive(false);
        //objRestaurant.SetActive(false);
        //switch(ScenesManager.Instance.parentID)
        //{
        //    case "PR001":
        //        objHouse.SetActive(true);
        //        break;
        //    case "PR002":
        //        objZoo.SetActive(true);
        //        break;
        //    case "PR003":
        //        objSchool.SetActive(true);
        //        break;
        //    case "PR004":
        //        objRestaurant.SetActive(true);
        //        break;
        //}
        createCategory();
	}

    void createCategory()
    {
        string parentID = ScenesManager.Instance.parentID;
        string parentName = ScenesManager.Instance.parentName;
        parentTitle.text = parentName;
        List<BaseCategory> baseCategories =
            BaseLoadData.Instance.myCategoryData.FindAll(x => x.parentID.Equals(parentID));
        if (baseCategories != null)
        {
            Debug.Log("So hinh: " + ResourceLoader.categoryLibrary.Count);
            foreach (var baseCategory in baseCategories)
            {
                GameObject categoryObj = GameObject.Instantiate(categoryPrefab) as GameObject;
                UICategory uiCategory = categoryObj.GetComponent<UICategory>();
                uiCategory.categoryName.text = baseCategory.categoryContent;
                uiCategory.baseCategory = baseCategory;
                Debug.Log("Hinh:" + baseCategory.categoryPhoto);
                uiCategory.categorySprite.sprite = ResourceLoader.GetCategorySprite(baseCategory.categoryPhoto);
                uiCategory.categoryButton.onClick.AddListener(delegate { OnCategoryClicked(uiCategory.baseCategory);});
                categoryObj.transform.SetParent(contentPanel);
                categoryObj.transform.localScale = Vector3.one;
                categoryObj.transform.localPosition = Vector3.zero;
            }
            
        }

    }

    public BaseCategory baseCategory;

    void OnCategoryClicked(BaseCategory _baseCategory)
    {
        Debug.Log("Duoc chon: " + _baseCategory.categoryContent);
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(ScenesManager.Instance.gameObject);
        Application.LoadLevel("NewUI");
        baseCategory = _baseCategory;

    }

    public void OnBackMenu()
    {
        //DontDestroyOnLoad(gameObject);
        Destroy(ScenesManager.Instance.gameObject);
        Application.LoadLevel("WorldMap");
    }
}
