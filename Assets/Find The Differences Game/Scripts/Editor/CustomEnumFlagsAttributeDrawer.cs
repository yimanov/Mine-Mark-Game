using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Assets.FindDifferences.Scripts.Editor
{
    [CustomPropertyDrawer(typeof(CustomEnumFlagsAttribute))]
    [CustomPropertyDrawer(typeof(ChangeTypes))]
    public class CustomEnumFlagsAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            Enum targetEnum = GetBaseProperty<Enum>(property);

            EditorGUI.BeginProperty(position, label, property);

            var newValue = EditorGUI.EnumMaskField(position, label, targetEnum);
            //if (EditorGUI.EndChangeCheck())
            {
                property.intValue = (int)Convert.ChangeType(newValue, targetEnum.GetType());
            }
            EditorGUI.EndProperty();
        }

        static T GetBaseProperty<T>(SerializedProperty prop)
        {
            // Separate the steps it takes to get to this property
            string[] separatedPaths = prop.propertyPath.Split('.');

            // Go down to the root of this serialized property
            System.Object reflectionTarget = prop.serializedObject.targetObject as object;
            // Walk down the path to get the target object
            foreach (var path in separatedPaths)
            {
                FieldInfo fieldInfo = reflectionTarget.GetType().GetField(path);
                reflectionTarget = fieldInfo.GetValue(reflectionTarget);
            }
            return (T)reflectionTarget;
        }
    }


}