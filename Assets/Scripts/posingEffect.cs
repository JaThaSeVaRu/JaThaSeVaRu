using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posingEffect : MonoBehaviour
{
    public GameObject character;


    void Start()
    {
        transform.position = new Vector3(transform.position.x, 10f, transform.position.z);
    }

    void Update()
    {

        if (character.GetComponent<characterControl>().state != runstate.SLIDING)
        {
            transform.position = new Vector3(transform.position.x, 10f, transform.position.z);
        }

        if (character.GetComponent<characterControl>().state == runstate.SLIDING)
        {
            transform.position = character.GetComponent<characterControl>().transform.position;
        }
    }
}
