using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

class SceneInfo
{
    public string sceneName;
    public ControllerBase controller;
}

public class SceneStack
{
    private static SceneStack instance;

    private LinkedList<SceneInfo> sceneList;

    public static SceneStack Instance()
    {
        if (instance == null)
        {
            instance = new SceneStack();
        }
        return instance;
    }

    public void Init()
    {
        sceneList = new LinkedList<SceneInfo>();
    }

    // after first scene is loaded, call this function to add it to stack
    public void SetFirstScene(string sceneName, ControllerBase controller)
    {
        SceneInfo sceneInfo = new SceneInfo();
        sceneInfo.sceneName = sceneName;
        sceneInfo.controller = controller;
        sceneList.AddLast(sceneInfo);
    }

    // hide current scene, then load new scene
    public void Push(string sceneName)
    {
        if (sceneList.Count > 0)
        {
            sceneList.Last.Value.controller.Hide();
        }
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        SceneInfo sceneInfo = new SceneInfo();
        sceneInfo.sceneName = sceneName;
        sceneList.AddLast(sceneInfo);
    }

    public void SetCurrentController(ControllerBase controller)
    {
        sceneList.Last.Value.controller = controller;
    }

    public void Pop()
    {
        if (sceneList.Count < 2)
        {
            return;
        }

        SceneManager.UnloadSceneAsync(sceneList.Last.Value.sceneName);
        sceneList.RemoveLast();
        sceneList.Last.Value.controller.Show();
    }
}
