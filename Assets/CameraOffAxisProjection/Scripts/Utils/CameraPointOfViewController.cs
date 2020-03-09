namespace Assets.CameraOffAxisProjection.Scripts.Utils
{
  using Assets.CameraOffAxisProjection.Scripts;

  using UnityEngine;

  [ExecuteInEditMode]
  [RequireComponent(typeof(CameraOffAxisProjection))]
  public class CameraPointOfViewController : MonoBehaviour
  {
    [SerializeField]
    private Transform pointOfViewTransform;

    private CameraOffAxisProjection cameraOffAxisProjection;

    public Transform PointOfViewTransform
    {
      get
      {
        return this.pointOfViewTransform;
      }

      set
      {
        this.pointOfViewTransform = value;
      }
    }

    public CameraOffAxisProjection CameraOffAxisProjection
    {
      get
      {
        return this.cameraOffAxisProjection;
      }
    }

    protected void Awake()
    {
      this.cameraOffAxisProjection = this.GetComponent<CameraOffAxisProjection>();
    }

    protected void Update()
    {
      if (this.pointOfViewTransform != null)
      {
        this.cameraOffAxisProjection.WorldPointOfView = this.pointOfViewTransform.position;
      }
    }

    protected void OnValidate()
    {
      if (this.pointOfViewTransform == null)
      {
        Debug.LogError(
          string.Format(
            "The variable '{0}' of '{1}' of the game object '{2}' has not been assigned.",
            " Point Of View Transform",
            this.GetType().Name,
            this.name),
          this.gameObject);
      }
    }
  }
}
