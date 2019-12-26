using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_deck_controller : MonoBehaviour
{
    // denote the type of objects it will attack
    public string attack_tag;

    // denote the targets for the object
    private List<GameObject> attack_list = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if the victim enters the range it controls
        // the trick will operate
        if (other.gameObject.CompareTag(attack_tag))
        {
            attack_list.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // it the victim leaves the range it controls
        // the trick won't consider it as a target
        if (other.gameObject.CompareTag(attack_tag))
        {
            if (attack_list.Exists(x => x == other.gameObject))
                attack_list.Remove(other.gameObject);
        }
    }

    // check if necessary to keep targets in the list
    public void Check_victim()
    {
        for (int i = 0; i < attack_list.Count; i++)
        {
            if (attack_list[i] == null)
                attack_list.RemoveAt(i);
        }
    }

    // randomly pick a victim from the list
    public GameObject Random_choose_victim()
    {
        if (attack_list.Count == 0)
            return null;
        int i = Random.Range(0, attack_list.Count);
        return attack_list[i];
    }
}
