using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class MoveIcon_WM : MonoBehaviour {
    private Vector3 postionMoveTo = new Vector3();
	// Use this for initialization
	void Start () {
        Vector3 temp = gameObject.GetComponent<RectTransform>().position;
        postionMoveTo = new Vector3(temp.x, temp.y + 0.2f);
        StartAnimationMove();
	}
    public void StartAnimationMove()
    {
        HOTween.To(gameObject.GetComponent<RectTransform>(), 0.5f, new TweenParms()
            .Prop("position", postionMoveTo,false)
            .Loops(-1, LoopType.Yoyo)
            .Delay(Random.Range(0.1f,0.5f))
            );
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
