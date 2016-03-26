using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScore : MonoBehaviour {

    public float moveSpeed;
    private bool isMove;
    private float moveSpace;
    private float moveSpaceCurrent;
    //
    public RectTransform scoreRectTransform;
    public Text scoreText;
    //
    public Vector2 scorePosition;

    void Start()
    {
        if (scoreRectTransform != null)
        {
            scorePosition = scoreRectTransform.anchoredPosition;
        }
    }

    private Vector2 startPosition;
    private bool isSaveStartPosition = false;
    public void Reset()
    {
        //if (scoreRectTransform != null)
        //{
        //    scoreRectTransform.anchoredPosition = startPosition;
        //}
    }

    public void SetScore(float _score)
    {
        scoreText.text = _score.ToString();
    }


    public void Move(float _moveSpace)
    {
        moveSpace = _moveSpace;
        moveSpaceCurrent = 0.0f;
        isMove = true;
        if (scoreRectTransform != null)
        {
            //if (!isSaveStartPosition)
            //{
            //    startPosition = scoreRectTransform.anchoredPosition;
            //    isSaveStartPosition = true;
            //}
            scorePosition = scoreRectTransform.anchoredPosition;
        }
    }

    void Update()
    {
//        if (isMove)
//        {
//            if (moveSpaceCurrent >= moveSpace)
//            {
//                isMove = false;
//            }
//            else
//            {
//                if (scoreRectTransform != null)
//                {
//                    scorePosition.y += moveSpeed * Time.deltaTime;
//                    moveSpaceCurrent += moveSpeed * Time.deltaTime;
//                    scoreRectTransform.anchoredPosition = scorePosition;
//                }
//                else
//				{
//                    isMove = false;
//				}
//            }
//        }
    }
}
