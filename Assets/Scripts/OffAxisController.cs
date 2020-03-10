using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.CameraOffAxisProjection.Scripts;

[ExecuteInEditMode]
public class OffAxisController : MonoBehaviour
{
    CameraOffAxisProjection cameraView;


    private void Start()
    {

        cameraView = GetComponentInParent<CameraOffAxisProjection>();
    }

    private void Update()
    {
        cameraView.PointOfView = this.transform.localPosition;
    }
}
