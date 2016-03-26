/* Store the contents for ListBoxes to display.
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ListBank : MonoBehaviour
{
    public static ListBank Instance;
    public BaseCategory baseCategory;
    public UIGameMenu gameMenu;
    private int[] contents = {
		1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16
	};

    private List<BaseCategory> allContents = new List<BaseCategory>();

    void Awake()
    {
        Instance = this;
    }

    //void LoadData()
    //{
    //    allContents = BaseLoadData.Instance.myCategoryData;
    //}

    //public int getListContent(int index)
    //{
    //    return contents[index];
    //}

    public BaseCategory getListContent(int index)
    {
        return BaseLoadData.Instance.myCategoryData[index];
    }

    public void onStart()
    {
        ListPositionCtrl.Instance.setSlidingEffect(2.0f);
    }

    public int getListLength()
    {
        //return contents.Length;
        return BaseLoadData.Instance.myCategoryData.Count;
    }

    public void categoryHandleEvent(ListBox _boxItem)
    {
        if(_boxItem != null)
        {
			Debug.Log("categoryHandleEvent");

            BaseGameController.Instance.baseCategory = _boxItem.baseCategory;
            gameMenu.updateContent(_boxItem.baseCategory);
			tapToPlayHandleEvent();
            //BaseScreenController.Instance.ShowPopup(BaseScreenType.BS_MENU);
        }
    }

	public void tapToPlayHandleEvent()
	{
		BaseGameController.Instance.GameRestart();
		BaseScreenController.Instance.Show(BaseScreenType.BS_GAME_PLAY);
		BaseGameController.Instance.GameInit();
	}

    //public void categoryHandleEvent(UIWord category)
    //{
    //    Debug.Log("Da click");
    //    baseCategory = null;
    //}
}
