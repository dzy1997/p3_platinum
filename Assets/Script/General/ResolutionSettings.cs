using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreen = true;
        Screen.SetResolution(1600, 900, FullScreenMode.FullScreenWindow);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
