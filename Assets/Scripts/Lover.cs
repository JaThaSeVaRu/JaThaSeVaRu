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

        //move left along with train
        transform.Translate(Vector3.left * GameManager.Instance.player.Velocity * Time.deltaTime);

        //disappear when out of bounds
        if (transform.position.x <= -15)
        {
            Destroy(gameObject);
        }

    }
}
