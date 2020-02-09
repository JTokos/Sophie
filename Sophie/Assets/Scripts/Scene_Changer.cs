using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Changer : MonoBehaviour
{

    public string sceneName;

    public void SceneChange()
    {
        SceneManager.LoadScene(sceneName);
    }
}
