using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BaseButton : MonoBehaviour {

    ChangeScreen _ChangeScreenManager;
    public ChangeScreen menuManager
    {
        get
        {
            if (_ChangeScreenManager == null)
                _ChangeScreenManager = FindObjectOfType<ChangeScreen>();

            return _ChangeScreenManager;
        }
    }

    
    virtual public void OnClicked() { }

    void OnEnable()
    {
        Debug.Log("ENAVLE!");
        GetComponent<Button>().onClick.AddListener(OnClicked);
    }

    void OnDisable()
    {
        RemoveListener();
    }

    public void RemoveListener()
    {
        GetComponent<Button>().onClick.RemoveListener(OnClicked);
    }
}
