using UnityEditor;
using UnityEngine;

namespace Assets.FindDifferences.Scripts.Editor
{
    [CustomPropertyDrawer(typeof(ChangeTypes))]
    public class CustomEnumFlagsAttribute : PropertyAttribute
    {
        public CustomEnumFlagsAttribute() { }
    }
}