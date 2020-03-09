namespace Assets.CameraOffAxisProjection.Scripts.Attributes.Editor
{
  using Assets.CameraOffAxisProjection.Scripts.Attributes;

  using UnityEditor;

  using UnityEngine;

  [CustomPropertyDrawer(typeof(ConditionalHideAttribute))]
  public class ConditionalHidePropertyDrawer : PropertyDrawer
  {
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
      ConditionalHideAttribute conditionalHideAttribute = (ConditionalHideAttribute)this.attribute;

      bool enabled = this.EvaluateCondition(conditionalHideAttribute, property);
      bool wasEnabled = GUI.enabled;

      GUI.enabled = enabled;

      if (!conditionalHideAttribute.HideInInspector || enabled)
      {
        EditorGUI.PropertyField(position, property, label, true);
      }

      GUI.enabled = wasEnabled;
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
      ConditionalHideAttribute conditionalHideAttribute = (ConditionalHideAttribute)this.attribute;
      bool enabled = this.EvaluateCondition(conditionalHideAttribute, property);

      if (!conditionalHideAttribute.HideInInspector || enabled)
      {
        return EditorGUI.GetPropertyHeight(property, label);
      }

      return -EditorGUIUtility.standardVerticalSpacing;
    }

    private bool EvaluateCondition(ConditionalHideAttribute conditionalHideAttribute, SerializedProperty serializedProperty)
    {
      SerializedProperty conditionalSerializedProperty = serializedProperty.serializedObject.FindProperty(conditionalHideAttribute.SerializableFieldName);

      if (conditionalSerializedProperty != null)
      {
        object value;
        switch (conditionalSerializedProperty.propertyType)
        {
          case SerializedPropertyType.Boolean:
            {
              value = conditionalSerializedProperty.boolValue;
              break;
            }

          case SerializedPropertyType.Color:
            {
              value = conditionalSerializedProperty.colorValue;
              break;
            }

          case SerializedPropertyType.Enum:
            {
              value = conditionalSerializedProperty.enumValueIndex;
              break;
            }

          case SerializedPropertyType.Float:
            {
              value = conditionalSerializedProperty.floatValue;
              break;
            }

          case SerializedPropertyType.Integer:
            {
              value = conditionalSerializedProperty.intValue;
              break;
            }

          case SerializedPropertyType.Vector2:
            {
              value = conditionalSerializedProperty.vector2Value;
              break;
            }

          case SerializedPropertyType.Vector3:
            {
              value = conditionalSerializedProperty.vector3Value;
              break;
            }

          case SerializedPropertyType.Vector4:
            {
              value = conditionalSerializedProperty.vector4Value;
              break;
            }

          case SerializedPropertyType.Quaternion:
            {
              value = conditionalSerializedProperty.quaternionValue;
              break;
            }

          case SerializedPropertyType.String:
            {
              value = conditionalSerializedProperty.stringValue;
              break;
            }

          case SerializedPropertyType.ObjectReference:
            {
              value = conditionalSerializedProperty.objectReferenceValue;
              break;
            }

          default:
            {
              Debug.LogError(
                string.Format(
                  "Data type '{0}' of the serialized property '{1}' is currently not supported. The conditional hiding of the serializable field '{2}' can not be evaluated",
                  conditionalSerializedProperty.propertyType,
                  conditionalHideAttribute.SerializableFieldName,
                  serializedProperty.name));

              return true;
            }
        }

        return object.Equals(value, conditionalHideAttribute.SerializableFieldValue);
      }

      Debug.LogError(
        string.Format(
          "The serialized property '{0}' was not found in the serialized object. The conditional hiding of the serializable field '{1}' can not be evaluated",
          conditionalHideAttribute.SerializableFieldName,
          serializedProperty.name));

      return true;
    }
  }
}
