using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInputHandler : MonoBehaviour
{
    public MenuController menuController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer>0) timer -= Time.deltaTime;
    }

    float timer = 0f;
    float wait_time = 0.2f;
    void OnScrollUp(){
        if (!menuController.startPrompt.activeSelf && timer<=0){
            timer = wait_time;
            menuController.switchSelect(-1);
        }
    }
    
    void OnScrollDown(){
        if (!menuController.startPrompt.activeSelf && timer<=0){
            timer = wait_time;
            menuController.switchSelect(1);
        }
    }

    void OnButtonPress(){
        if (menuController.startPrompt.activeSelf){
            menuController.ShowMenu();
        }else{
            menuController.EnterLevel();
        }
        // if (selectedIdx!=-1){
        //     buttons[selectedIdx].OnPointerExit(null);
        //     buttons[selectedIdx].onClick.Invoke();
        // }
    }
}
