using UnityEngine;
using System.Collections;

public class CategoryManager : MonoSingleton<CategoryManager> {


    public GameObject objHouse;
    public GameObject objZoo;
    public GameObject objSchool;
    public GameObject objRestaurant;

    void Awake()
    {
        
    }
	// Use this for initialization
	void Start () {
        objHouse.SetActive(false);
        objZoo.SetActive(false);
        objSchool.SetActive(false);
        objRestaurant.SetActive(false);
        switch(ScenesManager.Instance.category)
        {
            case 1:
                objHouse.SetActive(true);
                break;
            case 2:
                objZoo.SetActive(true);
                break;
            case 3:
                objSchool.SetActive(true);
                break;
            case 4:
                objRestaurant.SetActive(true);
                break;
        }
	}
	
	
}
