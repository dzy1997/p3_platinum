using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_onboss : MonoBehaviour
{
    // denote the boss health it refers to
    public int threshold;

    public Health health;

    private void Update()
    {
        if (health.health <= threshold)
        {
            ExplosionParticleGenerator ep = GetComponent<ExplosionParticleGenerator>();
            if (ep)
                ep.Launch();
            Destroy(gameObject);
        }
    }
}
