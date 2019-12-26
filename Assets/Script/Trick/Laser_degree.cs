using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_degree : shoot_abstract
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

    // denote the animator it controls
    public Animator anim;
    // denote the time delay before it starts working
    public float delay_offset;
    // denote the wait time at each stop
    public float wait_time;
    // denote the cool down time
    public float cool_down_time;
    // denote the fire time
    public float fire_time;
    // denote the length of laser
    public float laser_length;
    // denote the sway frequence of machine gun
    public float frequence;
    // denote the degree range it will shoot around the original shoot direction
    public float rotate_degree;
    // denote if it will attack with counter axis
    public bool counter;
    // denote whether it is active
    private bool isActive;

    private float pre_length;
    // denote the reference offset vector
    private Vector3 original_direction;
    // denote whether in cool down state
    private bool isCooling;
    // denote whether is in sway state
    private bool isSway;
    // denote the sway speed
    private float sway_speed;

    // reset the state
    public override void reset_state()
    {
        // set inactive before delay offset
        start_ob.SetActive(false);
        middle_ob.SetActive(false);
        end_ob.SetActive(false);
        // delay offset
        StartCoroutine(shoot_offset());
        shoot_direction = original_direction;
        isCooling = false;
        isSway = false;
        isActive = true;
    }

    void Awake()
    {
        sway_speed = 2 * rotate_degree / frequence;
        isActive = true;
        pre_length = 0f;
        original_direction = shoot_direction.normalized;

        // start to instantiate
        float degree = Vector3.SignedAngle(Vector3.right, shoot_direction, Vector3.forward);
        if (!start_ob)
            start_ob = Instantiate(start, transform.position + 0.8f * shoot_direction.normalized, Quaternion.Euler(0, 0, degree), transform);
        if (!middle_ob)
            middle_ob = Instantiate(middle, transform.position + 0.8f * shoot_direction.normalized, Quaternion.Euler(0, 0, degree), transform);
        if (!end_ob)
            end_ob = Instantiate(end, transform.position + 0.8f * shoot_direction.normalized, Quaternion.Euler(0, 0, degree), transform);
        // set inactive before delay offset
        start_ob.SetActive(false);
        middle_ob.SetActive(false);
        end_ob.SetActive(false);
        // delay offset
        StartCoroutine(shoot_offset());
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
            return;
        if (!isCooling && end_ob.activeSelf)
        {
            isCooling = true;
            StartCoroutine(Cool_down());
        }

        // first adjust the direction
        adjust_view_dir();
        
        // then adjust the length and position
        float length = Detect_length();
        if (end_ob.activeSelf)
        {
            if (System.Math.Abs(pre_length - length) > 0.001f)
            {
                middle_ob.transform.localPosition = 0.5f * length * original_direction.normalized;
                middle_ob.transform.localScale = new Vector3(2 * length, 1f);
                end_ob.transform.localPosition = length * original_direction.normalized;
            }
            pre_length = length;
        }

    }



    // make a time offset before working
    IEnumerator shoot_offset()
    {
        yield return new WaitForSeconds(delay_offset);
        start_ob.SetActive(true);
        middle_ob.SetActive(true);
        end_ob.SetActive(true);
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, shoot_direction.normalized, laser_length, layerMask);
        // only hit on walls
        if (hit.collider != null)
        {
            return Vector2.Distance(transform.position, hit.point);
        }
        return laser_length;
    }

    // cool down the fire
    IEnumerator Cool_down()
    {
        StartCoroutine(Fire());
        yield return new WaitForSeconds(cool_down_time);
        isCooling = false;
    }

    // Fire
    IEnumerator Fire()
    {
        float t = fire_time;
        while (t > 0)
        {
            if (!isSway)
            {
                isSway = true;
                StartCoroutine(Sway());
            }
            t = t - Time.deltaTime;
            yield return 0;
        }
    }

    // sway the gun deck
    IEnumerator Sway()
    {
        // first wait for some time
        float wait_t = wait_time;
        yield return new WaitForSeconds(wait_t);

        // Then start rotating
        bool axis = true;
        float t = frequence;
        while (t > 0)
        {
            t = t - Time.deltaTime;
            if (Vector3.SignedAngle(original_direction, shoot_direction, Vector3.forward) > rotate_degree / 2f)
                axis = false;
            if (Vector3.SignedAngle(original_direction, shoot_direction, Vector3.back) > rotate_degree / 2f)
                axis = true;
            if (axis)
                shoot_direction = Quaternion.AngleAxis(sway_speed * Time.deltaTime, Vector3.forward) * shoot_direction;
            else
                shoot_direction = Quaternion.AngleAxis(sway_speed * Time.deltaTime, Vector3.back) * shoot_direction;
            yield return 0;
        }
        shoot_direction = original_direction;
        isSway = false;
    }

    private void adjust_view_dir()
    {
        float degree = Vector3.SignedAngle(original_direction, shoot_direction, Vector3.forward);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, degree));
    }

    public void Set_active_state(bool active)
    {
        isActive = active;
    }
}
