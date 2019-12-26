using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPromptShine : MonoBehaviour
{
    public Text text;
    public Image icon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float timer = 0f;
    public float cycle = 4f;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float a = (Mathf.Cos(timer/cycle)+1)/2f;
        Color color = new Color(1f,1f,1f,a);
        text.color = color;
        icon.color = color;
    }


}
