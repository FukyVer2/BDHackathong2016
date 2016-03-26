using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScoreController : MonoBehaviour {

    public RectTransform uiScoreParent;
    //
    public UIScore uiScoreRed;
    public UIScore uiScoreBlue;

    //Lay kich thuoc cua thang cha
    public float parentWidth;
    public float parentHeight;

    //Van toc di chuyen cua cac score
    public float speedY;

    //Luu diem cua cac doi tuong
    public float scoreRed;
    public float scoreBlue;

    //So diem toi da trong mot goi cau hoi
    public float scoreMax;

    void Awake()
    {
        CalSpeed();
    }

    public void Reset()
    {
        scoreBlue = 0;
        scoreRed = 0;
        uiScoreBlue.SetScore(0);
        uiScoreRed.SetScore(0);
        uiScoreBlue.Reset();
        uiScoreRed.Reset();
    }

    public void CalParentSize()
    {
        if (uiScoreParent != null)
        {
            //
            parentHeight = uiScoreParent.rect.height;
            parentWidth = uiScoreParent.rect.width;
        }
        else
        {
#if UNITY_EDITOR
            Debug.Log("Chua cai dat thang cha");
#endif
        }
    }

    public void CalSpeed()
    {
        CalParentSize();
        if (scoreMax != 0)
        {
            speedY = parentHeight / scoreMax;
        }
    }

    public BaseTeamType GetTeamWin()
    {
        if (scoreBlue > scoreRed)
        {
            return BaseTeamType.TEAM_BLUE;
        }
        else
        {
            return BaseTeamType.TEAM_RED;
        }
    }

	public void SetScore(float _scoreBlue, float _scoreRed)
	{
		uiScoreRed.SetScore(_scoreBlue);
		uiScoreBlue.SetScore(_scoreRed);
	}

    public void Move(BaseTeamType _baseTeamType, float _score)
    {
        switch (_baseTeamType)
        {
            case BaseTeamType.NONE:
                break;
            case BaseTeamType.TEAM_RED:
                uiScoreRed.Move(_score * speedY);
                scoreRed += _score;
                uiScoreRed.SetScore(scoreRed);
                break;
            case BaseTeamType.TEAM_BLUE:
                scoreBlue += _score;
                uiScoreBlue.Move(_score * speedY);
                uiScoreBlue.SetScore(scoreBlue);
                break;
            default:
                break;
        }
    }
    [ContextMenu("Move")]
    public void Test()
    {
        Move(BaseTeamType.TEAM_BLUE, 10);
    }

}
