using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public playerhealth playerhealthsc;
    private Rigidbody2D body;
    private float speed = 5;
    private bool can_dash = true;

    
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        playerhealthsc = GameObject.Find("Player").GetComponent<playerhealth>();
    }



    private IEnumerator dash()
    {
        playerhealthsc.iframes = true;
        speed = 15;
        yield return new WaitForSeconds(.20f);
        playerhealthsc.iframes = false;
        speed = 5;
        yield return null;
    }




    private void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);
        body.velocity.Normalize();

        if(Input.GetButtonDown("Jump"))
        {
            if (can_dash == true)
            {
                StopCoroutine(dash());
                StartCoroutine(dash());
                StartCoroutine(dash_timer());
            }
        }
    }



    private IEnumerator dash_timer()
    {
        can_dash = false;
        
        yield return new WaitForSeconds(.3f);
        can_dash = true;
        yield return null;
    }


}
