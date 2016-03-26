using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class Title_WM : MonoBehaviour {
    public RectTransform objTitle;

    private Vector3 positionTitle =new Vector3();
    private Vector3 positionTitleMoveTo = new Vector3();

    void Start()
    {
        positionTitle = objTitle.position;
        positionTitleMoveTo = new Vector3(positionTitle.x,positionTitle.y - positionTitle.y/4);
    }

    [ContextMenu("test move!")]
	public void PoiterDown()
    {
        if(objTitle)
        {
            HOTween.To(objTitle, 0.8f, new TweenParms()
                .Prop("position", positionTitleMoveTo,false)
                .OnComplete(PoiterUp)
                );
        }
    }

    public void PoiterUp()
    {
        HOTween.To(objTitle, 0.8f, new TweenParms()
                .Prop("position", positionTitle, false)
                .Delay(0.75f)
                );
    }
}
