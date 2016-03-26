using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIPhoto : MonoBehaviour {

    public Image uiPhotoContent;
    private Sprite uiPhotoSprite;
    //public UIPhotoEffect uiPhotoEffect;

    public void Reset()
    {
        uiPhotoSprite = null;
        uiPhotoContent.sprite = uiPhotoSprite;
    }

    public Image UIPhotoContent
    {
        get { return uiPhotoContent; }
    }

    public Sprite UIPhotoSprite
    {
        get { return uiPhotoSprite; }
        set
        {
            uiPhotoSprite = value;
            uiPhotoContent.sprite = uiPhotoSprite;
        }
    }

    public void SetSprite()
    {
        uiPhotoContent.sprite = uiPhotoSprite;
    }

    public void PhotoChanged(Sprite _sprite)
    {
        if (_sprite != null)
        {
            uiPhotoSprite = _sprite;
			SetSprite();
			//Hoang comment
			//uiPhotoEffect.MoveIn(0.7f ,0.7f, SetSprite);
            

			//uiPhotoEffect.MoveOut();
            //uiPhotoEffect.BeginMove(0.7f, 0.0f);
            //Invoke("SetSprite", 2.0f);
            //uiPhotoEffect.EndMove(0.7f, 2.5f);
        }
    }
}
