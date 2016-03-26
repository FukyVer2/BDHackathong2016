using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIGameLose : MonoBehaviour {

    public Image uiPhoto;
    //
    public void updateContent()
    {
        BaseCategory _baseCategory = BaseGameController.Instance.baseCategory;
        uiPhoto.sprite = ResourceLoader.GetCategorySprite(_baseCategory.categoryContent.Trim());
    }
    public void closePopupHandleEvent()
    {
        BaseScreenController.Instance.HidePopup(BaseScreenType.BS_GAME_OVER);
        BaseScreenController.Instance.Show(BaseScreenType.BS_WORLD_MAP);
    }

    public void returnMenuHandleEvent()
    {
        BaseGameController.Instance.GameRestart();
        BaseScreenController.Instance.HidePopup(BaseScreenType.BS_GAME_OVER);
        BaseScreenController.Instance.Show(BaseScreenType.BS_WORLD_MAP);
    }
}
