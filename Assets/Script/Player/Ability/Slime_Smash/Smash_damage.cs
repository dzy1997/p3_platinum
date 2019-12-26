using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smash_damage : damage_power
{
    // damage behaviour for a smash
    public override void Handle_damage_behave(GameObject victim)
    {
		Debug.Log(victim + "Get smashed!!!");
        // TODO: implement the causing damage to victim
        Health victim_health = victim.GetComponent<Health>();
        if (victim_health != null)
        {
            victim_health.ChangeHealthByAmount(-damage_amount);
        }

    }
}
