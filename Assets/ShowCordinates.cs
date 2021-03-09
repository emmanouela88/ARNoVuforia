using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Android;
using ARLocation;

public class ShowCordinates : MonoBehaviour
{
    private double myLatValue;
    private double myLngValue;
    private double myAltValue;
    public GameObject myPrefab;
    private void Awake()
    {
        var loc = new Location()
        {
            Latitude = myLatValue,
            Longitude = myLngValue,
            Altitude = myAltValue,
            AltitudeMode = AltitudeMode.GroundRelative

        };

        var opts = new PlaceAtLocation.PlaceAtOptions()
        {
            HideObjectUntilItIsPlaced = true,
            MaxNumberOfLocationUpdates = 2,
            MovementSmoothing = 0.1f,
            UseMovingAverage = false
        };
        PlaceAtLocation.AddPlaceAtComponent(myPrefab, loc, opts);
    }

    void Start()
    {
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }
#elif UNITY_IOS
                  PlayerSettings.iOS.locationUsageDescription = "Details to use location";
#endif
        StartCoroutine(StartLocationService());
    }

    private IEnumerator StartLocationService()
    {
        if (!Input.location.isEnabledByUser)
        {
            yield break;
        }
        Input.location.Start();
        while (Input.location.status == LocationServiceStatus.Initializing)
        {
            yield return new WaitForSeconds(1);
        }
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }

        Debug.Log("Latitude : " + Input.location.lastData.latitude);
        Debug.Log("Longitude : " + Input.location.lastData.longitude);
        Debug.Log("Altitude : " + Input.location.lastData.altitude);
    }
    void Update()
    {
      
    }
}
