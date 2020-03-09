using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float f_offset;
    [SerializeField] float f_maxoffset;
    [SerializeField] Transform lookat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * f_offset * Time.deltaTime, 0, 0);
        transform.position += new Vector3(0, Input.GetAxisRaw("Vertical") * f_offset * Time.deltaTime, 0);
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -f_maxoffset, f_maxoffset), Mathf.Clamp(transform.position.y, -f_maxoffset, f_maxoffset), Mathf.Clamp(transform.position.z, -f_maxoffset, f_maxoffset));
        transform.LookAt(lookat);
    }
}
