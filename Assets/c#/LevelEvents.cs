using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEvents : MonoBehaviour
{
    [SerializeField] float testtime;
    [SerializeField] Vector2 testpos;
    [SerializeField] float delaytest;
    [SerializeField] float time;

    GameObject popball;
    GameObject ballexpo;
    GameObject line;
    GameObject conelaser;
    GameObject placeholder;

    Quaternion rot;
    public SmallerBallSpawn ballspawner;
    LineScript lineSpawner = new LineScript();
    AudioSource AudioSource;
    bool has_started = false;
    
    private void Awake()
    {
        ballexpo = GameObject.Find("ball_expo");
        line = GameObject.Find("line");
        conelaser = GameObject.Find("cone_laser");
        popball = gameObject;
        AudioSource = gameObject.GetComponent<AudioSource>();
        AudioSource.time = 118f;
        StartCoroutine(list_of_moves());
    }

   

    private void FixedUpdate()
    {
        if (has_started == true)
        { time += Time.deltaTime; }
    }
        void cone_laser(Vector2 pos,float angle = 0)
    {
        
        rot.eulerAngles = new Vector3(0,0,angle);
        GameObject.Instantiate(conelaser,pos,rot);
    }

    void spawn_pop_ball(Vector2 pos,float delay = 0)
    {
        ballspawner.publicdelay = delay;
        GameObject.Instantiate(ballexpo, pos, Quaternion.identity);
    }

   void line_spawn(Vector2 pos, float delay = 0)
    {
        lineSpawner.delay_p_line = delay;
        GameObject.Instantiate(line, pos, Quaternion.identity);
    }


    IEnumerator list_of_moves()
    {
        yield return new WaitForSecondsRealtime(2);
        has_started = true;
        AudioSource.Play();
      
        yield return new WaitUntil(() => time >= 2.7f);
       
       for(float x = 0;x < 7.2f;x += 0.9f)
        {
            line_spawn(new Vector2(-11 + x, 13));
            line_spawn(new Vector2(11 + x * -1, 13));
            yield return new WaitForSecondsRealtime(0.07f);
        }
        

        yield return new WaitUntil(() => time >= 2.85f);
        spawn_pop_ball(new Vector2(0, -6),0.05f);
        
        yield return new WaitUntil(() => time >= 6.38f); 
        spawn_pop_ball(new Vector2(-7, -6),0.35f);
        spawn_pop_ball(new Vector2(7, -6),0.35f);

        yield return new WaitUntil(() => time >= 9.65f);
        spawn_pop_ball(new Vector2(0, -6),0.4f);
        spawn_pop_ball(new Vector2(-7, -6),0.4f);
        spawn_pop_ball(new Vector2(7, -6),0.4f);

        yield return new WaitUntil(() => time >= testtime);
        cone_laser(new Vector2(13f, 3), 90);
        cone_laser(new Vector2(-13f, -3), 270);








        yield return null;
    }

}
