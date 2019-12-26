using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_ondeath : MonoBehaviour
{
    public Health health;

    private void Update()
    {
        if (health.isDead)
        {
            ExplosionParticleGenerator ep = GetComponent<ExplosionParticleGenerator>();
            if (ep)
                ep.Launch();
            Destroy(gameObject);
        }
    }
}
