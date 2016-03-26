using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class UIWord : MonoBehaviour {

    public GameObject wordBasic;
    public GameObject wordContent;
    public GameObject wordContentView;
    //
    public Image wordBasicImage;
    public Image wordContentImage;
    public Image wordContentViewImage;
    //
    public Text wordBasicText;
    public Text wordContentText;
    public Text wordContentViewText;
    //
    private UIWordType uiWordType;
    //
    private string wordText;
	public int index;
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
        set {
                uiWordType = value; 
                // Set lai color cua cac hinh   
                switch (uiWordType)
                {
                    case global::UIWordType.BLUE:
                        wordBasicImage.color = blueColor;
                        wordContentImage.color = blue2Color;
                        wordContentViewImage.color = greenColor;
                        break;
                    case global::UIWordType.RED:
                        wordBasicImage.color = redColor;
                        wordContentImage.color = red2Color;
                        wordContentViewImage.color = greenColor;
                        break;
                    case global::UIWordType.NONE:
                        wordBasicImage.color = greenColor;
                        wordContentImage.color = greenColor;
                        wordContentViewImage.color = greenColor;
                        break;
                }
            }
    }

    public Vector3 position;

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
        wordContentViewImage.color = greenColor;
        wordBasic.transform.localScale = Vector3.zero;
        wordContent.transform.localScale = Vector3.zero;
        wordBasic.transform.localPosition = Vector3.zero;
        wordContent.transform.localPosition = Vector3.zero;
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
            wordContentViewText.text = wordText;
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
            wordBasicText.text = "+" + wordScore.ToString();
        }
    }

    public void OnWordValueChanged()
    {
        wordBasic.SetActive(true);
        wordContent.SetActive(true);
        wordBasic.transform.localScale = Vector3.one;
        wordContent.transform.localScale = Vector3.one;
        wordContentImage.color = greenColor;
    }

	public void StopItween()
	{
		iTween.Stop (wordContent);
		iTween.Stop (wordBasic);
		iTween.Stop (gameObject);

	}
}
 
