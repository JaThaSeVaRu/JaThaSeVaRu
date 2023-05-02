using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCollider : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {

        background.instance.createNewBackground(transform.parent.gameObject);
        Destroy(this.gameObject);    
    }
}
