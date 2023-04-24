using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EditorPlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerData player;
    [SerializeField] StationData OriginStation;
    [SerializeField] StationData TargetStation;
    [SerializeField] WorldData world;
    bool playerTraveling;
    float speed;
    public float playerMockSpeed;

    private void Update() 
    {
        speed = ((player.Velocity * Time.deltaTime));
        if (Input.GetKeyDown("space"))
        {
            playerTraveling = true;
            player.Velocity = playerMockSpeed;
        }
        if (playerTraveling)
        {
            MakePlayerTravel();
            Debug.Log("Player traveling at: " + speed);
        }
    }
    void MakePlayerTravel()
    {
        player.Coordinates = Vector2.MoveTowards(player.Coordinates, TargetStation.Coordinates, speed);
        if (Vector2.Distance(player.Coordinates, TargetStation.Coordinates) <= 0.00001)
        {
            player.LastStation = TargetStation;
            playerTraveling = false;
            player.Velocity = 0;
            world.GetSystemTime();
            Debug.Log("Player reached target at: " + TargetStation.StationName);
        }
        
    }
    

}
