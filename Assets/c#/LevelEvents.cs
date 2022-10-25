using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEvents : MonoBehaviour
{
    [SerializeField] float testtime;
    [SerializeField] Vector2 testpos;
    [SerializeField] float delaytest;
    [SerializeField] float time = 0;
    //[SerializeField] float start_time = 0; //used to start where I want it to start

    GameObject ballexpo;
    GameObject line;
    GameObject conelaser;
    GameObject ballscaled;
    GameObject camera_level;
    GameObject big_ass_lines;
    GameObject attack_1;
    GameObject attack_2;

    bool call_once = true;
    bool can_stop = false;
    bool can_start = false;
    float music_start_time;
    Quaternion rot;
    public SmallerBallSpawn ballspawner;
    AudioSource AudioSource;
    bool has_started = false;
    
    private void Awake()
    {
        Time.timeScale = 0;
        ballexpo = GameObject.Find("ball_expo");
        line = GameObject.Find("line_attack");
        conelaser = GameObject.Find("cone_laser");
        ballscaled = GameObject.Find("scaled_ball_pop");
        camera_level = GameObject.Find("Main Camera");
        big_ass_lines = GameObject.Find("big_lined_attack");
        AudioSource = gameObject.GetComponent<AudioSource>();
        music_start_time = 118f; // + start_time;
        AudioSource.time = music_start_time;
        StartCoroutine(list_of_moves());
    }

   

    private void Update()
    {
        if(Input.anyKey == true && call_once)
        {
            can_start = true;
            call_once = false;
            GameObject.Find("any_key_to_start_text").SetActive(false);
        }
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

    //start of big lines methods
    void big_attack_instantiate(float x = 0, float y = 0,float x1 = 0,float y1 = 0, float angle = 0)
    {
        rot.eulerAngles = new Vector3(0, 0, angle);
        attack_1 = GameObject.Instantiate(big_ass_lines, new Vector2(x, y), rot);
        attack_2 = GameObject.Instantiate(big_ass_lines, new Vector2(x1, y1), rot);
    }
    void big_attack_add_velocity()
    {
        lines_large_script.speed_of_lines = 18;
    }
    
    IEnumerator big_attack_destroy()
    {
        while(can_stop == false)
        {
            foreach (SpriteRenderer r in attack_1.GetComponentsInChildren<SpriteRenderer>())
            {
                r.material.color -= new Color32(0, 0, 0, 10);                  
            }
            foreach (SpriteRenderer r in attack_2.GetComponentsInChildren<SpriteRenderer>())
            {
                r.material.color -= new Color32(0, 0, 0, 10);
                if (r.material.color.a <= 0)
                    can_stop = true;
            }
            yield return new WaitForFixedUpdate();
        }
        Destroy(attack_1, 0);
        Destroy(attack_2, 0);
        yield return null;
    }
     //end of methods  
       
    IEnumerator list_of_moves()
    {
        yield return new WaitUntil(() => can_start == true);
        Time.timeScale = 1;
        yield return new WaitForSeconds(2);
        has_started = true;
        AudioSource.Play();
        yield return new WaitUntil(() => time >= 2.7f);
     
       for(float x = 0;x < 7.2f;x += 0.9f)
        {
            line_spawn(-11 + x, -8);
            line_spawn(11 + x * -1, -8);
            yield return new WaitForSeconds(0.07f);
        }
        

        yield return new WaitUntil(() => time >= 2.85f);
        spawn_pop_ball(new Vector2(0, -6),0.05f);

        yield return new WaitUntil(() => time >= 4.90f);
        ball_scaled(-3,3.2f);

        yield return new WaitUntil(() => time >= 6.38f); 
        spawn_pop_ball(new Vector2(-7, -6),0.35f);
        spawn_pop_ball(new Vector2(7, -6),0.35f);

        yield return new WaitUntil(() => time >= 6.51f);
        ball_scaled(5.4f, -2.7f);

        yield return new WaitUntil(() => time >= 8.1f);
        ball_scaled(-8.8f, -3.5f);

        yield return new WaitUntil(() => time >= 9.4f);
        line_spawn(-12f,3.5f,270);       
        line_spawn(-12,-3.5f,270,0.5f);
        cone_laser(12,0,90,0.58f);

        yield return new WaitUntil(() => time >= 9.74f);
        ball_scaled(-0.96f, -2.66f);

        yield return new WaitUntil(() => time >= 11.6f);
        ball_scaled(4.52f, 1.29f);


        yield return new WaitUntil(() => time >= 13f);
        cone_laser(13f, 3, 90);
        cone_laser(-13f, -3, 270);
        big_attack_instantiate(-8, 0, 8);

        yield return new WaitUntil(() => time >= 15.7f);
        camera_movement(0, 1);
        big_attack_add_velocity();

        yield return new WaitUntil(() => time >= 19.2f);
        camera_movement(0, 3);
        big_attack_add_velocity();

        yield return new WaitUntil(() => time >= 22.5f);
        camera_movement(0, 5.1f);
        big_attack_add_velocity();

        yield return new WaitUntil(() => time >= 25.95f);
        camera_movement(0, 7);
        big_attack_add_velocity();

        yield return new WaitUntil(() => time >= 29.65f);
        big_attack_add_velocity();

        yield return new WaitUntil(() => time >= 31.1f);
        big_attack_add_velocity();
        StartCoroutine(big_attack_destroy());
       







        yield return null;
    }

}
