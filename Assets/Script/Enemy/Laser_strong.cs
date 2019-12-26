using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_strong : MonoBehaviour
{
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
        AudioSource.PlayClipAtPoint(laser, transform.position, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            // start to instantiate
            if (dir == Vector3.down)
            {
                start_ob = Instantiate(start, transform.position, Quaternion.Euler(0, 0, -90), transform);
                middle_ob = Instantiate(middle, transform.position, Quaternion.Euler(0, 0, -90), transform);
                end_ob = Instantiate(end, transform.position, Quaternion.Euler(0, 0, -90), transform);
            }
            else if (dir == Vector3.up)
            {
                start_ob = Instantiate(start, transform.position, Quaternion.Euler(0, 0, 90), transform);
                middle_ob = Instantiate(middle, transform.position, Quaternion.Euler(0, 0, 90), transform);
                end_ob = Instantiate(end, transform.position, Quaternion.Euler(0, 0, 90), transform);
            }
            else if (dir == Vector3.left)
            {
                start_ob = Instantiate(start, transform.position, Quaternion.Euler(0, 0, 180), transform);
                middle_ob = Instantiate(middle, transform.position, Quaternion.Euler(0, 0, 180), transform);
                end_ob = Instantiate(end, transform.position, Quaternion.Euler(0, 0, 180), transform);
            }
            else
            {
                start_ob = Instantiate(start, transform.position, Quaternion.identity, transform);
                middle_ob = Instantiate(middle, transform.position, Quaternion.identity, transform);
                end_ob = Instantiate(end, transform.position, Quaternion.identity, transform);
            }
            StartCoroutine(Timer_destroy());
            isReady = false;
        }

        if (start_ob != null)
        {
            middle_ob.transform.localPosition = start.transform.localPosition + 0.5f * max_length * dir;
            middle_ob.transform.localScale = new Vector3(4 * max_length, 1f);
            end_ob.transform.localPosition = start.transform.localPosition + max_length * dir;
        }
    }

    // destroy itself after certain time
    IEnumerator Timer_destroy()
    {
        yield return new WaitForSeconds(time_last);
        Destroy(gameObject);
    }
}
