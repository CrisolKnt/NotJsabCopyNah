using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause_and_scene_change : MonoBehaviour
{
    [SerializeField] bool is_paused = false;
    bool can_unpause_music = false;
    AudioSource music;


    private void Awake()
    {
        music = transform.GetChild(1).GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (is_paused)
            {
                is_paused = false;
                Time.timeScale = 1;
                if (can_unpause_music)
                {
                    music.Play();
                }
                transform.Find("UiCamera").GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                if (music.isPlaying)
                {
                    can_unpause_music = true;
                }
                is_paused = true;
                Time.timeScale = 0;
                music.Pause();
                transform.Find("UiCamera").GetChild(1).gameObject.SetActive(true);

            }
        }
    }
}
