using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class visual_health : MonoBehaviour
{
    Image image;
    float max_health;
    private void Awake()
    {
        max_health = playerhealth.player_health;
        image = GetComponent<Image>();
        playerhealth.Player_Damaged += show_health;
    }
    private void OnDestroy()
    {
        playerhealth.Player_Damaged -= show_health;
    }
    void show_health()
    {
        image.fillAmount = (float)playerhealth.player_health / max_health;
    }

    private void Update()
    {
        transform.position = GameObject.Find("Player").transform.position;
    }
}
