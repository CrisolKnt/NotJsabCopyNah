using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lines_large_script : MonoBehaviour
{
    GameObject line1;
    GameObject warning;
    public static float speed_of_lines = 0f;
    private void OnEnable()
    {
        transform.parent.parent = GameObject.Find("Main Camera").transform;
        warning = transform.parent.GetChild(0).gameObject;
        line1 = gameObject;
    }

   private void Update()
    {
        transform.position += new Vector3(0, speed_of_lines * Time.deltaTime);
         if(line1.transform.localPosition.y < 7.5f)
        {
            line1.transform.position += new Vector3(0, 5);
        }

         if (speed_of_lines < -1.5f)
        {
            speed_of_lines += 1.5f * Time.deltaTime; 
        }
        if (speed_of_lines  < -1.5f && warning != null)
        {
            Destroy(warning, 0);
        }
    }
}
