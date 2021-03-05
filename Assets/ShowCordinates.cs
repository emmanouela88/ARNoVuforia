using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class ShowCordinates : MonoBehaviour
{
    public Text longtitudeText;
    public Text latitudeText;
    public Text accuracyText;
    /*IEnumerator Start()
    {
        Input.location.Start();
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
        }

        // Stop service if there is no need to query location updates continuously
        Input.location.Stop();
    }*/
    private void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        longtitudeText.text = "Longtitude: " + Input.location.lastData.longitude;
        latitudeText.text = "Latitude: " + Input.location.lastData.latitude;
        accuracyText.text = "Accuracy: " + Input.location.lastData.horizontalAccuracy;
    }
}
