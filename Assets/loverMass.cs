using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loverMass : MonoBehaviour
{
    public float baseSpeed;
    public float speed;
    public float switchSpeed;


    public GameObject character;
    public GameObject manager;


    void Start()
    {
        
    }

    void Update()
    {

        switchSpeed = character.GetComponent<characterControl>().speed / 4f;

        speed = baseSpeed * ( 1 + manager.GetComponent<gameManager>().heartsStolen);

        if (transform.position.x <= -3.5f)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (transform.position.y <= -0.6f)
        {
            if (character.GetComponent<characterControl>().transform.position.y <= transform.position.y)
            {
                transform.Translate(Vector3.down * switchSpeed * Time.deltaTime);
            }
            if (character.GetComponent<characterControl>().transform.position.y >= transform.position.y)
            {
                transform.Translate(Vector3.up * switchSpeed * Time.deltaTime);
            }
        }
        if (transform.position.y > -0.6f)
        {
            transform.position = new Vector3(transform.position.x, -0.6f, transform.position.z);
        }
    }
}
