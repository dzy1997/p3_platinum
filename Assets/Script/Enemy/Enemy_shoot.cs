using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_shoot : shoot_abstract
{
    // denote the shooting animator it controls if have
    public Animator anim;
    // denote whether to follow the target
    public bool isTrack;
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

    // reset
    public override void reset_state()
    {
        isShooting = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        isShooting = false;
        A_aim = GetComponent<Adjust_Aim>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShooting)
        {
            isShooting = true;
            StartCoroutine(shooting_bullet());
        }
    }

    // adjust the shooting direction by outside
    private void Adjust_shoot_direction(Vector3 dir)
    {
        shoot_direction = dir.normalized;
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
            if (isTrack)
                shoot_direction = (target.transform.position - transform.position).normalized;
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
}
