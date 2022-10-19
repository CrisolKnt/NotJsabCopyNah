using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallerBallSpawn : MonoBehaviour
{
    GameObject ball;
    GameObject dot;
    GameObject warning;
    Transform spawnPos;
    public float publicdelay = 0;
    float delay;
    bool isOriginal = false;
    GameObject[] amountofcopies;
    private void Awake()
    {
        delay = publicdelay;
        amountofcopies = GameObject.FindGameObjectsWithTag("popball");
        spawnPos = GetComponent<Transform>();
        dot = GameObject.Find("dot");
     
        if(amountofcopies.Length == 1)
        {
            isOriginal = true; 
        }
       
        StartCoroutine(warning_spawm());

        //move ball up
        
    }

    
    IEnumerator warning_spawm()
    {

        warning = GameObject.Instantiate(GameObject.Find("warning"), spawnPos.position + new Vector3(0, 3), spawnPos.rotation);
        yield return new WaitForSecondsRealtime(1.5f);
        Destroy(warning, 1f);

        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 800);

        yield return new WaitForSecondsRealtime(0.32f);

        for(int x = 0; x < 3;x++)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 266.6666666f);
            yield return new WaitForSecondsRealtime(0.07f);
        }
        
        StartCoroutine(shoot_ball());
        yield return null;
    }




   IEnumerator shoot_ball()
    {
        //make big ball go up with warning, go white then explode into 16 smaller pieces on all ways. made to be reusable by instancing big ball.
        yield return new WaitForSeconds(delay);
        float angleMath = (float) 16;
        float angle_offset = 360 / angleMath;
        float angle = Random.value * 20;
        Vector3 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;

        for(int x = 0;x < 16;x++)
        {
            angle += angle_offset;
            ball = GameObject.Instantiate(dot, spawnPos.position, spawnPos.rotation);
            ball.GetComponent<Rigidbody2D>().AddForce(dir * 250);
            dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
            Destroy(ball, 4);

        }
        if(isOriginal != true)
        {
            Destroy(gameObject, 0);
        }


        yield return null;
    }
}
