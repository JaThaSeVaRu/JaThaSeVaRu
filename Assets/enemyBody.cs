using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBody : MonoBehaviour
{
    public GameObject parent;

    void Start()
    {
        
    }


    void Update()
    {

        if (parent.GetComponent<enemy>().yeeted == true)
        {
            transform.Rotate(parent.GetComponent<enemy>().rotation * parent.GetComponent<enemy>().speed * Time.deltaTime);
        }
    }
}
