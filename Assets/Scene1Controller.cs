using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene1Controller : ControllerBase
{
    public Text text;

    void Awake()
    {
        SceneStack.Instance().Init();
        SceneStack.Instance().SetFirstScene("Scene1", this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        text.text = "clicked";
        SceneStack.Instance().Push("Scene2");
    }
}
