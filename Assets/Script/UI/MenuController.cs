using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject buttonGroup, startPrompt;
    public Button[] buttons;
    public int selectedIdx = -1;
    public bool buttonVisible = false;
    public Color normalColor,highlightColor, selectColor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private float timer;
    float wait_time = 0.2f;
    void Update()
    {
        if (timer>0){
            timer -= Time.deltaTime;
        }
    }

    public void switchSelect(int input){
        Text text;
        RectTransform rt;
        if (selectedIdx == -1){
            selectedIdx = 0;
        }else{
            // buttons[selectedIdx].OnPointerExit(null);
            text = buttons[selectedIdx].transform.GetChild(0).GetComponent<Text>();
            text.color = normalColor;
            rt = text.GetComponent<RectTransform>();
            rt.offsetMin = new Vector2(0, rt.offsetMin.y);
            selectedIdx = (selectedIdx+buttons.Length+input)%buttons.Length;
        }
        // buttons[selectedIdx].OnPointerEnter(null);
        text = buttons[selectedIdx].transform.GetChild(0).GetComponent<Text>();
        text.color = highlightColor;
        rt = text.GetComponent<RectTransform>();
        rt.offsetMin = new Vector2(30, rt.offsetMin.y);
    }

    public void EnterLevel(){
        if (selectedIdx != -1){
            buttons[selectedIdx].transform.GetChild(0).GetComponent<Text>().color = selectColor;
            buttons[selectedIdx].onClick.Invoke();
        }
    }

    public void ShowMenu(){
        startPrompt.SetActive(false);
        buttonGroup.SetActive(true);
    }
}
