using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    GameObject warning;
    Transform spawnPos;
    GameObject[] amountofcopies;
    bool isOriginal;
    public float delay_p_line = 0;

    private void Awake()
    {
        spawnPos = GetComponent<Transform>();
        StartCoroutine(warning_spawm(delay_p_line));

        amountofcopies = GameObject.FindGameObjectsWithTag("line");
        if (amountofcopies.Length == 1)
        {
            isOriginal = true;
        }
    }
    IEnumerator warning_spawm(float delay)
    {

        warning = GameObject.Instantiate(GameObject.Find("line_warning"),spawnPos.position + new Vector3(0,-13) , spawnPos.rotation);
        yield return new WaitForSecondsRealtime(2f);
        Destroy(warning, delay + 1.5f);
        
        spawnPos.position += new Vector3(0, -13);

        Destroy(warning, 0);
        if (isOriginal != true)
        { 
            for (int x = 0; x < 5;x++)
        {
            spawnPos.localScale += new Vector3(-0.1f, 0, 0);
            yield return new WaitForSecondsRealtime(0.07f);
        }
        if (isOriginal != true)
        
            Destroy(gameObject, 0);
        }

        yield return null;
    }


}
