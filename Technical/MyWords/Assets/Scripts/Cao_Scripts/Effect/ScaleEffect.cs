using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class ScaleEffect : GUIEffect 
{


    public void StartEffect(Transform tranfs, EffectInfo info)
    {
        HOTween.To(tranfs, info.timeScale, new TweenParms()
            .Prop("localScale", info.scaleTarget, false)
            .Ease(info.typeScale)
            .Delay(info.timeDelayScale)
            .Loops(info.loopScale, info.typeLoopScale)
            );
    }

    public void EndEffect(Transform tranfs, EffectInfo info)
    {
        HOTween.To(tranfs, info.timeScale, new TweenParms()
            .Prop("localScale", info.scaleEnd, false)
            .Ease(info.typeScale)
            .Delay(info.timeDelayScale)
            .Loops(info.loopScale, info.typeLoopScale)
            );
    }
}
