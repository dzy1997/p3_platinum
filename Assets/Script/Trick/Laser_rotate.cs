using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_rotate : shoot_abstract
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
    // denote the cool down time
    public float cool_down_time;
    // denote the fire time
    public float fire_time;
    // denote the length of laser
    public float laser_length;
    private float pre_length;
    // denote the reference offset vector
    private Vector3 ref_dir;

    // denote whether it is active
    private bool isActive;

    // denote the time used to rotate for a round
    public float time_rotate;
    // denote counter or non-counter rotation
    public bool counter;

    // denote the degree each deltatime rotate;
    private float r_speed;
    // denote the rotate lock
    private bool r_lock;

    public void Set_active_state(bool active)
    {
        isActive = active;
    }

    // reset
    public override void reset_state()
    {
        r_lock = true;
        isActive = true;
        pre_length = 0f;
        shoot_direction = ref_dir;
        StartCoroutine(shoot_offset());
    }

    // Start is called before the first frame update
    void Start()
    {
        r_speed = 360f / time_rotate;

        r_lock = true;
        isActive = true;
        pre_length = 0f;
        ref_dir = shoot_direction.normalized;

        StartCoroutine(shoot_offset());

        // start to instantiate
        float degree = Vector3.SignedAngle(Vector3.right, shoot_direction.normalized, Vector3.forward);
        start_ob = Instantiate(start, transform.position + 0.8f * shoot_direction.normalized, Quaternion.Euler(0, 0, degree), transform);
        middle_ob = Instantiate(middle, transform.position + 0.8f * shoot_direction.normalized, Quaternion.Euler(0, 0, degree), transform);
        end_ob = Instantiate(end, transform.position + 0.8f * shoot_direction.normalized, Quaternion.Euler(0, 0, degree), transform);
    }

    // Update is called once per frame
    void Update()
    {
        // get the new Vector it will rotate to
        Vector3 dir = Vector3.zero;
        if (counter)
            dir = Quaternion.AngleAxis(r_speed * Time.deltaTime, Vector3.forward) * shoot_direction;
        else
            dir = Quaternion.AngleAxis(r_speed * Time.deltaTime, Vector3.back) * shoot_direction;

        shoot_direction = dir;

        float length = Detect_length();
        if (System.Math.Abs(pre_length - length) > 0.001f)
        {
            middle_ob.transform.localPosition = 0.5f * length * ref_dir.normalized;
            middle_ob.transform.localScale = new Vector3(2 * length, 1f);
            end_ob.transform.localPosition = length * ref_dir.normalized;
        }
        pre_length = length;

    }

    /*
    IEnumerator rotate_shoot()
    {
        // get the new Vector it will rotate to
        Vector3 dir = Vector3.zero;
        if (counter)
            dir = Quaternion.AngleAxis(r_speed * Time.deltaTime, Vector3.forward) * shoot_direction;
        else
            dir = Quaternion.AngleAxis(r_speed * Time.deltaTime, Vector3.back) * shoot_direction;

        shoot_direction = dir;

        yield return 0;
        r_lock = false;
    }
    */

    // make a time offset before working
    IEnumerator shoot_offset()
    {
        yield return new WaitForSeconds(delay_offset);
        r_lock = false;
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
}
