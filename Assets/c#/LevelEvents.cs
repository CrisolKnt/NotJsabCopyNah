using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEvents : MonoBehaviour
{
    [SerializeField] float testtime;
    [SerializeField] Vector2 testpos;
    [SerializeField] float delaytest;
    [SerializeField] float time;
    
    GameObject ballexpo;
    GameObject line;
    GameObject conelaser;
    GameObject ballscaled;
    GameObject camera_level;

    float music_start_time;
    Quaternion rot;
    public SmallerBallSpawn ballspawner;
    AudioSource AudioSource;
    bool has_started = false;
    
    private void Awake()
    {
        ballexpo = GameObject.Find("ball_expo");
        line = GameObject.Find("line_attack");
        conelaser = GameObject.Find("cone_laser");
        ballscaled = GameObject.Find("scaled_ball_pop");
        camera_level = GameObject.Find("Main Camera");
        AudioSource = gameObject.GetComponent<AudioSource>();
        music_start_time = 118f;
        AudioSource.time = music_start_time;
        StartCoroutine(list_of_moves());
    }

   

    private void FixedUpdate()
    {
        if (has_started == true)
        { time += Time.deltaTime; }
    }
    void cone_laser(float x = 0, float y = 0, float angle = 0,float delay = 0)
    {
        conelaser_script.public_delay_cone = delay;
        rot.eulerAngles = new Vector3(0,0,angle);
        GameObject.Instantiate(conelaser,new Vector2(x,y),rot);
    }

    void spawn_pop_ball(Vector2 pos,float delay = 0)
    {
        ballspawner.publicdelay = delay;
        GameObject.Instantiate(ballexpo, pos, Quaternion.identity);
    }

   void line_spawn(float x = 0, float y = 0, float angle = 0, float delay = 0)
    {
        rot.eulerAngles = new Vector3(0, 0, angle);
        
        LineScript.delay_p_line = delay;
        GameObject lineph = GameObject.Instantiate(line, new Vector2(x,y), rot);
        lineph.transform.GetChild(0).gameObject.SetActive(true);
    }

    void ball_scaled(float x = 0,float y = 0)
    {
       GameObject ballscaledobj = GameObject.Instantiate(ballscaled, new Vector2(x,y), Quaternion.identity);
        ballscaledobj.transform.GetChild(0).gameObject.SetActive(true);
    }
    
    void camera_movement(float x = 0,float y = 0)
    {
        camera_level.GetComponent<Rigidbody2D>().velocity = new Vector2(x,y);
    }

       
    IEnumerator list_of_moves()
    {
        yield return new WaitForSecondsRealtime(2);
        has_started = true;
        AudioSource.Play();
        yield return new WaitUntil(() => time >= 2.7f);
       
       for(float x = 0;x < 7.2f;x += 0.9f)
        {
            line_spawn(-11 + x, -8);
            line_spawn(11 + x * -1, -8);
            yield return new WaitForSecondsRealtime(0.07f);
        }
        

        yield return new WaitUntil(() => time >= 2.85f);
        spawn_pop_ball(new Vector2(0, -6),0.05f);

        yield return new WaitUntil(() => time >= 4.98f);
        ball_scaled(-3,3.2f);

        yield return new WaitUntil(() => time >= 6.38f); 
        spawn_pop_ball(new Vector2(-7, -6),0.35f);
        spawn_pop_ball(new Vector2(7, -6),0.35f);

        yield return new WaitUntil(() => time >= 6.51f);
        ball_scaled(5.4f, -2.7f);

        yield return new WaitUntil(() => time >= 8.04f);
        ball_scaled(-8.8f, -3.5f);

        //yield return new WaitUntil(() => time >= 9.65f);
        //spawn_pop_ball(new Vector2(0, -6),0.4f);
        // spawn_pop_ball(new Vector2(-7, -6),0.4f);
        // spawn_pop_ball(new Vector2(7, -6),0.4f);

        yield return new WaitUntil(() => time >= 9.4f);
        line_spawn(-12f,3.5f,270);

       // yield return new WaitUntil(() => time >= 9.9f);
        line_spawn(-12,-3.5f,270,0.5f);

       // yield return new WaitUntil(() => time >= 9.98f);
        cone_laser(12,0,90,0.58f);



        yield return new WaitUntil(() => time >= 13f);
        cone_laser(13f, 3, 90);
        cone_laser(-13f, -3, 270);








        yield return null;
    }

}
