using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastObjectFinder : MonoBehaviour
{
    private GameObject _lastObject;
    public GameObject lastObject
    {
        get { return _lastObject; }
        set {
            _lastObject = value;
            _lastObject.transform.position = new Vector3(_lastObject.transform.position.x, _lastObject.transform.position.y, gameObject.transform.localPosition.z);
        }
    }
}
