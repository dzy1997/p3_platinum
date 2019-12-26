using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set_boss_phase : MonoBehaviour
{
    // denote the camera checkpoint it watches if exist
    public Camera_checkpoint C_c;
    // denote the minor camera checkpoint it watches if exist
    public Camera_minor_check C_m_c;

    // denote the wait time before set active
    public float offset_time;
    // denote the real boss it controls
    public RealBoss Rb;

    // denote whether have worked
    private bool reached;


    private void Start()
    {
        reached = false;
    }

    // Update is called once per frame
    void Update()
    {
        // exist C_c
        if (C_c && !reached)
        {
            if (C_c.isReached())
            {
                reached = true;
                StartCoroutine(kick_boss());
            }
        }
        // exist C_m_c
        if (C_m_c && !reached)
        {
            if (C_m_c.isReached())
            {
                reached = true;
                StartCoroutine(kick_boss());
            }
        }
    }

    // set active
    IEnumerator kick_boss()
    {
        yield return new WaitForSeconds(offset_time);
        Rb.StartPhase();
    }
}
