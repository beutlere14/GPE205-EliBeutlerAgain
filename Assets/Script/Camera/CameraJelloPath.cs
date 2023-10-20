using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraJelloPath : MonoBehaviour
{
    public Camera roomCam;
    public GameObject playerGO;
    private float camMotionSpeed = 5f;
    private float camRotationSpeed = 50f;
    Vector3 camOffset;

    void Start()
    {
        camOffset = new Vector3(0, 3, -8);  //x=sideways, y=up/down, z = forward/back
        roomCam.transform.position = playerGO.transform.position + (roomCam.transform.forward * camOffset.z) + (playerGO.transform.up * camOffset.y);
        roomCam.transform.LookAt(playerGO.transform.position);
    }

    private void UpdateCameraPosition()
    {

        //Move
        Vector3 newCamPosition = playerGO.transform.position + (playerGO.transform.forward * camOffset.z) + (playerGO.transform.up * camOffset.y);
        newCamPosition = Vector3.Slerp(roomCam.transform.position, newCamPosition, Time.smoothDeltaTime * camMotionSpeed); //spherical lerp smoothing
        roomCam.transform.position = newCamPosition;

        //Rotate
        Quaternion newCamRotation = Quaternion.LookRotation(playerGO.transform.position - roomCam.transform.position);
        newCamRotation = Quaternion.Slerp(roomCam.transform.rotation, newCamRotation, camRotationSpeed * Time.smoothDeltaTime); //spherical lerp smoothing
        roomCam.transform.rotation = newCamRotation;

    }

    private void LateUpdate()
    {
        UpdateCameraPosition();
    }
}
