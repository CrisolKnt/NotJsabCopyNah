using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoots_projectile_script : MonoBehaviour
{
    [SerializeField] float angle;
    GameObject[] amount_of_obj;
     
    Vector3 dir;
    private void Awake()
    {
        amount_of_obj = GameObject.FindGameObjectsWithTag("bullet");
        if (amount_of_obj.Length != 1)
        {
            angle = transform.rotation.eulerAngles.z;
            dir = Quaternion.AngleAxis(angle + 90, Vector3.forward) * Vector3.right;
            gameObject.GetComponent<Rigidbody2D>().AddForce(dir * 2000);
            Destroy(transform.gameObject, 1);
        }
    }

//warning just rotates left to right shooting 
   
}

