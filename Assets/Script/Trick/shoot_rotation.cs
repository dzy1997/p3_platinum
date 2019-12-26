using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot_rotation : MonoBehaviour
{
    // denote the shoot direction it controls
    public shoot_abstract shoot_feature;

    // Update is called once per frame
    void Update()
    {
        adjust_view_dir();
    }

    private void adjust_view_dir()
    {
        float degree = Vector3.SignedAngle(Vector3.down, shoot_feature.shoot_direction, Vector3.forward);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, degree));
    }
}
