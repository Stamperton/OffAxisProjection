#pragma warning disable 649
namespace Assets.CameraOffAxisProjection._Scenes.Scripts
{
  using UnityEngine;

  public class CaveCanvasController : MonoBehaviour
  {
    [SerializeField]
    private GameObject panelNotificationGameObject;

    [SerializeField]
    private CaveTrackingController caveTrackingController;

    protected void Update()
    {
      if (this.panelNotificationGameObject != null && this.caveTrackingController != null)
      {
        this.panelNotificationGameObject.SetActive(this.caveTrackingController.Tracking);
      }
    }
  }
}
