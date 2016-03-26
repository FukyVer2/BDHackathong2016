using UnityEngine;
using System.Collections;
using Holoville.HOTween;
[System.Serializable]
public class EffectInfo
{
    public Vector3 posStart;
    public Vector3 posTarget;
    public Vector3 posEnd;

    public float timeMove;
    public float timeDelayMove;
    public EaseType typeMove;
    public int loopMove;
    public LoopType typeLoopMove;

    public Vector3 scaleStart;
    public Vector3 scaleTarget;
    public Vector3 scaleEnd;

    public float timeScale;
    public float timeDelayScale;
    public EaseType typeScale;
    public int loopScale;
    public LoopType typeLoopScale;

}
public interface GUIEffect
{
    void StartEffect(Transform tranfs, EffectInfo effectInfo);

    void EndEffect(Transform tranfs, EffectInfo effectInfo);
}
