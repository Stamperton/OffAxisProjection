#pragma warning disable 649
namespace Assets.CameraOffAxisProjection._Scenes.Scripts
{
  using System;

  using UnityEngine;

  [RequireComponent(typeof(CharacterController))]
  public class SimpleCharacterController : MonoBehaviour
  {
    [Header("Settings")]

    [SerializeField]
    private Transform headTransform;

    [SerializeField]
    [Range(0.0f, 50)]
    private float movementSpeed = 25.0f;

    [SerializeField]
    [Range(0.0f, 90.0f)]
    private float rotationSpeed = 90.0f;

    [Header("Input")]

    [SerializeField]
    private string moveForwardAxisName = "Vertical";

    [SerializeField]
    private string moveLateralAxisName = "Horizontal";

    [SerializeField]
    private string rotationYawAxisName = "Mouse X";

    [SerializeField]
    private string rotationPitchAxisName = "Mouse Y";

    private CharacterController characterController;

    private Vector3 moveDirection = Vector3.zero;

    private Vector3 eulerAngles = Vector3.zero;

    protected void Awake()
    {
      this.characterController = this.GetComponent<CharacterController>();
    }

    protected void Update()
    {
      try
      {
        this.moveDirection.x = Input.GetAxis(this.moveLateralAxisName) * this.movementSpeed;
        this.moveDirection.z = Input.GetAxis(this.moveForwardAxisName) * this.movementSpeed;

        this.eulerAngles.x = -Input.GetAxis(this.rotationPitchAxisName) * this.rotationSpeed * Time.deltaTime;
        this.eulerAngles.y = Input.GetAxis(this.rotationYawAxisName) * this.rotationSpeed * Time.deltaTime;

        if (this.headTransform != null)
        {
          this.headTransform.transform.Rotate(this.eulerAngles.x, 0.0f, 0.0f);
        }

        this.characterController.transform.Rotate(0.0f, this.eulerAngles.y, 0.0f);
        this.characterController.SimpleMove(this.transform.TransformDirection(this.moveDirection));
      }
      catch (Exception exception)
      {
        Debug.LogException(exception);
        this.enabled = false;
      }
    }
  }
}
