//
// KinoContour - Contour line effect
//
// Copyright (C) 2015 Keijiro Takahashi
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using UnityEngine;
using UnityEditor;

namespace Kino
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(Contour))]
    public class ContourEditor : Editor
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
