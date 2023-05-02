using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainReset : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach(GameObject go in train.TrainParts)
        {
            if(go.name != gameObject.name)
            {
                this.transform.localPosition = go.transform.localPosition + new Vector3(Mathf.Abs(transform.localPosition.x - go.transform.localPosition.x), 0 ,0);
                break;
            }
        }
        Debug.Log("Train Reset");
    }
}
