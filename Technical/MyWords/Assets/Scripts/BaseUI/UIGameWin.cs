using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIGameWin : MonoBehaviour {

    public Image uiPhoto;
    public BaseTeamType teamType;
    //
    public void updateContent()
    {
        BaseCategory _baseCategory = BaseGameController.Instance.baseCategory;
        uiPhoto.sprite = ResourceLoader.GetCategorySprite(_baseCategory.categoryContent.Trim());
    }
    public void closePopupHandleEvent()
    {
        if(teamType != BaseTeamType.TEAM_BLUE)
            BaseScreenController.Instance.HidePopup(BaseScreenType.BS_GAME_WIN_RED);
        else
            BaseScreenController.Instance.HidePopup(BaseScreenType.BS_GAME_WIN_BLUE);
        BaseScreenController.Instance.Show(BaseScreenType.BS_WORLD_MAP);
    }

    public void returnMenuHandleEvent()
    {
        closePopupHandleEvent();
        BaseScreenController.Instance.Show(BaseScreenType.BS_WORLD_MAP);
    }
}
