using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.CameraOffAxisProjection.Scripts;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField] float f_offset;
    [SerializeField] CameraOffAxisProjection offAxis;
    [SerializeField] Transform lookat;
    [SerializeField] Text xRot;
    [SerializeField] Text yRot;
    #region We Might Still Use These
    //[SerializeField] float f_maxoffset;
    #endregion
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lookat.rotation = new Quaternion(Input.GetAxis("Vertical") * f_offset, -Input.GetAxis("Horizontal") * f_offset, 0.0f, 1.0f);
        xRot.text = (lookat.rotation.eulerAngles.x).ToString();
        yRot.text = (lookat.rotation.eulerAngles.y).ToString();
        //offAxis.PointOfView = new Vector3(Input.GetAxis("Horizontal") * f_offset, Input.GetAxis("Vertical") * f_offset, 0);
        //transform.rotation = Quaternion.LookRotation(lookat.position - transform.TransformPoint(offAxis.PointOfView));
    }
}
