using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

   
    IEnumerator death()
    {
        Image image = GameObject.Find("screen_of_death").GetComponent<Image>();
        Color fade = image.color;
        while (Time.timeScale - Time.deltaTime > 0.1)
        {
            image.color = new Color(fade.r,fade.g,fade.b,0.3f);
            Time.timeScale -= Time.deltaTime;
            yield return new WaitForSeconds(0.5f);
        }
        buttons.respawn();
    }
    IEnumerator lower_health()
    {
        if (dmgIframes == false && iframes == false)
        { 
            player_health -= 1;
            Debug.Log("health down");
            dmgIframes = true;
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.5f);
            yield return new WaitForSeconds(3);
            dmgIframes = false;
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
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
        if (player_health <= 0)
        {
            StartCoroutine(death());
        }
    }

}
