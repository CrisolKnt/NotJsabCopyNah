using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_2bossplayer : MonoBehaviour
{
    [SerializeField] float timer;
    [SerializeField] float animtimer;
    [SerializeField] float diference;
    AudioSource music;
    Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        music = gameObject.GetComponent<AudioSource>();
        anim = GameObject.Find("bossanimation").GetComponent<Animation>();
        StartCoroutine(events());
    }
    
    // Update is called once per frame
    void Update()
    {
        timer = music.time;
        animtimer = anim["level2bossanim"].time;
        diference = timer - animtimer;
    }

    IEnumerator events()
    {
        yield return new WaitForSeconds(3);
        music.Play();
        GameObject.Find("bossanimation").GetComponent<Animation>().Play();
    }
}
