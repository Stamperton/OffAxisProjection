namespace Assets.CameraOffAxisProjection.Scripts.Helpers
{
  using UnityEngine;

  public static class Matrix4x4Helper
  {
    public static Matrix4x4 Perspective(float left, float right, float bottom, float top, float near, float far)
    {
      var perspective = new Matrix4x4();
      perspective[0, 0] = 2.0f * near / (right - left);
      perspective[0, 1] = 0.0f;
      perspective[0, 2] = (right + left) / (right - left);
      perspective[0, 3] = 0.0f;

      perspective[1, 0] = 0.0f;
      perspective[1, 1] = 2.0f * near / (top - bottom);
      perspective[1, 2] = (top + bottom) / (top - bottom);
      perspective[1, 3] = 0.0f;

      perspective[2, 0] = 0.0f;
      perspective[2, 1] = 0.0f;
      perspective[2, 2] = (far + near) / (near - far);
      perspective[2, 3] = 2.0f * far * near / (near - far);

      perspective[3, 0] = 0.0f;
      perspective[3, 1] = 0.0f;
      perspective[3, 2] = -1.0f;
      perspective[3, 3] = 0.0f;

      return perspective;
    }

    public static Matrix4x4 Rotation(Vector3 right, Vector3 up, Vector3 forward)
    {
      var rotationMatrix = new Matrix4x4();
      rotationMatrix[0, 0] = right.x;
      rotationMatrix[0, 1] = right.y;
      rotationMatrix[0, 2] = right.z;
      rotationMatrix[0, 3] = 0.0f;

      rotationMatrix[1, 0] = up.x;
      rotationMatrix[1, 1] = up.y;
      rotationMatrix[1, 2] = up.z;
      rotationMatrix[1, 3] = 0.0f;

      rotationMatrix[2, 0] = forward.x;
      rotationMatrix[2, 1] = forward.y;
      rotationMatrix[2, 2] = forward.z;
      rotationMatrix[2, 3] = 0.0f;

      rotationMatrix[3, 0] = 0.0f;
      rotationMatrix[3, 1] = 0.0f;
      rotationMatrix[3, 2] = 0.0f;
      rotationMatrix[3, 3] = 1.0f;

      return rotationMatrix;
    }

    public static Matrix4x4 Translation(Vector3 translation)
    {
      var translationMatrix = new Matrix4x4();
      translationMatrix[0, 0] = 1.0f;
      translationMatrix[0, 1] = 0.0f;
      translationMatrix[0, 2] = 0.0f;
      translationMatrix[0, 3] = -translation.x;

      translationMatrix[1, 0] = 0.0f;
      translationMatrix[1, 1] = 1.0f;
      translationMatrix[1, 2] = 0.0f;
      translationMatrix[1, 3] = -translation.y;

      translationMatrix[2, 0] = 0.0f;
      translationMatrix[2, 1] = 0.0f;
      translationMatrix[2, 2] = 1.0f;
      translationMatrix[2, 3] = -translation.z;

      translationMatrix[3, 0] = 0.0f;
      translationMatrix[3, 1] = 0.0f;
      translationMatrix[3, 2] = 0.0f;
      translationMatrix[3, 3] = 1.0f;

      return translationMatrix;
    }
  }
}
