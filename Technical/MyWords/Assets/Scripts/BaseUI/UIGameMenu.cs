using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIGameMenu : MonoBehaviour {

    public Image uiPhoto;
    public Text uiText;
    //
    public void updateContent(BaseCategory _baseCategory)
    {
        uiPhoto.sprite = ResourceLoader.GetCategorySprite(_baseCategory.categoryContent.Trim());
        uiText.text = _baseCategory.categoryContent;
    }
	public void closePopupHandleEvent(){
        BaseScreenController.Instance.HidePopup(BaseScreenType.BS_MENU);
    }

    public void tapToPlayHandleEvent()
    {
        BaseGameController.Instance.GameRestart();
        BaseScreenController.Instance.HidePopup(BaseScreenType.BS_MENU);
        BaseScreenController.Instance.Show(BaseScreenType.BS_GAME_PLAY);
        BaseGameController.Instance.GameInit();
    }
}
