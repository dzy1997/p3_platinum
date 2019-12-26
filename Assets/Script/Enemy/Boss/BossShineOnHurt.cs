using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShineOnHurt : MonoBehaviour
{

	private SpriteRenderer body_sr;

    private bool isShine;
	private bool isRed;
	private Color red;
	private Color nocolor;
    private void Start()
    {
		body_sr = transform.Find("View").Find("body").GetComponent<SpriteRenderer>();
        isShine = false;
		isRed = false;
		red = new Color(255f,0f,0f,255f);
		nocolor = new Color(255f,255f,255f,255f);
    }

    // when hurt, shine
    public void Sprite_shine()
    {
        if (!isShine)
        {
            isShine = true;
			isRed = false;
            StartCoroutine(shining());
        }
    }

    // reset the state
    public void Reset()
    {
        isShine = false;
		isRed = false;
        body_sr.color = nocolor;
    }

    IEnumerator shining()
    {
        int t = 5;
        while (t > 0)
        {
            t--;
            if(!isRed){
				isRed = true;
				body_sr.color = red;
			}
			else{
				isRed = false;
				body_sr.color = nocolor;
			}
            yield return new WaitForSeconds(0.1f);
        }
        isRed = false;
		body_sr.color = nocolor;
        isShine = false;
    }
}
