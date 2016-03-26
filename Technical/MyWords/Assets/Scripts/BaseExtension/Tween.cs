using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class Tween {

    public static void RotateTo(float _time, int _repeat, float _speed, GameObject _target)
    {
        if (_target != null)
        {
            _target.AddComponent<RotateTo>().TweenInit(_time, _repeat, _speed, _target);
        }
    }

    public static void RotateTo(float _time, int _repeat, GameObject _target)
    {
        if (_target != null)
        {
            _target.AddComponent<RotateTo>().TweenInit(_time, _repeat, _target);
        }
    }

    public static void ScaleTo(float _time, int _repeat, Vector3 _targetScale  , GameObject _target)
    {
        if (_target != null)
        {
            _target.AddComponent<ScaleTo>().TweenInit(_time, _repeat, _targetScale, _target);
        }
    }

    public static void MoveTo(float _time, int _repeat, Vector3 _targetPosition, GameObject _target)
    {
        if (_target != null)
        {
            _target.AddComponent<MoveTo>().TweenInit(_time, _repeat, _targetPosition, _target);
        }
    }

    public static void ColorTo(float _time, int _repeat, Color _targetColor, Image _targetImage, GameObject _target)
    {
        if (_targetImage != null)
        {
            _target.AddComponent<ColorTo>().TweenInit(_time, _repeat, _targetColor, _targetImage, _target);
        }
    }
}

public abstract class BaseTween : MonoBehaviour
{
    public float time;
    public float speed;
    public float repeat;
    public GameObject target;
    public abstract void TweenExecute();
    //public abstract void TweenExecute(Action<BaseTween> _callBack);

    void Update()
    {
        TweenExecute();
    }
}

public class RotateTo : BaseTween
{
    public Vector3 rotationTarget;

    public void TweenInit(float _time, int _repeat, float _speed, GameObject _target)
    {
        time = _time;
        repeat = _repeat;
        speed = _speed;
        target = _target;
        rotationTarget = _target.transform.localRotation.eulerAngles;

    }

    public void TweenInit(float _time, int _repeat, GameObject _target)
    {
        time = _time;
        repeat = _repeat;
        speed = (_repeat * 360 * Time.deltaTime) / _time;
        target = _target;
        rotationTarget = _target.transform.localRotation.eulerAngles;

    }

    public override void TweenExecute()
    {
        if (repeat <= 0)
        {
            target.transform.localRotation = Quaternion.Euler(Vector3.zero);
            Destroy(target.GetComponent<RotateTo>());
            return;
        }
        //timeCurrent += Time.deltaTime;
        rotationTarget.z -= speed;// *Time.deltaTime;
        target.transform.localRotation = Quaternion.Euler(rotationTarget);
        if (rotationTarget.z <= -360)
        {
            repeat -= 1;
            //uiPhotoObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
            rotationTarget.z = 0;
            //timeCurrent = 0.0f;
        }

    }

}

public class ScaleTo : BaseTween
{
    public Vector3 localScale;
    public Vector3 targetScale;
    private Vector3 startScale;
    private float xSpeed;
    private float ySpeed;
    private float zSpeed;

    public void TweenInit(float _time, int _repeat, float _speed, Vector3 _targetScale, GameObject _target)
    {
        time = _time;
        repeat = _repeat;
        speed = _speed;
        target = _target;
        localScale = _target.transform.localScale;
        targetScale = _targetScale;
        startScale = localScale;

    }

    public void TweenInit(float _time, int _repeat, Vector3 _targetScale, GameObject _target)
    {
        time = _time;
        repeat = _repeat;
        target = _target;
        localScale = _target.transform.localScale;
        targetScale = _targetScale;
        startScale = localScale;
        xSpeed = (targetScale.x - localScale.x) * _repeat * Time.deltaTime / _time;
        ySpeed = (targetScale.y - localScale.y) * _repeat * Time.deltaTime / _time;
        zSpeed = (targetScale.z - localScale.z) * _repeat * Time.deltaTime / _time;
    }

