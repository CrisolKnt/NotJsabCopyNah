using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class reset_animation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>().keepAnimatorControllerStateOnDisable = false;
    }

    private void OnEnable()
    {
        gameObject.GetComponent<Animator>().Play("Normal",-1,normalizedTime: 0);
    }

}
