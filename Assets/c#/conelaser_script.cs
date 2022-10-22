using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conelaser_script : MonoBehaviour
{
    Transform mainCone;
    public static float public_delay_cone;
    GameObject[] amountofcopies;
   

    private void Awake()
    {
        amountofcopies = GameObject.FindGameObjectsWithTag("coneobj");
        if (amountofcopies.Length != 1)
        {
            mainCone = gameObject.transform;
            StartCoroutine(cone_functions(public_delay_cone));
        }
    }
    
    IEnumerator cone_functions(float delay = 0)
    {
        yield return new WaitForSecondsRealtime(2.5f + delay);
        mainCone.position = transform.parent.GetChild(1).position;

        for(int x = 0; x < 10;x++)
        {
            mainCone.localScale += new Vector3(0.1170758f,0,0);
            yield return new WaitForFixedUpdate();
        }
        Destroy(transform.parent.GetChild(1).gameObject, 0);
        yield return new WaitForSecondsRealtime(0.4f);

        for (int x = 0; x < 60; x++)
        {
            mainCone.localScale += new Vector3(-0.019512633333333f, 0, 0);
            yield return new WaitForFixedUpdate();
        }
        Destroy(transform.parent.gameObject, 0);

        yield return null;
    }
}
