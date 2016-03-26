using UnityEngine;
using System.Collections;

public class MyImageTarget : MonoBehaviour {

	public BaseTeamType team;
	public string character;

	[ContextMenu("Trackale Target")]
	public void TrackableTarget()
	{

//        if(BaseGameController.Instance.baseWordController.completeChangeWord && !BaseGameController.Instance.gameLose)
//		    BaseGameController.Instance.baseWordController.uiWordEffect.GiveCharacter (character [0], team);

		GamePlayController.Instance.TrackableCharacter (character [0], team);
		SoundManager.Instance.PlaySoundWithName (character);
	}
}
