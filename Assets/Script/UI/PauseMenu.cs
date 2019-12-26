using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public Button[] buttons;
    public GameObject panel;
    public int selectedIdx = -1;
    float wait_time = 0.2f;
    public PauseMenu player1, player2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    float timer = 0f;
    void Update()
    {
        if (timer>=0f){
            timer -= Time.unscaledDeltaTime;
        }
    }

    void switchSelect(int input){
        if (selectedIdx == -1){
            selectedIdx = 0;
        }else{
            buttons[selectedIdx].OnPointerExit(null);
            selectedIdx = (selectedIdx+buttons.Length+input)%buttons.Length;
        }
        buttons[selectedIdx].OnPointerEnter(null);
    }

    public void OnScrollUp(){
        if (!panel.activeSelf) return;
        if (timer<=0){
            Debug.Log("up");
            timer = wait_time;
            switchSelect(-1);
        }
    }
    
    public void OnScrollDown(){
        if (!panel.activeSelf) return;
        if (timer<=0){
            Debug.Log("down");
            timer = wait_time;
            switchSelect(1);
        }
    }
    public void OnButtonPress(){
        if (!panel.activeSelf) return;
        if (selectedIdx!=-1){
            buttons[selectedIdx].OnPointerExit(null);
            buttons[selectedIdx].onClick.Invoke();
        }
    }
    public void OnTogglePauseMenu(){
        if (!panel.activeSelf){
            panel.SetActive(true);
            Time.timeScale = 0.001f;
            GetComponent<PlayerInput>().SwitchCurrentActionMap("PauseMenu");
        }else{
            panel.SetActive(false);
            Time.timeScale = 1f;
            if (player1 && player2){
                player1.GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
                player2.GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
            }
            else{
                GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
            }
        }
    }
    public void MainMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void RestartLevel(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
