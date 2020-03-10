using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.CameraOffAxisProjection.Scripts;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float f_offset;
    [SerializeField] float f_maxoffset;
    [SerializeField] Transform lookat;
    [SerializeField] CameraOffAxisProjection offAxis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        offAxis.PointOfView = new Vector3(Input.GetAxis("Horizontal") * f_offset, Input.GetAxis("Vertical") * f_offset /* Time.deltaTime*/, 0);
    }
}
