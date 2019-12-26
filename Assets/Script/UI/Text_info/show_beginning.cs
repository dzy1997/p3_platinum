using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class show_beginning : MonoBehaviour
{
    // denote the length of video
    public float offset_time;
    // denote the next scene it will go to
    public string next_scene;
    // denote the text it controls
    public Text text;
    // denote the fade animator
    public Animator fade_anim;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(show_info());
    }

    IEnumerator show_info()
    {
        yield return new WaitForSeconds(offset_time);
        fade_anim.SetInteger("Fade_state", 1);
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(next_scene);
    }

}
