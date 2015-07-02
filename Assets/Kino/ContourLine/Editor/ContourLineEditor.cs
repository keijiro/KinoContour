//
// ContourLine - Contour line effect with depth Sobel filter
//
// http://github.com/keijiro/ContourLine
//
using UnityEngine;
using UnityEditor;

namespace Kino
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(ContourLine))]
    public class ContourLineEditor : Editor
    {
        SerializedProperty _lineColor;
        SerializedProperty _filterType;
        SerializedProperty _sensitivity;
        SerializedProperty _fallOffDepth;
        SerializedProperty _backgroundColor;

        void OnEnable()
        {
            _lineColor = serializedObject.FindProperty("_lineColor");
            _filterType = serializedObject.FindProperty("_filterType");
            _sensitivity = serializedObject.FindProperty("_sensitivity");
            _fallOffDepth = serializedObject.FindProperty("_fallOffDepth");
            _backgroundColor = serializedObject.FindProperty("_backgroundColor");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_lineColor);
            EditorGUILayout.PropertyField(_filterType);
            EditorGUILayout.PropertyField(_sensitivity);
            EditorGUILayout.PropertyField(_fallOffDepth);
            EditorGUILayout.PropertyField(_backgroundColor);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
