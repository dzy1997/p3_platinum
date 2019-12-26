using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toto_level_end : MonoBehaviour
{
    // denote the toto end that is recorded
    public tuto_end te1;
    public tuto_end te2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (te1.reached && te2.reached)
            GameController.GetInstance().EndLevel();
    }
}
