using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseScreenController  : MonoSingleton<BaseScreenController>
{
    public List<ScreenConfig> screenContains;
    private Dictionary<BaseScreenType, GameObject[]> dicScreenContains;

    public GameObject[] screenCurrent;

    void Awake()
    {
        dicScreenContains = new Dictionary<BaseScreenType, GameObject[]>();
        ConvertToDictionary();
    }

    void ConvertToDictionary()
    {
        foreach (var screenConfig in screenContains)
        {
            dicScreenContains.Add(screenConfig.baseScreenType, screenConfig.screen);
        }
    }

    public void Show(BaseScreenType _baseScreenType)
    {
        if (screenCurrent != null)
        {
            //screenCurrent.SetActive(false);
            DeActiveAllScreen(screenCurrent);
        }
        screenCurrent = GetScreenByType(_baseScreenType);
        ActiveAllScreen(screenCurrent);
        //if(screenCurrent != null)
        //    screenCurrent.SetActive(true);
    }

    private GameObject[] screenOnlyShow;
    private void ShowOnly(BaseScreenType _baseScreenType)
    {
        //GameObject screen =  GetScreenByType(_baseScreenType)[0];
        //if (screen != null)
        //    screen.SetActive(true);
        if (screenOnlyShow != null)
            DeActiveAllScreen(screenOnlyShow);
        GameObject[] screen = GetScreenByType(_baseScreenType);
        screenOnlyShow = screen;
        ActiveAllScreen(screen);
    }

    private void HideOnly()
    {
        if (screenOnlyShow != null)
        {
            DeActiveAllScreen(screenOnlyShow);
            screenOnlyShow = null;
        }
    }

    public void ShowPopup(BaseScreenType _baseScreenType)
    {
        ShowOnly(BaseScreenType.BS_NOTIFICATION);
        GameObject screen = GetScreenByType(_baseScreenType)[0];
        if (screen != null)
        {
            screen.transform.localScale = Vector3.zero;
            screen.SetActive(true);
            iTween.ScaleTo(screen, iTween.Hash(iT.ScaleTo.time, 0.6f,
                                               iT.ScaleTo.scale, Vector3.one,
                                               iT.ScaleTo.easetype, iTween.EaseType.easeInSine));
        }
    }

    public void Hide(BaseScreenType _baseScreenType)
    {
        //screenCurrent = GetScreenByType(_baseScreenType)[0];
        //if (screenCurrent != null)
        //    screenCurrent.SetActive(true);
        screenCurrent = GetScreenByType(_baseScreenType);
        DeActiveAllScreen(screenCurrent);
    }

    public void ActiveAllScreen(GameObject[] _multiScreen)
    {
        if (_multiScreen != null)
        {
            foreach (var screen in _multiScreen)
            {
                if (screen != null)
                {
                    screen.SetActive(true);
                }
            }
        }
    }

    public void DeActiveAllScreen(GameObject[] _multiScreen)
    {
        if (_multiScreen != null)
        {
            foreach (var screen in _multiScreen)
            {
                if (screen != null)
                {
                    screen.SetActive(false);
                }
            }
        }
    }

    public GameObject screenPopup;
    public void HidePopup(BaseScreenType _baseScreenType)
    {
        GameObject screen = GetScreenByType(_baseScreenType)[0];
        screenPopup = screen;
        if (screen != null)
        {
            iTween.ScaleTo(screen, iTween.Hash(iT.ScaleTo.time, 0.3f,
                                               iT.ScaleTo.scale, Vector3.zero,
                                               iT.ScaleTo.easetype, iTween.EaseType.easeInSine));
        }
        Invoke("HidePopup", 0.3f);
    }

    void HidePopup()
    {
        if (screenPopup != null)
        {
            screenPopup.SetActive(false);
            screenPopup = null;
        }
        HideOnly();
    }

    public GameObject[] GetScreenByType(BaseScreenType _baseScreenType)
    {
        if (dicScreenContains.ContainsKey(_baseScreenType))
            return dicScreenContains[_baseScreenType];
#if UNIT_EDITOR
        Debug.log("Khong co man hinh nay ba oi");
#endif
        return null;
    }
}

[System.Serializable]
public class ScreenConfig
{
    public BaseScreenType baseScreenType;
    public GameObject[] screen;
}


public enum BaseScreenType
{
    BS_WORLD_MAP= 0,
    BS_MENU = 1,
    BS_GAME_PLAY = 2,
    BS_NOTIFICATION = 3,
    BS_GAME_START = 4,
    BS_GAME_WIN_RED = 5,
    BS_GAME_WIN_BLUE = 6,
    BS_GAME_OVER = 7,
	BS_GAME_PAUSE = 8,
	BS_GAME_LIBRARY = 9
}