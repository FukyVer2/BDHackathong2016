using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIWordWrong : MonoBehaviour {

    public GameObject wordWrongBlue;
    public GameObject wordWrongRed;
    public GameObject wordWrongBasicActive;
    public GameObject wordWrongBasicDeActive;
    //
    public Color wordWrongColorRed;
    public Color wordWrongColorBlue;
    public Color wordWrongColorGreen;
    //
    public Text wordWrongContentText;
    //
    private string wordWrongText;
    private UIWordType wordWrongType;
    //
    private bool isActive;
    private bool isUse;

    public string WordWrongText
    {
        get { return wordWrongText; }
        set
        {
            wordWrongText = value;
            wordWrongContentText.text = wordWrongText;
        }
    }

    public bool IsActive
    {
        get { return isActive; }
        set
        {
            isActive = value;
            if (!value)
            {
                WordWrongType = UIWordType.DEACTIVE;
            }
            else
            {
                WordWrongType = UIWordType.ACTIVE;
            }
        }
    }

    public bool IsUse
    {
        get { return isUse; }
        set
        {
            isUse = value;
        }
    }

    public UIWordType WordWrongType
    {
        get { return wordWrongType; }
        set
        {
            wordWrongType = value;
            // Set lai color cua cac hinh   
            switch (wordWrongType)
            {
                case global::UIWordType.BLUE:
                    wordWrongBlue.SetActive(true);
                    wordWrongRed.SetActive(false);
                    wordWrongBasicActive.SetActive(false);
                    wordWrongBasicDeActive.SetActive(false);
                    wordWrongContentText.color = wordWrongColorBlue;
                    break;
                case global::UIWordType.RED:
                    wordWrongBlue.SetActive(false);
                    wordWrongRed.SetActive(true);
                    wordWrongBasicActive.SetActive(false);
                    wordWrongBasicDeActive.SetActive(false);
                    wordWrongContentText.color = wordWrongColorRed;
                    break;
                case global::UIWordType.ACTIVE:
                    wordWrongBlue.SetActive(false);
                    wordWrongRed.SetActive(false);
                    wordWrongBasicActive.SetActive(true);
                    wordWrongBasicDeActive.SetActive(false);
                    wordWrongContentText.color = wordWrongColorGreen;
                    break;
                case global::UIWordType.DEACTIVE: case global::UIWordType.NONE:
                    wordWrongBlue.SetActive(false);
                    wordWrongRed.SetActive(false);
                    wordWrongBasicActive.SetActive(false);
                    wordWrongBasicDeActive.SetActive(true);
                    wordWrongContentText.color = wordWrongColorGreen;
                    break;
            }
        }
    }

    void Start()
    {
        //ReStart();
        WordWrongText = "";
    }

    public void ReStart()
    {
        WordWrongType = UIWordType.NONE;
        WordWrongText = "";
        
    }
}
