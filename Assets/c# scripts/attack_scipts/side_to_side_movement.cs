using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class side_to_side_movement : MonoBehaviour
{
    bool go_to_x_side = false;
    float angle;
    public static bool startangle;

    private void Awake()
    {
        go_to_x_side = startangle;
    }
    private void Update()
    {
        angle = transform.eulerAngles.z;
        if (angle >= 15 && angle <= 115)
        {
            go_to_x_side = true;
        }
        if(angle <= 345 && angle >= 300)
        {
            go_to_x_side = false;
        }


        if (go_to_x_side)
        {
            transform.eulerAngles += new Vector3(0,0,-9 * Time.deltaTime);
        } 
        else
        {
            transform.eulerAngles += new Vector3(0, 0,9 * Time.deltaTime);
        }
    }
}
