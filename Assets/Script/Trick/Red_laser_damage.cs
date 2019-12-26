using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_laser_damage : damage_power
{
    public override void Handle_damage_behave(GameObject victim)
    {
        Health victim_health = victim.GetComponent<Health>();
        if (victim_health != null)
        {
            victim_health.ChangeHealthByAmount(-damage_amount);
        }
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
}
