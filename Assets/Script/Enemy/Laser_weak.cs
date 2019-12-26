using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_weak : MonoBehaviour
{
    // denote whether it can be detroyed
    public bool retain;
    // Laser start part
    public GameObject start;
    // Laser middle part
    public GameObject middle;
    // Laser end part
    public GameObject end;
    // denote the sound effect of laser
    public AudioClip laser;

    // The private parts of a laser
    private GameObject start_ob;
    private GameObject middle_ob;
    private GameObject end_ob;

    // The direction of the laser
    private Vector3 dir;
    // Time it will last
    private float time_last;
    // The max length of laser
    private float max_length;
    private float pre_length;
    // denote whether the laser is ready to function
    private bool isReady;
    // Set the properties of laser
    public void Set_property(Vector3 direction, float last, float length)
    {
        dir = direction;
        time_last = last;
        max_length = length;
        isReady = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        start_ob = null;
        middle_ob = null;
        end_ob = null;
        pre_length = 0f;
        AudioSource.PlayClipAtPoint(laser, transform.position, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            // start to instantiate
            float degree = Vector3.SignedAngle(Vector3.right, dir.normalized, Vector3.forward);
            start_ob = Instantiate(start, transform.position, Quaternion.Euler(0, 0, degree), transform);
            middle_ob = Instantiate(middle, transform.position, Quaternion.Euler(0, 0, degree), transform);
            end_ob = Instantiate(end, transform.position, Quaternion.Euler(0, 0, degree), transform);

            if (!retain)
                StartCoroutine(Timer_destroy());
            isReady = false;
        }

        if (start_ob != null)
        {
            float length = Detect_length();
            if (System.Math.Abs(pre_length - length) > 0.001f)
            {
                middle_ob.transform.localPosition = start_ob.transform.localPosition + 0.5f * length * dir;
                middle_ob.transform.localScale = new Vector3(2 * length, 1f);
                end_ob.transform.localPosition = start_ob.transform.localPosition + length * dir;
            }
            pre_length = length;
        }
    }

    // return the target length of laser
    private float Detect_length()
    {
        int layerMask = 1 << 19;
        int layerMask2 = 1 << 20;
        int layerMask3 = 1 << 21;
        int waterMask = 1 << 4;
        layerMask = layerMask | layerMask2 | layerMask3 | waterMask;
        layerMask = ~layerMask;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, max_length, layerMask);
        // only hit on walls
        if (hit.collider != null)
        {
            return Vector2.Distance(transform.position, hit.point);
        }
        return max_length;
    }

    IEnumerator Timer_destroy()
    {
        yield return new WaitForSeconds(time_last);
        Destroy(gameObject);
    }
}
