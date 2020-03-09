namespace Assets.CameraOffAxisProjection.Scripts.Editor
{
  using System;
  using System.Globalization;

  using Assets.CameraOffAxisProjection.Scripts;

  using UnityEditor;

  using UnityEngine;

  [CustomEditor(typeof(CameraOffAxisProjection))]
  [CanEditMultipleObjects]
  public class CameraOffAxisProjectionEditor : Editor
  {
    private CameraOffAxisProjection cameraOffAxisProjection;

    public override void OnInspectorGUI()
    {
      base.OnInspectorGUI();

      if (this.targets.Length == 1)
      {
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        EditorGUILayout.LabelField(
          "Viewport Width",
          this.cameraOffAxisProjection.ViewportSize.x.ToString(CultureInfo.CurrentCulture));
        EditorGUILayout.LabelField(
          "Viewport Height",
          this.cameraOffAxisProjection.ViewportSize.y.ToString(CultureInfo.CurrentCulture));

        var formatAspectRation = FormatAspectRatio(this.cameraOffAxisProjection.Camera.aspect);
        EditorGUILayout.LabelField("Aspect Ratio", string.Format("{0}:{1}", formatAspectRation.x, formatAspectRation.y));

        EditorGUILayout.Space();

        if (this.cameraOffAxisProjection.UseFixedAspectRatio
            && this.cameraOffAxisProjection.UseAspectAsViewportSize)
        {
          EditorGUILayout.HelpBox(
            "The properties 'Projection', 'Near Clip Plane' and 'Field of View' of the component 'Camera' are handled by this component",
            MessageType.Info);
        }
        else
        {
          EditorGUILayout.HelpBox(
            "The properties 'Projection' and 'Near Clip Plane' of the component 'Camera' are handled by this component",
            MessageType.Info);
        }
      }
      else
      {
        EditorGUILayout.Space();

        EditorGUILayout.HelpBox(
          "The properties 'Projection', 'Near Clip Plane' and 'Field of View' (if the properties 'Use Fixed Aspect Ratio' and 'Use Aspect As Viewport Size' are true) of the component 'Camera' are handled by this component",
          MessageType.Info);
      }
    }

    protected void OnSceneGUI()
    {
      if (Event.current.type == EventType.Repaint)
      {
        Handles.color = Color.white;
        Handles.SphereHandleCap(
          1,
          this.cameraOffAxisProjection.WorldPointOfView,
          this.cameraOffAxisProjection.transform.rotation,
          0.1f,
          EventType.Repaint);
      }

      EditorGUI.BeginChangeCheck();

      var position = Handles.PositionHandle(this.cameraOffAxisProjection.WorldPointOfView, this.cameraOffAxisProjection.transform.rotation);

      if (EditorGUI.EndChangeCheck())
      {
        this.cameraOffAxisProjection.WorldPointOfView = position;

        if (!Application.isPlaying)
        {
          Undo.RegisterCompleteObjectUndo(this.cameraOffAxisProjection, this.cameraOffAxisProjection.GetType().FullName);
          EditorUtility.SetDirty(this.cameraOffAxisProjection);
        }
      }
    }

    protected void OnEnable()
    {
      this.cameraOffAxisProjection = (CameraOffAxisProjection)this.target;
    }

    private static Vector2 FormatAspectRatio(float aspectRatio)
    {
      int i = 0;
      while (true)
      {
        i++;
        if (Math.Abs(Math.Round(aspectRatio * i, 2) - Mathf.RoundToInt(aspectRatio * i)) < Mathf.Epsilon)
        {
          break;
        }
      }

      return new Vector2((float)Math.Round(aspectRatio * i, 2), i);
    }
  }
}
