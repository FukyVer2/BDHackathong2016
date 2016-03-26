using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class UIWordPrefab : MonoBehaviour
{
    public GameObject wordBasic;
    public GameObject wordContent;

    public Image wordBasicImage;
    public Image wordContentImage;

    public Text wordBasicText;
    public Text wordContentText;

    private UIWordType uiWordType;
    //
    private string wordText;
    private int wordScore;
    public Vector3 wordPosition;
    //
    public Color blueColor;
    public Color blue2Color;
    public Color redColor;
    public Color red2Color;
    public Color greenColor;

    public UIWordType UIWordType
    {
        get { return uiWordType; }
        set
        {
            uiWordType = value;
            // Set lai color cua cac hinh   
            switch (uiWordType)
            {
                case global::UIWordType.BLUE:
                    wordBasicImage.color = blueColor;
                    wordContentImage.color = blue2Color;
                    break;
                case global::UIWordType.RED:
                    wordBasicImage.color = redColor;
                    wordContentImage.color = red2Color;
                    break;
                case global::UIWordType.NONE:
                    wordBasicImage.color = greenColor;
                    wordContentImage.color = greenColor;
                    break;
            }
        }
    }

    public Vector3 position;
	public float scaleWhenFinish;

    [ContextMenu("Test position")]
    public void TestPosition()
    {
        wordBasic.transform.position = position;
        wordContent.transform.position = position;
    }

    void Start()
    {
        //wordPosition = gameObject.transform.localPosition;
        // wordContentViewImage.color = greenColor;
        //wordBasic.transform.localScale = Vector3.zero;
        //wordContent.transform.localScale = Vector3.zero;
        //wordBasic.SetActive(false);
        //wordContent.SetActive(false);
        //gameObject.SetActive(false);
    }

    public void Show()
    {
        wordBasic.transform.localScale = Vector3.zero;
        wordContent.transform.localScale = Vector3.zero;
        wordBasic.SetActive(false);
        wordContent.SetActive(false);
        //wordPosition = gameObject.transform.localPosition;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public string WordText
    {
        get
        {
            return wordText;
        }
        set
        {
            wordText = value;
            wordContentText.text = wordText;
        }
    }

    public int WordScore
    {
        get
        {
            return wordScore;
        }
        set
        {
            wordScore = value;
            wordBasicText.text = wordScore.ToString();
        }
    }

    public Vector3 positionMoveUpTo;
    private Action callBack;
    public void MoveUp(Vector3 _position, float _time, float _timeDelay, Action _callBack)
    {
        callBack = _callBack;
        wordBasic.SetActive(true);
        wordContent.SetActive(true);
        wordBasic.transform.position = new Vector3(0, wordBasic.transform.position.y, 0);
        wordContent.transform.position = new Vector3(0, wordContent.transform.position.y, 0);
        gameObject.transform.position = _position;
        gameObject.transform.localScale = new Vector3(scaleWhenFinish, scaleWhenFinish, scaleWhenFinish);
        positionMoveUpTo = _position;
        CallBack();
    }


    void CallBack()
    {
        if (callBack != null)
        {
            callBack();
            callBack = null;
        }
    }

    public void DestroyWord()
    {
        GameObject.Destroy(gameObject, 1.0f);
    }

    public void MoveToCenter(float _time)
    {
        wordPosition = gameObject.transform.localPosition;
        iTween.MoveTo(gameObject, iTween.Hash(//iT.MoveTo.islocal, true,
                                             iT.MoveTo.time, _time,
                                             iT.MoveTo.position, new Vector3(0, transform.position.y, 0),
                                             iT.MoveTo.easetype, iTween.EaseType.easeInOutExpo));
    }

    public void MoveToLR(float _time)
    {
        iTween.MoveTo(gameObject, iTween.Hash(iT.MoveTo.islocal, true,
                                      iT.MoveTo.time, _time,
                                      iT.MoveTo.position, wordPosition,
                                      iT.MoveTo.easetype, iTween.EaseType.easeInOutQuint));
    }
}
