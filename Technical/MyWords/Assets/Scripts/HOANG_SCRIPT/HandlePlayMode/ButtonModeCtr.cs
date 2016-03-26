using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonModeCtr : MonoBehaviour {
	Image myImg;
	public BaseModeLevel baseModeLevel;
	public Sprite activeSprite;
	public Sprite disActiveSprite;
	public Color disActiveColor;

	void Awake()
	{
		myImg = GetComponent<Image> ();
	}

	public void ActiveButton()
	{
		myImg.sprite = activeSprite;
		myImg.color = Color.white;
	}

	public void DisActiveButton()
	{
		myImg.sprite = disActiveSprite;
		myImg.color = disActiveColor;
	}
}
