using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

public class PlaceOnPlane : MonoBehaviour
{
    ARRaycastManager raycastManager;
    List<ARRaycastHit> hits;

    public GameObject model;
    // Start is called before the first frame update
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        hits = new List<ARRaycastHit>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);

        if (isPointerOverUIObjects(touch.position))
            return;

        if (raycastManager.Raycast(touch.position, hits))
        {
            Pose pose = hits[0].pose;

            Instantiate(model, pose.position, pose.rotation);
        }
    }

    bool isPointerOverUIObjects(Vector2 pos)
    {
        if (EventSystem.current == null)
            return false;

        PointerEventData eventOnCurrentPosition = new PointerEventData(EventSystem.current);
        eventOnCurrentPosition.position = new Vector2(pos.x, pos.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventOnCurrentPosition, results);
        return results.Count > 0;
    }
}
