using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reborn : MonoBehaviour
{
    // denote the player it inspects
    public GameObject player;

    private Health h;
    // Start is called before the first frame update
    void Start()
    {
        h = player.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (h.isDead)
            GameController.GetInstance().RespawnPlayers();
    }
}
