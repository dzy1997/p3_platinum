using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class degree_shoot : shoot_abstract
{
    // denote the sway frequence of machine gun
    public float frequence;
    // denote the degree range it will shoot around the original shoot direction
    public float degree;
    // denote the fire time
    public float fire_time;
    // denote the cool down time -- must longer than fire time
    public float cool_down_time;
    // denote the delay time it have
    public float delay_time;
    // denote the original shoot direction
    private Vector3 original_dir;

    // denote the shooting animator it controls if have
    public Animator anim;
    // denote the speed of bullet speed
    public float bullet_speed;
    // denote the shooting speed
    public float shoot_time;
    // denote the type of bullet it is shooting
    public GameObject bullet;
    // denote the controller
    public Gun_deck_controller gdc;

    // denote the status of gameobject
    private bool isShooting;
    // denote the aiming function
    private Adjust_Aim A_aim;
    // denote whether in cool down state
    private bool isCooling;
    // denote whether is in sway state
    private bool isSway;
    // denote the sway speed
    private float sway_speed;

    // Start is called before the first frame update
    void Awake()
    {
        isShooting = false;
        isCooling = false;
        isSway = false;
        sway_speed = 2 * degree / frequence;
        original_dir = shoot_direction;
        A_aim = GetComponent<Adjust_Aim>();
        StartCoroutine(delay_shoot());
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCooling)
        {
            isCooling = true;
            StartCoroutine(Cool_down());
        }
    }

    // Reset the state of machine gun
    override public void reset_state()
    {
		
        isShooting = false;
        isCooling = false;
        isSway = false;
		shoot_direction = original_dir;
        
    }

    // adjust the shooting direction by outside
    private void Adjust_shoot_direction(Vector3 dir)
    {
        shoot_direction = dir.normalized;
    }

    IEnumerator Cool_down()
    {
        StartCoroutine(Fire());
        yield return new WaitForSeconds(cool_down_time);
        isCooling = false;
    }

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
            if (!isShooting)
            {
                isShooting = true;
                StartCoroutine(shooting_bullet());
            }
            yield return 0;
        }
    }

    IEnumerator Sway()
    {
        bool axis = true;
        float t = frequence;
        while (t > 0)
        {
            t = t - Time.deltaTime;
            if (Vector3.SignedAngle(original_dir, shoot_direction, Vector3.forward) > degree / 2f)
                axis = false;
            if (Vector3.SignedAngle(original_dir, shoot_direction, Vector3.back) > degree / 2f)
                axis = true;
            if (axis)
                shoot_direction = Quaternion.AngleAxis(sway_speed * Time.deltaTime, Vector3.forward) * shoot_direction;
            else
                shoot_direction = Quaternion.AngleAxis(sway_speed * Time.deltaTime, Vector3.back) * shoot_direction;
            yield return 0;
        }
        shoot_direction = original_dir;
        isSway = false;
    }

    IEnumerator shooting_bullet()
    {
        GameObject target = gdc.Random_choose_victim();
        if (A_aim != null)
            Adjust_shoot_direction(A_aim.cur_dir);
        if (target != null)
        {
            StartCoroutine(anim_shoot());

            GameObject shot = Instantiate(bullet, transform.position + 0.2f * shoot_direction.normalized, Quaternion.identity);
            shot.GetComponent<abstract_bullet>().set_shotdir(shoot_direction.normalized);
            shot.GetComponent<abstract_bullet>().set_target(target);
            shot.GetComponent<abstract_bullet>().set_speed(bullet_speed);
            shot.GetComponent<abstract_bullet>().Set_ready();
        }
        // cool for some time
        yield return new WaitForSeconds(shoot_time);
        isShooting = false;
    }

    IEnumerator anim_shoot()
    {
        if (anim)
            anim.SetBool("isShoot", true);
        yield return 10;
        if (anim)
            anim.SetBool("isShoot", false);
    }

    IEnumerator delay_shoot()
    {
        isCooling = true;
        yield return new WaitForSeconds(delay_time);
        isCooling = false;
    }
}
