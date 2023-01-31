using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectibleScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    void  OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            Destroy(gameObject);
        }

    }
}