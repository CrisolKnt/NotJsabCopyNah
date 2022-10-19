using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnGameObjects : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject ballexpo;
    GameObject placeholder;
    private void Awake()
    {
        ballexpo = GameObject.Find("ball_expo");
    }

    public void spawn_pop_ball(Vector2 pos)
    {
       placeholder = GameObject.Instantiate(ballexpo, pos, Quaternion.identity);
        Destroy(placeholder,2.95f);
    }

}
