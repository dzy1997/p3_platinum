using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shine_on_hurt : MonoBehaviour
{
    public SpriteRenderer sr;

    private bool isShine;

    private void Start()
    {
        isShine = false;
    }

    // when hurt, shine
    public void Sprite_shine()
    {
        if (!isShine)
        {
            isShine = true;
            StartCoroutine(shining());
        }
    }

    // reset the state
    public void Reset()
    {
        isShine = false;
        sr.enabled = true;
    }

    IEnumerator shining()
    {
        int t = 5;
        while (t > 0)
        {
            t--;
            sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(0.1f);
        }
        sr.enabled = true;
        isShine = false;
    }
}
