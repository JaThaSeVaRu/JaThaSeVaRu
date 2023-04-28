using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityFinder : MonoBehaviour
{
    float oldLatitude, oldLongitude;
    double speedLatitude, speedLongitude;
    double oldTimestamp;
    public double Speed;


    float R = 6.371f;
    float calculateGPSDistance(float lat1, float lon1, float lat2, float lon2)
    {
        float phi1 = lat1 * Mathf.PI / 180f;
        float phi2 = lat2 * Mathf.PI / 180f;
        float deltaPhi = (lat2 - lat1) * Mathf.PI / 180f;
        float delta = (lon2 - lon1) * Mathf.PI / 180f;

        float a = Mathf.Sin(deltaPhi / 2f) * Mathf.Sin(deltaPhi / 2f) + Mathf.Cos(phi1) * Mathf.Cos(phi2) * Mathf.Sin(delta / 2f) * Mathf.Sin(delta / 2f);

        float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));

        float d = R * c; // in metres

        return d*1000;
    }

    // public void buttonGPS()
    // {
    //     updateGPSnum();
    // }

    // public void buttonStation()
    // {
    //     StationFinder.instance.FindNearestStation();
    // }
    public bool updateGPSnum()
    {
        if (UnityEngine.Input.location.status == LocationServiceStatus.Running)
        {
            //Debug.Log(Input.location.lastData.timestamp);
            if (Input.location.lastData.latitude != oldLatitude || Input.location.lastData.longitude != oldLongitude)
            {
                if (Input.location.lastData.timestamp == oldTimestamp)
                {
                    //Speed.text = "Speed: 0";
                }
                else
                {
                    Vector2 oCoord = new Vector2(oldLatitude, oldLongitude);
                    Vector2 nCoord = new Vector2(Input.location.lastData.latitude, Input.location.lastData.longitude);
                    float d = calculateGPSDistance(oCoord.x, oCoord.y, nCoord.x, nCoord.y);
                    //Debug.Log(d);
                    //speedLatitude = (Input.location.lastData.latitude - oldLatitude) / (Input.location.lastData.timestamp - oldTimestamp);
                    //speedLongitude = (Input.location.lastData.longitude - oldLongitude) / (Input.location.lastData.timestamp - oldTimestamp);
                    //speedLatitude *= 110.574;
                    //speedLongitude *= 111.320 * System.Math.Cos(speedLatitude);

                    Speed = d / (Input.location.lastData.timestamp - oldTimestamp) * 3600f;
                    GameManager.instance.player.Velocity = (float)Speed;
                }
                oldLongitude = Input.location.lastData.longitude;
                oldLatitude = Input.location.lastData.latitude;
                oldTimestamp = Input.location.lastData.timestamp;
            }
            return true;
        }
        return false;
    }
}
