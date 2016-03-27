using UnityEngine;
using System.Collections;
using System;

public class ChangeScreen : MonoBehaviour {

    public GameObject PAUSE;

    public GameObject GAME_PLAY;

	// Use this for initialization
	void Start () {
	
	}

    public void OpenSettings()
    {
        float time = 0.2f;
        GoOut(GAME_PLAY, time, 0);
        GoIn(PAUSE, time, time);
    }

    //close the setting menu
    public void CloseSettings()
    {
        float time = 0.2f;
        GoOut(PAUSE, time, 0);
        GoIn(GAME_PLAY, time, time);

    }

    public void GoOut(GameObject obj, float time, float delay)
    {
        obj.transform.localScale = Vector3.one;
        StartCoroutine(GoInOrOutCorout(obj, 0, time, delay, () =>
        {
            obj.transform.localScale = Vector3.zero;
            obj.SetActive(false);
        }));

    }

    public void GoIn(GameObject obj, float time, float delay)
    {
        obj.transform.localScale = Vector3.zero;
        StartCoroutine(GoInOrOutCorout(obj, 1, time, delay, () =>
        {
            obj.transform.localScale = Vector3.one;
            obj.SetActive(true);
        }));

    }

    IEnumerator GoInOrOutCorout(GameObject obj, float scale, float time, float delay, Action callback)
    {
        obj.SetActive(true);

        yield return new WaitForSeconds(delay);

        var originalScale = obj.transform.localScale;
        var targetScale = Vector3.one * scale;
        var originalTime = time;

        while (time > 0.0f)
        {
            time -= Time.deltaTime;
            obj.transform.localScale = Vector3.Lerp(targetScale, originalScale, time / originalTime);
            yield return 0;
        }

        if (callback != null)
            callback();
    }

}
