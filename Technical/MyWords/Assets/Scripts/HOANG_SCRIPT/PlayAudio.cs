using UnityEngine;
using System.Collections;

public class PlayAudio : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SoundManager.Instance.PlaySoundWithType(AudioType.BACKGROND);
	}

    void OnEnable()
    {
        Debug.Log("play");
        //SoundManager.Instance.PlaySoundWithType(AudioType.BACKGROND);
    }

    void OnDisnable()
    {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
