using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.CameraOffAxisProjection.Scripts;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float f_offset;
    [SerializeField] CameraOffAxisProjection offAxis;
    #region We Might Still Use These
    //[SerializeField] float f_maxoffset;
    [SerializeField] Transform lookat;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lookat.rotation = new Quaternion(Input.GetAxis("Vertical") * f_offset, -Input.GetAxis("Horizontal") * f_offset, 0.0f, 1.0f);
        //offAxis.PointOfView = new Vector3(Input.GetAxis("Horizontal") * f_offset, Input.GetAxis("Vertical") * f_offset, 0);
        //transform.rotation = Quaternion.LookRotation(lookat.position - transform.TransformPoint(offAxis.PointOfView));
    }
}
