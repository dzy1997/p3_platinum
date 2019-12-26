using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial_info : MonoBehaviour
{
    // whether to freeze input of players
    public bool freeze;
    // freeze time
    public float freeze_time;
    // the text it will control
    public Show_text info;
    // note the content number
    public int content_index;
    // the player object it controls
    public List<GameObject> players;
    // denote the button tuto for players
    public Sprite button;
    public Image img;
      
    private bool reached;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !reached)
        {
            reached = true;
            info.Direct_text(contents[content_index]);
            img.sprite = button;
            if (freeze)
                StartCoroutine(freeze_speed());
        }
    }

    private List<string> contents = new List<string>();

    private void Start()
    {
        string content = "You woke up! Time to escape!\n";
        contents.Add(content);
        content = "Watch out! They can hurt you.\n Open your shield!";
        contents.Add(content);
        content = "Release to refill power!";
        contents.Add(content);
        content = "Stop! Laser can kill you!\n Use your power!";
        contents.Add(content);
        content = "Use your power!";
        contents.Add(content);
        content = "Go to Xtraction Point!\n Find a way to freedom!!!";
        contents.Add(content);
    }

    IEnumerator freeze_speed()
    {
        float temp = 0;
        foreach (GameObject p in players)
        {
            temp = p.GetComponent<Movement>().speed;
            p.GetComponent<Movement>().speed = 0f;
        }
        yield return new WaitForSeconds(freeze_time);
        foreach (GameObject p in players)
        {
            p.GetComponent<Movement>().speed = temp;
        }
    }
}
