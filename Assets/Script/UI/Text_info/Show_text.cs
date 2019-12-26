using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show_text : MonoBehaviour
{
    // denote the text if controls
    public Text info;

    // denote the state of showing routine
    private bool isShow;

    // Start is called before the first frame update
    void Start()
    {
        isShow = false;
        info.text = "";
    }

    // the interface that outside can use this method
    public void Display_txt(string txt, float time)
    {
        if (!isShow)
        {
            isShow = true;
            StartCoroutine(show_text(txt, time));
        }
    }

    // display the text directly
    public void Direct_text(string txt)
    {
        info.text = txt;
    }

    IEnumerator show_text(string txt, float time)
    {
        info.text = "";
        foreach (char c in txt)
        {
            info.text += c;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(time);
        info.text = "";
        isShow = false;
    }
}
