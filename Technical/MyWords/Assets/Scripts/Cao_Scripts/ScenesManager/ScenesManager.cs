using UnityEngine;
using System.Collections;

public class ScenesManager : MonoSingleton<ScenesManager>
{


    public int category;

    void Awake()
    {

    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void bt_JoinHome()
    {
        DontDestroyOnLoad(gameObject);
        category = 1;
        Application.LoadLevel("Cao_Scenes");

    }
    public void bt_JoinZoo()
    {
        DontDestroyOnLoad(gameObject);
        category = 2;
        Application.LoadLevel("Cao_Scenes");       
    }
    public void bt_JoinSchool()
    {
        DontDestroyOnLoad(gameObject);
        category = 3;
        Application.LoadLevel("Cao_Scenes");      
    }
    public void bt_JoinRestaurant()
    {
        DontDestroyOnLoad(gameObject);
        category = 4;
        Application.LoadLevel("Cao_Scenes");        
    }
}
