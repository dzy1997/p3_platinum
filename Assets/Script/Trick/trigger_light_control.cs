using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_light_control : MonoBehaviour
{
    public Light controlled_light;

    // denote the intensity of light
    public float intense_1;
    public float intense_2;
    // denote the progress of change
    private bool inProgress;
    // denote the time needed to change
    private int t;

    // Start is called before the first frame update
    void Start()
    {
        controlled_light.intensity = intense_1;
        inProgress = false;
        t = 30;
    }

    private void Update()
    {
        if (!inProgress)
        {
            inProgress = true;
            StartCoroutine(shine());
        }
    }

    IEnumerator shine()
    {
        float delta = (intense_2 - intense_1) / t;
        int i = t;
        while (i > 0)
        {
            controlled_light.intensity += delta;
            yield return 0;
            i--;
        }
        controlled_light.intensity = intense_2;
        i = t;
        // pause for 1 sencond
        yield return new WaitForSeconds(1f);
        while(i > 0)
        {
            controlled_light.intensity += -delta;
            yield return 0;
            i--;
        }
        controlled_light.intensity = intense_1;
        yield return new WaitForSeconds(1f);
        inProgress = false;
    }
}
