using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lover : MonoBehaviour
{
    public float speed;


    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    //IMPORTANT: check heart-Script for extension of this script
    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

    void Update()
    {
        //get the speed of the train
        speed = train.speed;

        //move left along with train
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        //disappear when out of bounds
        if (transform.position.x <= -15)
        {
            Destroy(gameObject);
        }

    }
}
