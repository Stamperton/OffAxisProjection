namespace Assets.CameraOffAxisProjection.Scripts.Attributes
{
  using System;

  using UnityEngine;

  [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Struct)]
  public class ConditionalHideAttribute : PropertyAttribute
  {
    public ConditionalHideAttribute(string serializableFieldName, object serializableFieldValue)
    {
      this.SerializableFieldName = serializableFieldName;
      this.SerializableFieldValue = serializableFieldValue;
      this.HideInInspector = true;
    }

    public ConditionalHideAttribute(string serializableFieldName, object serializableFieldValue, bool hideInInspector)
    {
      this.SerializableFieldName = serializableFieldName;
      this.SerializableFieldValue = serializableFieldValue;
      this.HideInInspector = hideInInspector;
    }

    public string SerializableFieldName { get; set; }

    public object SerializableFieldValue { get; set; }

    public bool HideInInspector { get; set; }
  }
}