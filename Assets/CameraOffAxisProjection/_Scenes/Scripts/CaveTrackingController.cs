#pragma warning disable 649
namespace Assets.CameraOffAxisProjection._Scenes.Scripts
{
  using UnityEngine;

  [RequireComponent(typeof(Collider))]
  public class CaveTrackingController : MonoBehaviour
  {
    [SerializeField]
    private Transform localViewPoinTransform;

    private CaveTransformTracker currentCaveTransformTracker;

    public bool Tracking
    {
      get
      {
        return this.currentCaveTransformTracker != null;
      }
    }

    protected void OnTriggerEnter(Collider other)
    {
      if (this.currentCaveTransformTracker == null)
      {
        var caveTransformTracker = other.GetComponent<CaveTransformTracker>();
        if (caveTransformTracker != null)
        {
          this.currentCaveTransformTracker = caveTransformTracker;
        }
      }
    }

    protected void OnTriggerExit(Collider other)
    {
      var caveTransformTracker = other.GetComponent<CaveTransformTracker>();
      if (object.ReferenceEquals(caveTransformTracker, this.currentCaveTransformTracker))
      {
        this.currentCaveTransformTracker = null;
      }
    }

    protected void Update()
    {
      if (this.currentCaveTransformTracker != null)
      {
        this.localViewPoinTransform.localPosition =
          this.transform.InverseTransformPoint(this.currentCaveTransformTracker.transform.position);
      }
    }
  }
}
