using UnityEngine;
using System.Collections;
using System;

public class UIPhotoEffect : MonoBehaviour {

	// Use this for initialization
    public GameObject effect1;
    public GameObject effect2;
    public GameObject effect3;
    public GameObject effect4;
    public GameObject effect5;
    public GameObject effect6;
    public GameObject effect7;
    public GameObject effect8;
    public GameObject effect9;
    public GameObject effect10;
    public GameObject effect11;
    public GameObject effect12;
    public GameObject effectCenter;
    //
    public Vector3 effectPostionStart1;
    public Vector3 effectPostionStart2;
    public Vector3 effectPostionStart3;
    public Vector3 effectPostionStart4;
    public Vector3 effectPostionStart5;
    public Vector3 effectPostionStart6;
    public Vector3 effectPostionStart7;
    public Vector3 effectPostionStart8;
    public Vector3 effectPostionStart9;
    public Vector3 effectPostionStart10;
    public Vector3 effectPostionStart11;
    public Vector3 effectPostionStart12;

    void Start()
    {
        effectPostionStart1 = effect1.transform.localPosition;
        effectPostionStart2 = effect2.transform.localPosition;
        effectPostionStart3 = effect3.transform.localPosition;
        effectPostionStart4 = effect4.transform.localPosition;
        effectPostionStart5 = effect5.transform.localPosition;
        effectPostionStart6 = effect6.transform.localPosition;
        effectPostionStart7 = effect7.transform.localPosition;
        effectPostionStart8 = effect8.transform.localPosition;
        effectPostionStart9 = effect9.transform.localPosition;
        effectPostionStart10 = effect10.transform.localPosition;
        effectPostionStart11 = effect11.transform.localPosition;
        effectPostionStart12 = effect12.transform.localPosition;
        //
        Debug.Log(Screen.width + ":" + Screen.height);
        effect1.transform.localPosition = new Vector3(-700, -900, 0);
        effect2.transform.localPosition = new Vector3(700, -900, 0);
        effect3.transform.localPosition = new Vector3(700, 600, 0);
        effect4.transform.localPosition = new Vector3(-700, 600, 0);
        effect5.transform.localPosition = new Vector3(-700, 900, 0);
        effect6.transform.localPosition = new Vector3(700, 900, 0);
        effect7.transform.localPosition = new Vector3(-700, 400, 0);
        effect8.transform.localPosition = new Vector3(-700, -400, 0);
        effect9.transform.localPosition = new Vector3(-400, -900, 0);
        effect10.transform.localPosition = new Vector3(400, -900, 0);
        effect11.transform.localPosition = new Vector3(700, 400, 0);
        effect12.transform.localPosition = new Vector3(700, -400, 0);
        //
        effectCenter.transform.localScale = Vector3.zero;
    }

    public float beginTime;
    public float endTime;

    public void BeginMove(float _beginTime, float _delayTime) //Bat dau hieu ung trong bao nhieu giay
    {
        beginTime = _beginTime;
        //Invoke("MoveIn", _delayTime);
    }
    public Action callBack;
    public void MoveIn(float _beginTime, float _endtime, Action _callBack)
    {
        beginTime = _beginTime;
        endTime = _endtime;
        callBack = _callBack;
        Tween.RotateTo(beginTime, 3, effectCenter);
        Tween.ScaleTo(beginTime, 1, new Vector3(1f, 1f, 1f), effectCenter);
        //
        Tween.MoveTo(beginTime, 1, effectPostionStart2, effect2);
        Tween.MoveTo(beginTime, 1, effectPostionStart1, effect1);
        Tween.MoveTo(beginTime, 1, effectPostionStart3, effect3);
        Tween.MoveTo(beginTime, 1, effectPostionStart4, effect4);
        Tween.MoveTo(1.4f * beginTime, 1, effectPostionStart5, effect5);
        Tween.MoveTo(1.4f * beginTime, 1, effectPostionStart6, effect6);
        Tween.MoveTo(1.4f * beginTime, 1, effectPostionStart7, effect7);
        Tween.MoveTo(1.4f * beginTime, 1, effectPostionStart8, effect8);
        Tween.MoveTo(1.4f * beginTime, 1, effectPostionStart9, effect9);
        Tween.MoveTo(1.4f * beginTime, 1, effectPostionStart10, effect10);
        Tween.MoveTo(1.4f * beginTime, 1, effectPostionStart11, effect11);
        Tween.MoveTo(1.4f * beginTime, 1, effectPostionStart12, effect12);

        Invoke("CallBack", 1.4f * beginTime + 2.0f);
        Invoke("MoveOut", 1.4f * beginTime + 2.0f);
    }

    public void CallBack()
    {
        if(callBack != null)
        {
            callBack();
            callBack = null;
        }
    }

    public void EndMove(float _endtime, float _delayTime) //Ket thuc hieu ung sau bao nhieu giay
    {
        endTime = _endtime;
        //Invoke("MoveOut", _delayTime);
    }

    public void MoveOut()
    {
        Tween.RotateTo(1.4f * endTime, 3, effectCenter);
        Tween.ScaleTo(endTime, 1, new Vector3(0f, 0f, 0f), effectCenter);
        //
        Tween.MoveTo(endTime, 1, new Vector3(700, -900, 0), effect2);
        Tween.MoveTo(endTime, 1, new Vector3(-700, -900, 0), effect1);
        Tween.MoveTo(endTime, 1, new Vector3(700, 600, 0), effect3);
        Tween.MoveTo(endTime, 1, new Vector3(-700, 600, 0), effect4);
        Tween.MoveTo(1.4f * endTime, 1, new Vector3(-700, 900, 0), effect5);
        Tween.MoveTo(1.4f * endTime, 1, new Vector3(700, 900, 0), effect6);
        Tween.MoveTo(1.4f * endTime, 1, new Vector3(-700, 400, 0), effect7);
        Tween.MoveTo(1.4f * endTime, 1, new Vector3(-700, -400, 0), effect8);
        Tween.MoveTo(1.4f * endTime, 1, new Vector3(-400, -900, 0), effect9);
        Tween.MoveTo(1.4f * endTime, 1, new Vector3(400, -900, 0), effect10);
        Tween.MoveTo(1.4f * endTime, 1, new Vector3(700, 400, 0), effect11);
        Tween.MoveTo(1.4f * endTime, 1, new Vector3(700, -400, 0), effect12);
    }
}
