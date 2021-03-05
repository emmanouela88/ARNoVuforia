using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaceObjects : MonoBehaviour
{
    [SerializeField]
    private GameObject placedObject;

    [SerializeField]
    private GameObject parentObject;
    /* [SerializeField]
     private Camera arCamera;*/

    /*private Vector2 touchPosition = default;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();*/

    private void Awake()
    {
        ChangeSelectedObject();
    }

    void ChangeSelectedObject()
    {
      
        GameObject temp = Instantiate(placedObject, placedObject.transform.position, Quaternion.identity);
        temp.transform.SetParent(parentObject.transform);
       
    }
}
