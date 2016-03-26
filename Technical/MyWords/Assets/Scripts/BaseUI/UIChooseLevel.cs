using UnityEngine;
using System.Collections;

public class UIChooseLevel : MonoBehaviour {

	void Show()
	{

	}

	void Hide() 
	{
		gameObject.SetActive (false);
	}

	void BntChooseLevel(BaseModeLevel modeLevel)
	{
		BaseGameController.Instance.baseModeLevel = modeLevel;
	}
}
