using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.InTransit)
            transform.Translate(Vector3.left * speed / 10f * GameManager.Instance.player.Velocity * Time.deltaTime);
    }
}
