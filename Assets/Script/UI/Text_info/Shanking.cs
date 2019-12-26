using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shanking : MonoBehaviour
{
    private RectTransform rt;
    private bool isShake;
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        isShake = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShake)
        {
            isShake = true;
            StartCoroutine(shaking());
        }
    }

    IEnumerator shaking()
    {
        yield return new WaitForSeconds(0.3f);
        rt.localScale = new Vector3(0.9f, 0.9f, 1f);
        yield return new WaitForSeconds(0.3f);
        rt.localScale = new Vector3(1f, 1f, 1f);
        isShake = false;
    }
}
