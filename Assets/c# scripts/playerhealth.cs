using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerhealth : MonoBehaviour
{
    //player stats
    [SerializeField] public static int player_health = 3;
    [SerializeField] public bool iframes = false;
    [SerializeField] private bool dmgIframes = false;
    private bool isColliding = false;
    bool isontriangle = false;
    
   //references 
    AudioSource audio;
    Image sprite;
    SpriteRenderer sprite2;
    public GameObject timer;

    //events
    public delegate void Player_health_events();
    public static Player_health_events Player_Damaged;
   
   
    private void Awake()
    {
        player_health = 3;
        audio = GetComponent<AudioSource>();
        sprite = transform.GetChild(0).GetComponentInChildren<Image>();
        sprite2 = GetComponent<SpriteRenderer>();
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
        static_variable.times_ded += 1;
        buttons.respawn();
    }
    IEnumerator lower_health()
    {
        if (dmgIframes == false && iframes == false)
        { 
            player_health -= 1;
            Debug.Log("health down");
            Player_Damaged();
            audio.time = 0.28f;
            audio.Play();
            dmgIframes = true;
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.4f);
            sprite2.color = new Color(sprite2.color.r, sprite2.color.g, sprite2.color.b, 0.4f);
            yield return new WaitForSeconds(3);
            dmgIframes = false;
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
            sprite2.color = new Color(sprite2.color.r, sprite2.color.g, sprite2.color.b, 1f);
        }
        yield return null;
    }


   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("triangle"))
        {
            isontriangle = true;
            Debug.Log("collison false");
            tutorial_music_player.shouldloop = false;
            Destroy(GameObject.FindGameObjectWithTag("triangle"), 0);
            Instantiate(timer,transform.position,Quaternion.identity);
            StartCoroutine(enable_collision());
        }
    }

    IEnumerator enable_collision()
    {
        yield return new WaitUntil(() => tutorial_music_player.canenablecollision == true);
        isontriangle = false;
        Debug.Log("collison true");
        tutorial_music_player.canenablecollision = false;

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("triangle"))
        {
            if (!isontriangle)
            {
                isColliding = true;
            }
        }
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
        static_variable.time_played += Time.deltaTime;
    }
   
}
