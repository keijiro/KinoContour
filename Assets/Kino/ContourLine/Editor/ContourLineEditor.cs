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
        SerializedProperty _filterStrength;
        SerializedProperty _filterThreshold;
        SerializedProperty _fallOffDepth;
        SerializedProperty _backgroundColor;

        void OnEnable()
        {
            _lineColor = serializedObject.FindProperty("_lineColor");
            _filterStrength = serializedObject.FindProperty("_filterStrength");
            _filterThreshold = serializedObject.FindProperty("_filterThreshold");
            _fallOffDepth = serializedObject.FindProperty("_fallOffDepth");
            _backgroundColor = serializedObject.FindProperty("_backgroundColor");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_lineColor);
            EditorGUILayout.PropertyField(_filterStrength);
            EditorGUILayout.PropertyField(_filterThreshold);
            EditorGUILayout.PropertyField(_fallOffDepth);
            EditorGUILayout.PropertyField(_backgroundColor);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
