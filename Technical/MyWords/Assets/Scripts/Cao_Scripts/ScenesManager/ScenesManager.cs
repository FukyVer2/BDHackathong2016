using UnityEngine;
using System.Collections;

public class ScenesManager : MonoSingleton<ScenesManager>
{


    public string parentID;
    public string parentName = "None";
    //public BaseLoadData baseLoadData;

    void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void bt_JoinHome()
    {
        DontDestroyOnLoad(gameObject);
        parentID = "PR001";
        parentName = "House";
        Application.LoadLevel("Cao_Scenes");

    }

    public void bt_JoinZoo()
    {
        DontDestroyOnLoad(gameObject);
        parentID = "PR003";
        parentName = "The Zoo";
        Application.LoadLevel("Cao_Scenes");
    }

    public void bt_JoinSchool()
    {
        DontDestroyOnLoad(gameObject);
        parentID = "PR002";
        parentName = "School";
        Application.LoadLevel("Cao_Scenes");
    }

    public void bt_JoinRestaurant()
    {
        DontDestroyOnLoad(gameObject);
        parentID = "PR004";
        parentName = "Restaurant";
        Application.LoadLevel("Cao_Scenes");
    }

    //public void Test()
    //{
    //    StartCoroutine(xxx());
    //}

    //IEnumerator xxx()
    //{
    //    while ((Application.isLoadingLevel == false))
    //    {

    //        yield return null;

    //    }
    //    GamePlayController.Instance.baseWordController.LoadData(_baseCategory);
    //}
}