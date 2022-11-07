using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timer_follow_player : MonoBehaviour
{
    Transform pos;
    float division;
    float amount_to_go;
    public static float endofloop = 0;

    private void Awake()
    {
        Destroy(GameObject.Find("triangle_to_advance"), 0);
        pos = GameObject.Find("Player").transform;
        amount_to_go = endofloop - tutorial_music_player.musictime;
        division = amount_to_go;
    }

    private void Update()
    {
            transform.GetChild(0).GetComponentInChildren<Image>().fillAmount = amount_to_go / division;
            amount_to_go -= Time.deltaTime;
        if(amount_to_go < 0)
        {
            Destroy(gameObject, 0);
        }
        gameObject.transform.position = GameObject.Find("Player").transform.position;

    }

    private void OnDestroy()
    {
        GameObject.Find("Player").transform.position = new Vector2(-6,0);
        tutorial_music_player.canenablecollision = true;
        playerhealth.player_health = 3;
        playerhealth.Player_Damaged();
        
    }
}
