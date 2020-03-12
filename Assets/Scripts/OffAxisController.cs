using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.CameraOffAxisProjection.Scripts;

[ExecuteInEditMode]
public class OffAxisController : MonoBehaviour
{
    [SerializeField] CameraOffAxisProjection cameraView;


    private void Start()
    {
    }

    private void Update()
    {
        cameraView.PointOfView = transform.localToWorldMatrix * transform.localPosition;
    }
}
