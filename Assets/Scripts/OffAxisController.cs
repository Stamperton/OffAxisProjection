using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.CameraOffAxisProjection.Scripts;

public class OffAxisController : MonoBehaviour
{
    CameraOffAxisProjection cameraView;
    Animator anim;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
        cameraView = GetComponentInParent<CameraOffAxisProjection>();
    }

    private void Update()
    {
        cameraView.PointOfView = this.transform.localPosition;
        if (Input.GetAxis("Horizontal") < 0)
        {
            anim.SetBool("LeanRight", false);
            anim.SetBool("LeanLeft", true);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            anim.SetBool("LeanLeft", false);
            anim.SetBool("LeanRight", true);
        }
        else if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("LeanLeft", false);
            anim.SetBool("LeanRight", false);
        }

        Debug.Log(Input.GetAxis("Horizontal"));
    }
}
