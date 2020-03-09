#pragma warning disable 649
namespace Assets.CameraOffAxisProjection._Scenes.Scripts
{
  using UnityEngine;

  [ExecuteInEditMode]
  public class CopyLocalPosition : MonoBehaviour
  {
    [SerializeField]
    private Transform sourceTransform;

#if UNITY_EDITOR
    protected void Awake()
    {
      if (!Application.isPlaying)
      {
        UnityEditor.EditorApplication.QueuePlayerLoopUpdate();
      }
    }
#endif

    protected void Update()
    {
      if (this.sourceTransform != null)
      {
        this.transform.localPosition = this.sourceTransform.localPosition;
      }
    }
  }
}
