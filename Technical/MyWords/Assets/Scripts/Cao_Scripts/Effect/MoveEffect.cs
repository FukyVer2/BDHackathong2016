using UnityEngine;
using System.Collections;
using Holoville.HOTween;
public class MoveEffect : GUIEffect
{

    public void StartEffect(Transform tranfs, EffectInfo info)
    {
        HOTween.To(tranfs, info.timeMove, new TweenParms()
            .Prop("localPosition", info.posTarget, false)
            .Ease(info.typeMove)
            .Delay(info.timeDelayMove)
            .Loops(info.loopMove, info.typeLoopMove)
            );
    }

    public void EndEffect(Transform tranfs, EffectInfo info)
    {
        HOTween.To(tranfs, info.timeMove, new TweenParms()
            .Prop("localPosition", info.posEnd, false)
            .Ease(info.typeMove)
            .Delay(info.timeDelayMove)
            .Loops(info.loopMove, info.typeLoopMove)
            );
    }
}
