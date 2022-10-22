using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    GameObject warning;
    public static float delay_p_line;

    private void Awake()
    {
        warning = transform.parent.GetChild(1).gameObject;
        StartCoroutine(warning_spawm(delay_p_line));
    }
    IEnumerator warning_spawm(float delay)
    {
        yield return new WaitForSecondsRealtime(2f + delay);
        Destroy(warning,1.5f);
        transform.position = transform.parent.GetChild(1).position;

        Destroy(warning, 0);
  
            for (int x = 0; x < 5;x++)
        {
            transform.localScale += new Vector3(-0.1f, 0, 0);
            yield return new WaitForSecondsRealtime(0.07f);
        }
        Destroy(transform.parent.gameObject, 0);

        yield return null;
    }


}
