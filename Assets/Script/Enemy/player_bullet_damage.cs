using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_bullet_damage : damage_power
{
    // damage behaviour for a bullet
    public override void Handle_damage_behave(GameObject victim)
    {
        // if collide with wall, disappear immediately
        if (victim.CompareTag("Wall"))
        {
            GetComponent<ExplosionParticleGenerator>().Launch();
            Destroy(gameObject);
            return;
        }
        // TODO: implement the causing damage to victim
        Health victim_health = victim.GetComponent<Health>();
        if (victim_health != null)
        {
            victim_health.ChangeHealthByAmount(-damage_amount);
        }


        // TODO: implement the self destroy with health controller
        // for now just destroy itself
        GetComponent<ExplosionParticleGenerator>().Launch();
        Destroy(gameObject);
    }
}
