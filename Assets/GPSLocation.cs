using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSLocation : MonoBehaviour
{
    public Text GPSStatus;
    public Text latitudePos;
    public Text longitudePos;
    public Text altitudeValue;
    public Text accuracyVal;
    public Text timeStampMine;

    public static GPSLocation instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(GPSLoc());
    }

    // Update is called once per frame
    IEnumerator GPSLoc()
    {
        if (!Input.location.isEnabledByUser) yield break;

        Input.location.Start();

        int maxWait = 20;
        while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait < 1)
        {
            GPSStatus.text = "Time out";
            yield break;
        }

        if(Input.location.status == LocationServiceStatus.Failed)
        {
            GPSStatus.text = "Unable for device location";
            yield break;
        }
        else
        {
            GPSStatus.text = "Access Granted";
            InvokeRepeating("UpdateGPSData",0.5f,1f);
        }
    }

    private void UpdateGPSData()
    {
        if(Input.location.status == LocationServiceStatus.Running)
        {
            GPSStatus.text = "Access Granted";
            latitudePos.text = Input.location.lastData.latitude.ToString();
            longitudePos.text = Input.location.lastData.longitude.ToString();
            altitudeValue.text = Input.location.lastData.altitude.ToString();
            accuracyVal.text = Input.location.lastData.horizontalAccuracy.ToString();
            timeStampMine.text = Input.location.lastData.timestamp.ToString();
        }
        else
        {
            GPSStatus.text = "No puedo";
        }
    }
}
