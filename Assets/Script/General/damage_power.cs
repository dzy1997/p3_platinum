using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class damage_power : MonoBehaviour
{
    // denote the damage the object can cause to other objects
    public int damage_amount;
    // denote the list of tags the object can cause damage to
    public List<string> damage_target;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // get the tag of the other object
        string tag_other = other.gameObject.tag;
        // only if the other is in the list of damage
        // then cause damage to the other
        if (damage_target.Exists(x => x == tag_other))
        {
            // TODO: implement the details for damaging for each child class!!!
            Handle_damage_behave(other.gameObject);
        }         
    }

    // The abstract function that handle damaging
    abstract public void Handle_damage_behave(GameObject victim);
}
