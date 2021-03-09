using ARLocation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeValues : MonoBehaviour
{
    public InputField orientUpdateInfo;
    ARLocationOrientation instance;
    void Start()
    {
        orientUpdateInfo.onValueChanged.AddListener((b) => UpdateInfoAndReset());
        instance = GetComponent<ARLocationOrientation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateInfoAndReset()
    {
        if (int.TryParse(orientUpdateInfo.text, out int myValue))
        {
            instance.MaxNumberOfUpdates = (uint)myValue;
            ARLocationManager.Instance.ResetARSession((() =>
            {
                Debug.Log("AR+GPS and AR Session were restarted!");
            }));
        }
           

    }
}
