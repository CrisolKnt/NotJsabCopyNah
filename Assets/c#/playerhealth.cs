using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerhealth : MonoBehaviour
{
    [SerializeField] private int player_health = 5;
    [SerializeField] public bool iframes = false;
    [SerializeField] private bool dmgIframes = false;
    private bool isColliding = false;
    public SpriteRenderer sprite;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }



    IEnumerator lower_health()
    {
        if (dmgIframes == false && iframes == false)
        { 
            player_health -= 1;
            Debug.Log("health down");
            dmgIframes = true;
            sprite.color = new Color(1, 1, 1, 0.5f);
            yield return new WaitForSeconds(3);
            dmgIframes = false;
            sprite.color = new Color(1, 1, 1, 1f);
        }
        yield return null;
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        isColliding = true;
    }




    private void Update()
    {
       
        if(isColliding == true)
        {
            StartCoroutine("lower_health");
        }
        isColliding = false;
    }

}
