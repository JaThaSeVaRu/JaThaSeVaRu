using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GPSTesting : MonoBehaviour
{
    public TMP_Text OldGPS, NewGPS, Speed, Timestamp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    float oldLatitude, oldLongitude;
    double speedLatitude, speedLongitude;
    double oldTimestamp;
    void Update()
    {
        if (UnityEngine.Input.location.status == LocationServiceStatus.Running)
        {
            Debug.Log(Input.location.lastData.timestamp);

            if (Input.location.lastData.latitude != oldLatitude || Input.location.lastData.longitude != oldLongitude)
            {
                if (Input.location.lastData.timestamp - oldTimestamp > 10)
                {
                    Speed.text = "Speed: 0";
                }
                else
                {
                    speedLatitude = (Input.location.lastData.latitude - oldLatitude) / (Input.location.lastData.timestamp - oldTimestamp);
                    speedLongitude = (Input.location.lastData.longitude - oldLongitude) / (Input.location.lastData.timestamp - oldTimestamp);
                    Speed.text = "Speed: " + speedLatitude + ", " + speedLongitude;
                }
                OldGPS.text = "OldGPS: " + oldLatitude + ", " + oldLongitude;
                oldLongitude = Input.location.lastData.longitude;
                oldLatitude = Input.location.lastData.latitude;
                NewGPS.text = "NewGPS: " + oldLatitude + ", " + oldLongitude;

                oldTimestamp = Input.location.lastData.timestamp;
                Timestamp.text = "Time: " + oldTimestamp;
            }
        }
    }
}
