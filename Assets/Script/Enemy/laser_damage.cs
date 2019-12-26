using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_damage : damage_power
{
    // denote the time to control damage
    private float cool_time = 0.5f;
    private bool damaged;

    public override void Handle_damage_behave(GameObject victim)
    {
        // TODO: implement the causing damage to victim
        Health victim_health = victim.GetComponent<Health>();
        if (victim_health != null)
        {
            if (!damaged)
            {
                damaged = true;
                victim_health.ChangeHealthByAmount(-damage_amount);
                StartCoroutine(cool_down());
            }
        }
    }

    IEnumerator cool_down()
    {
        yield return new WaitForSeconds(cool_time);
        damaged = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // get the tag of the other object
        string tag_other = other.gameObject.tag;
        // only if the other is in the list of damage
        // then cause damage to the other
        if (damage_target.Exists(x => x == tag_other))
        {
            Handle_damage_behave(other.gameObject);
        }
    }

    private void OnDisable()
    {
        damaged = false;
    }
}
