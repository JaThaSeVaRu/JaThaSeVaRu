using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class train : MonoBehaviour
{
    //set speed of train
    //static variable for character, lover and obstacles to use
    //public static float staticSpeed;
    //starting position to be teleported back to
    //public Vector3 startPosition;
    //X-Axis value to initialise the teleport back to startPosititon
    //public float setBack = -27.84f;

    public static List<GameObject> TrainParts = new List<GameObject>();

    private AudioManager audioManager;

    Sound s;

    void Start()
    {
        foreach(Transform ts in GetComponentsInChildren<Transform>())
        {
            if (ts.gameObject.layer == LayerMask.NameToLayer("Train"))
            {
                TrainParts.Add(ts.gameObject);
            }
        }
        //get current position and set as start position
        //startPosition = transform.position;
        audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play("Train");
        GameManager.Instance.player.OnVelocityChange += changeTrainPlaySpeed;
        s = Array.Find(audioManager.sounds, sound => sound.name == "Train");
    }

    public void changeTrainPlaySpeed(PlayerData pd)
    {
        s.source.pitch = 1 * pd.Velocity / 10f;
    }

    void Update()
    {
        //set static speed equal to speed for the character-Script, lover-Script and the Obstacle-Script to use
        //staticSpeed = speed;
        
        //move left

        foreach(GameObject t in TrainParts)
        { 
            if (GameManager.Instance.InTransit)
                t.transform.Translate(Vector3.left * GameManager.Instance.player.Velocity  * Time.deltaTime);
        }
        

        //if setback-Position is reached set back to starting position to simulate an infinite loop
        /*if (transform.position.x <= setBack)
        {
            transform.position = startPosition;
        }*/
    }
}
