using UnityEditor;
using UnityEngine;

namespace RyanNielson.InputBinder
{
	[CustomPropertyDrawer(typeof(AxisInputBinding))]
	public class AxisInputBindingPropertyDrawer : PropertyDrawer 
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) 
		{
			EditorGUI.PropertyField(position, property, label, true);
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return EditorGUI.GetPropertyHeight(property);
		}
	}
}
