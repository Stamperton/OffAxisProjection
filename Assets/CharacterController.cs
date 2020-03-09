using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float f_offset;
    [SerializeField] Transform lookat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
            transform.position += (new Vector3((Input.GetAxisRaw("Horizontal") * f_offset) * Time.deltaTime, 0, 0));
        if (Input.GetAxisRaw("Vertical") != 0)
            transform.position += (new Vector3(0, (Input.GetAxisRaw("Vertical") * f_offset) * Time.deltaTime, 0));
        transform.LookAt(lookat);
    }
}