    public override void TweenExecute()
    {
        if (repeat <= 0)
        {
            target.transform.localScale = targetScale;
            Destroy(target.GetComponent<ScaleTo>());
            return;
        }
        //timeCurrent += Time.deltaTime;
        localScale.x += xSpeed;
        localScale.y += ySpeed;
        localScale.z += zSpeed;
        target.transform.localScale = localScale;
        if (Mathf.Abs(localScale.x - startScale.x)>= Mathf.Abs(targetScale.x - startScale.x))
        {
            repeat -= 1;
            if (repeat < 0)
            {
                //uiPhotoObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
                localScale.x = targetScale.x;
                localScale.y = targetScale.y;
                localScale.z = targetScale.z;
            }
            else
            {
                localScale = startScale;
            }
            //timeCurrent = 0.0f;
        }

    }
}

public class MoveTo : BaseTween
{
    public Vector3 localPosition;
    public Vector3 targetPostition;
    private Vector3 startPosition;
    private float xSpeed;
    private float ySpeed;
    private float zSpeed;

    public void TweenInit(float _time, int _repeat, float _speed, Vector3 _targetPosition, GameObject _target)
    {
        time = _time;
        repeat = _repeat;
        speed = _speed;
        target = _target;
        localPosition = _target.transform.localPosition;
        targetPostition = _targetPosition;
        startPosition = localPosition;

    }

    public void TweenInit(float _time, int _repeat, Vector3 _targetPosition, GameObject _target)
    {
        time = _time;
        repeat = _repeat;
        target = _target;
        localPosition = _target.transform.localPosition;
        targetPostition = _targetPosition;
        startPosition = localPosition;
        xSpeed = (targetPostition.x - localPosition.x) * _repeat * Time.deltaTime / _time;
        ySpeed = (targetPostition.y - localPosition.y) * _repeat * Time.deltaTime / _time;
        zSpeed = (targetPostition.z - localPosition.z) * _repeat * Time.deltaTime / _time;
    }

    public override void TweenExecute()
    {
        if (repeat <= 0)
        {
            target.transform.localPosition = targetPostition;
            Destroy(target.GetComponent<MoveTo>());
            return;
        }
        //timeCurrent += Time.deltaTime;
        localPosition.x += xSpeed;
        localPosition.y += ySpeed;
        localPosition.z += zSpeed;
        target.transform.localPosition = localPosition;
        if (Mathf.Abs(localPosition.x - startPosition.x) >= Mathf.Abs(targetPostition.x - startPosition.x))
        {
            repeat -= 1;
            if (repeat < 0)
            {
                //uiPhotoObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
                localPosition.x = targetPostition.x;
                localPosition.y = targetPostition.y;
                localPosition.z = targetPostition.z;
            }
            else
            {
                localPosition = startPosition;
            }
            //timeCurrent = 0.0f;
        }

    }
}
public class ColorTo : BaseTween
{
    public Color localColor;
    public Color targetColor;
    private Color startColor;
    private Image targetImage;
    private float rSpeed;
    private float bSpeed;
    private float gSpeed;

    public void TweenInit(float _time, int _repeat, float _speed, Color _targetColor, Image _targetImage, GameObject _target)
    {
        time = _time;
        repeat = _repeat;
        speed = _speed;
        target = _target;
        targetImage = _targetImage;
        localColor = targetImage.color;
        targetColor = _targetColor;
        startColor = localColor;

    }

    public void TweenInit(float _time, int _repeat, Color _targetColor, Image _targetImage, GameObject _target)
    {
        time = _time;
        repeat = _repeat;
        target = _target;
        targetImage = _targetImage;
        localColor = targetImage.color;
        targetColor = _targetColor;
        startColor = localColor;
        rSpeed = (targetColor.r - localColor.r) * _repeat * Time.deltaTime / _time;
        bSpeed = (targetColor.b - localColor.b) * _repeat * Time.deltaTime / _time;
        gSpeed = (targetColor.g - localColor.g) * _repeat * Time.deltaTime / _time;
    }

    public override void TweenExecute()
    {
        if (repeat <= 0)
        {
            targetImage.color = targetColor;
            Destroy(target.GetComponent<ColorTo>());
            return;
        }
        //timeCurrent += Time.deltaTime;
        localColor.r += rSpeed;
        localColor.b += bSpeed;
        localColor.g += gSpeed;
        targetImage.color = localColor;
        if (Mathf.Abs(localColor.r - startColor.r) >= Mathf.Abs(targetColor.r - startColor.r))
        {
            repeat -= 1;
            if (repeat < 0)
            {
                //uiPhotoObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
                localColor = targetColor;
            }
            else
            {
                localColor = startColor;
            }
            //timeCurrent = 0.0f;
        }

    }
}