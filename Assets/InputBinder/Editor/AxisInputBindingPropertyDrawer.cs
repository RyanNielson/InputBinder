using UnityEditor;
using UnityEngine;

namespace RyanNielson.InputBinder
{
    [CustomPropertyDrawer(typeof(AxisInputBinding))]
    public class AxisInputBindingPropertyDrawer : PropertyDrawer 
    {
        private bool foldedOut = false;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) 
        {
            SerializedProperty name = property.FindPropertyRelative("name");
            SerializedProperty boundEvent = property.FindPropertyRelative("boundEvent");


            foldedOut = EditorGUI.Foldout(position, foldedOut, "Neato");
            if (foldedOut)
            {
                
                Rect namePosition = position;
                namePosition.y += 20;
                namePosition.height = EditorGUI.GetPropertyHeight(name);

                EditorGUI.PropertyField(namePosition, name, label, true);

                Rect boundEventPosition = namePosition;
                boundEventPosition.height = EditorGUI.GetPropertyHeight(boundEvent);
                boundEventPosition.y += namePosition.height;
                Debug.Log(namePosition);

                EditorGUI.PropertyField(boundEventPosition, boundEvent, label, true);
            }
            //Debug.Log(position);
            //Debug.Log(EditorGUI.GetPropertyHeight(name));
            

            //EditorGUI.PropertyField(position, property.FindPropertyRelative("name"));

           // Debug.Log(EditorGUI.GetPropertyHeight(
            //EditorGUI.PropertyField(position, property.FindPropertyRelative("boundEvent"));
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property);
        }
    }
}
