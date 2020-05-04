using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBase : MonoBehaviour
{
    // root element, commonly it's a canvas
    public GameObject ui;

    void Awake()
    {
        SceneStack.Instance().SetCurrentController(this);
    }

    public virtual void Show()
    {
        ui?.SetActive(true);
    }

    public virtual void Hide()
    {
        ui?.SetActive(false);
    }
}
