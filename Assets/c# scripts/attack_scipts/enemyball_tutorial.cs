using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyball_tutorial : MonoBehaviour
{
    GameObject dot;
    [SerializeField] float timer;
    Quaternion sideways;
    Transform playerpos;

    private void Awake()
    {
        playerpos = GameObject.Find("Player").transform;
        sideways.eulerAngles = new Vector3(0, 0, 90);
        dot = GameObject.Find("dot");
        StartCoroutine(poptimer());
    }
    private void Update()
    {
        timer = gameObject.GetComponent<Animation>()["enemyball"].time;
    }
    void popball()
    {
        GameObject ball;
        float angleMath = 16;
        float angle_offset = 360 / angleMath;
        float angle = Random.value * 20;
        Vector3 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;

        for (int x = 0; x < 16; x++)
        {
            angle += angle_offset;
            ball = GameObject.Instantiate(dot, transform.position, Quaternion.identity);
            ball.GetComponent<Rigidbody2D>().AddForce(dir * 250);
            dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
            Destroy(ball, 4);
        }
    }

    IEnumerator poptimer()
    {
        yield return new WaitUntil(() => timer >= 3.8f);
        Instantiate(GameObject.Find("line_attack"), new Vector2(0, -6), Quaternion.identity).transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitUntil(() => timer >= 5.1f);
        popball();

        yield return new WaitUntil(() => timer >= 5.05f);
        Instantiate(GameObject.Find("line_attack"), new Vector2(10, 3),sideways).transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitUntil(() => timer >= 6.3f);
        Instantiate(GameObject.Find("line_attack"), new Vector2(-5, -6), Quaternion.identity).transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitUntil(() => timer >= 7.6f);
        popball();

        yield return new WaitUntil(() => timer >= 7.45f);
        Instantiate(GameObject.Find("line_attack"), new Vector2(playerpos.position.x, -6), Quaternion.identity).transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitUntil(() => timer >= 8.7f);
        Instantiate(GameObject.Find("line_attack"), new Vector2(10, -2.5f), sideways).transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitUntil(() => timer >= 10f);
        popball();

        yield return new WaitUntil(() => timer >= 12.30f);
        Instantiate(GameObject.Find("line_attack"), new Vector2(10, playerpos.position.y), sideways).transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitUntil(() => timer >= 13.55f);
        Instantiate(GameObject.Find("line_attack"), new Vector2(4, -6), Quaternion.identity).transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitUntil(() => timer >= 14.85f);
        popball();

        yield return new WaitUntil(() => timer >= 14.80f);
        Instantiate(GameObject.Find("line_attack"), new Vector2(10, 1), sideways).transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitUntil(() => timer >= 16.05f);
        Instantiate(GameObject.Find("line_attack"), new Vector2(playerpos.position.x, -6), Quaternion.identity).transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitUntil(() => timer >= 17.30f);
        Instantiate(GameObject.Find("line_attack"), new Vector2(0, -6), Quaternion.identity).transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitUntil(() => timer >= 17.35f);
        popball();

        yield return new WaitUntil(() => timer >= 18.55f);
        Instantiate(GameObject.Find("line_attack"), new Vector2(10, -6), sideways).transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitUntil(() => timer >= 19.65f);
        popball();

        yield return new WaitUntil(() => timer >= 19.65f);
        Instantiate(GameObject.Find("line_attack"), new Vector2(-3, -6), Quaternion.identity).transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitUntil(() => timer >= 20.70f);
        Instantiate(GameObject.Find("line_attack"), new Vector2(10, 1), sideways).transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitUntil(() => timer >= 21.95f);
        popball();

        yield return new WaitUntil(() => timer >= 21.95f);
        Instantiate(GameObject.Find("line_attack"), new Vector2(10,6), sideways).transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitUntil(() => timer >= 23.2f);
        Instantiate(GameObject.Find("line_attack"), new Vector2(playerpos.position.x, -6), Quaternion.identity).transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitUntil(() => timer >= 24.15f);
        popball();

    }
}
