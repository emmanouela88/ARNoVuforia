using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script manipulates a 3D plane to project the camera as AR and as you rotate you can see a 3D obj.
public class ARCamera : MonoBehaviour
{
    public GameObject obj;

    void Start()
    {
        if (Application.isMobilePlatform)
        {
            GameObject cameraParent = new GameObject("camParent");
            cameraParent.transform.position = this.transform.position;
            this.transform.parent = cameraParent.transform;
            cameraParent.transform.Rotate(Vector3.right, 90);
        }

        Input.gyro.enabled = true;
        WebCamTexture webTexture = new WebCamTexture();
        obj.GetComponent<MeshRenderer>().material.mainTexture = webTexture;
        webTexture.Play();
    }

    void Update()
    {
        Quaternion camRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y,
            -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        this.transform.localRotation = camRotation;
    }
}
