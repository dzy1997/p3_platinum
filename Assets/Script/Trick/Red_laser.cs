using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_laser : shoot_abstract
{
    // denote the time delay before it starts working
    public float delay_offset;
    // denote the cool down time
    public float cool_down_time;
    // denote the fire time
    public float fire_time;
    // denote the length of laser
    public float laser_length;
    // denote the bullet type
    public GameObject Laser_type;

    // denote the laser it generates
    private GameObject laser;
    // the state of laser deck
    private bool isFire;
    // denote whether it is active
    private bool isActive;

    public void Set_active_state(bool active)
    {
        isActive = active;
    }

    // reset
    public override void reset_state()
    {
        if (laser)
            Destroy(laser);
        isFire = true;
        isActive = true;
        StartCoroutine(shoot_offset());
    }

    // Start is called before the first frame update
    void Start()
    {
        isFire = true;
        isActive = true;
        StartCoroutine(shoot_offset());
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
            if (laser)
                Destroy(laser);
            return;
        }
        if (!isFire)
        {
            isFire = true;
            StartCoroutine(Shoot_laser());
        }
    }

    // fire routine
    IEnumerator Shoot_laser()
    {
        ExplosionParticleGenerator ep = GetComponent<ExplosionParticleGenerator>();
        if (ep)
            ep.Launch();
        yield return new WaitForSeconds(1f);

        laser = Instantiate(Laser_type, transform.position + shoot_direction * 0.25f, Quaternion.identity, transform);
        laser.GetComponent<Laser_strong>().Set_property(shoot_direction, fire_time, laser_length);
        yield return new WaitForSeconds(cool_down_time - 1f);
        
        isFire = false;
    }

    // make a time offset before working
    IEnumerator shoot_offset()
    {
        yield return new WaitForSeconds(delay_offset);
        isFire = false;
    }
}
