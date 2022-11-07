using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tutorial_music_player : MonoBehaviour
{
    public AudioSource music;
    public static float musictime;
    public static bool shouldloop = true;
    [SerializeField]float level_time = 0;

    //prefabs
    public GameObject ballExpo;
    public GameObject triangle;
    GameObject lineattack;
    public static bool canenablecollision = false;
    private void Awake()
    {
        Time.timeScale = 1;
        timer_follow_player.endofloop = 40;
        canenablecollision = false;
    }
    private void Start()
    {
        static_variable.checkpointtoload = 0;
        lineattack = GameObject.Find("line_attack");
        music = GetComponent<AudioSource>();
        music.time = 15;
        music.volume = Main_Menu.volumemaster;
        if (static_variable.checkpointtoload <= 0)
        {
            StartCoroutine(level_start());
        }
        StartCoroutine(music_loop());
    }

    private void Update()
    {
        level_time = music.time;
        musictime = music.time;
    }

    void line_spawn(float x = 0, float y = 0, float delay = 0)
    {
        LineScript.delay_p_line = delay;
        GameObject lineph = GameObject.Instantiate(lineattack, new Vector2(x, y), Quaternion.identity);
        lineph.transform.GetChild(0).gameObject.SetActive(true);
    }
    IEnumerator music_loop()
    {
        bool trainglehasspawn = false;
        timer_follow_player.endofloop = 40;
        if (static_variable.checkpointtoload <= 0)
        {
            while (shouldloop)//loop1
            {
                yield return new WaitUntil(() => music.time >= 40);
                if (GameObject.FindGameObjectsWithTag("triangle").Length == 0)
                {
                    if (trainglehasspawn == false)
                    {
                        Instantiate(triangle, new Vector2(4.5f, 0), Quaternion.identity);
                        trainglehasspawn = true;
                        GameObject.Find("triangle_to_advance").GetComponent<TextMeshPro>().color += new Color(0,0,0,0.35f);
                    }
                }
                if (shouldloop)
                {
                    music.time -= 9.51f;
                    StopCoroutine(loop1());
                    StartCoroutine(loop1());
                }
            }
            GameObject.Find("remember_to_dash").GetComponent<TextMeshPro>().color += new Color(0, 0, 0, 0.35f);
            shouldloop = true;
            trainglehasspawn = false;
            music.time += 9.51f;
        }
        else
        {
            music.time = 49.51f;
        }
        if(static_variable.checkpointtoload <= 1)
        { 
        static_variable.checkpointtoload = 1;
        timer_follow_player.endofloop = 59.02f;
        StartCoroutine(loop2());
        while (shouldloop)
        {
            yield return new WaitUntil(() => music.time >= 59.02f);
            if (GameObject.FindGameObjectsWithTag("triangle").Length == 0)
            {
                if (trainglehasspawn == false)
                {
                    Instantiate(triangle, new Vector2(4.5f, 0), Quaternion.identity);
                    trainglehasspawn = true;
                }
            }
            if (shouldloop)
            {
                music.time -= 9.51f;
                StopCoroutine(loop2());
                StartCoroutine(loop2());
            }
              
        }
       // canenablecollision = true;
        shouldloop = true;
        trainglehasspawn = false;
        }
        else
        {
            music.time = 61f;
        }
        static_variable.checkpointtoload = 2;
        yield return new WaitUntil(() => music.time > 77.02f);
        GameObject.Find("enemyball").GetComponent<Animation>().Play();

        yield return new WaitUntil(() => music.time > 106);
        music.volume = Main_Menu.volumemaster / 3;
        GameObject.Find("UiCamera").transform.GetChild(2).gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    IEnumerator level_start()
    {
        yield return new WaitUntil(() => music.time > 22);
        GameObject.Find("gametitle").GetComponent<Animation>().Play();
        Destroy(GameObject.Find("gametitle"), 6);

        yield return new WaitUntil(() => music.time > 24.6f);
        Instantiate(ballExpo, new Vector2(6, -6), Quaternion.identity);

        yield return new WaitUntil(() => music.time > 27);
        Instantiate(ballExpo, new Vector2(6, -6), Quaternion.identity);

        yield return new WaitUntil(() => music.time > 29.3);
        Instantiate(ballExpo, new Vector2(6, -6), Quaternion.identity);

        yield return new WaitUntil(() => music.time > 31.5f);
        Instantiate(ballExpo, new Vector2(6, -6), Quaternion.identity);

        yield return new WaitUntil(() => music.time > 34);
        Instantiate(ballExpo, new Vector2(6, -6), Quaternion.identity);

        yield return new WaitUntil(() => music.time > 36.5f);
        Instantiate(ballExpo, new Vector2(6, -6), Quaternion.identity);

        yield return new WaitUntil(() => music.time > 38.7f);
        Instantiate(ballExpo, new Vector2(6, -6), Quaternion.identity);
    }
    IEnumerator loop1()
    {
        yield return new WaitUntil(() => music.time > 31.5f);
        Instantiate(ballExpo, new Vector2(6, -6), Quaternion.identity);

        yield return new WaitUntil(() => music.time > 34);
        Instantiate(ballExpo, new Vector2(6, -6),Quaternion.identity);

        yield return new WaitUntil(() => music.time > 36.5f);
        Instantiate(ballExpo, new Vector2(6, -6), Quaternion.identity);

        yield return new WaitUntil(() => music.time > 38.7f);
        Instantiate(ballExpo, new Vector2(6, -6), Quaternion.identity);
    }

    IEnumerator loop2()
    {
        yield return new WaitUntil(() => music.time > 50.52f);
        Instantiate(ballExpo, new Vector2(6, -6), Quaternion.identity);

        yield return new WaitUntil(() => music.time > 52f);
        line_spawn(-1.5f,-6);
        
        yield return new WaitUntil(() => music.time > 53.02f);
        Instantiate(ballExpo, new Vector2(6, -6), Quaternion.identity);
       
        yield return new WaitUntil(() => music.time > 54.1f);
        line_spawn(1.5f, -6);

        yield return new WaitUntil(() => music.time > 55.52f);
        Instantiate(ballExpo, new Vector2(6, -6), Quaternion.identity);

        yield return new WaitUntil(() => music.time > 56.8f);
        line_spawn(0, -6);

        GameObject.Find("remember_to_dash").GetComponent<TextMeshPro>().color = new Color(0, 0, 0, 0);


        yield return new WaitUntil(() => music.time > 57.72f);
        Instantiate(ballExpo, new Vector2(6, -6), Quaternion.identity);

        yield return new WaitUntil(() => music.time > 58f);
        line_spawn(-3, -6);

        yield return new WaitUntil(() => music.time > 58.6f);
        line_spawn(3, -6);

        yield return new WaitUntil(() => music.time > 59f);
        Instantiate(ballExpo, new Vector2(6, -6), Quaternion.identity);
    }
}
