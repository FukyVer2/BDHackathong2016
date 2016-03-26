using UnityEngine;
using System.Collections;

public class UITileLayout : MonoBehaviour {

    public int childID;
    public bool isMaxSize;

    private Vector2 childPosition;

    public Vector2 SetChildPosition
    {
        get { return childPosition;}
        set { childPosition = value;
              gameObject.GetComponent<RectTransform>().anchoredPosition = childPosition; }
    }

    public Vector2 SetChildSize
    {
        set { gameObject.GetComponent<RectTransform>().sizeDelta = value; }
    }

    public void EventClick()
    {
        UIGridLayout.Instance.childIdIndex = childID;
        UIGridLayout.Instance.SetSizeOfChild();
    }
}
