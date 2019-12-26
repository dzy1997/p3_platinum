using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // the scene it will direct to
    public string scene_name;

    public void OnClick()
    {
        SceneManager.LoadScene(scene_name);
    }
}