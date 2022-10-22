using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scale_ball_script : MonoBehaviour
{
    GameObject dot;
    GameObject ball;
    // Start is called before the first frame update
    private void OnEnable()
    {
        dot = GameObject.Find("dot");
        
        StartCoroutine(basemove());
    }

  
    IEnumerator basemove()
    {
        yield return new WaitForSecondsRealtime(1.2f);
        transform.position = transform.parent.position;
        for(int x = 0;x < 20;x++)
        {
            transform.localScale += new Vector3(0.05f, 0.05f, 0);
            yield return new WaitForFixedUpdate();
        }
        StartCoroutine(shoot_ball());
      
        Destroy(transform.parent.gameObject, 0.1f);
        yield return null;
    }
    IEnumerator shoot_ball()
    {
        float angleMath = (float)16;
        float angle_offset = 360 / angleMath;
        float angle = Random.value * 20;
        Vector3 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;

        for (int x = 0; x < 16; x++)
        {
            angle += angle_offset;
            ball = GameObject.Instantiate(dot, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody2D>().AddForce(dir * 250);
            dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
            Destroy(ball, 4);

        }


        yield return null;
    }
}
