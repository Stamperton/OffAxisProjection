namespace Assets.CameraOffAxisProjection._Scenes.Scripts
{
  using System.Collections.Generic;

  using UnityEngine;

  public class CameraSwitcher : MonoBehaviour
  {
    [SerializeField]
    private List<Camera> cameras = new List<Camera>();

    private int activeIndex = 0;

    protected void Start()
    {
      foreach (var cameraComponent in this.cameras)
      {
        cameraComponent.enabled = false;
      }

      if (this.cameras.Count > 0)
      {
        this.cameras[this.activeIndex].enabled = true;
      }
    }

    protected void Update()
    {
      if (Input.GetKeyDown(KeyCode.F1))
      {
        if (this.cameras.Count > 0)
        {
          this.cameras[this.activeIndex].enabled = false;
          this.activeIndex = (this.activeIndex + 1) % this.cameras.Count;
          this.cameras[this.activeIndex].enabled = true;
        }
      }
    }
  }
}
