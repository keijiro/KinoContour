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

namespace Kino
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Camera))]
    [AddComponentMenu("Kino Image Effects/Contour")]
    public class Contour : MonoBehaviour
    {
        #region Public Properties

        // Line color
        [SerializeField]
        Color _lineColor = Color.black;

        public Color lineColor {
            get { return _lineColor; }
            set { _lineColor = value; }
        }

        // Filter strength
        [SerializeField, Range(1, 10)]
        float _filterStrength = 1;

        public float filterStrength {
            get { return _filterStrength; }
            set { _filterStrength = value; }
        }

        // Filter threshold
        [SerializeField, Range(0.1f, 1.0f)]
        float _filterThreshold = 0.1f;

        public float filterThreshold {
            get { return _filterThreshold; }
            set { _filterThreshold = value; }
        }

        // Depth fall-off
        [SerializeField]
        float _fallOffDepth = 40;

        public float fallOffDepth {
            get { return _fallOffDepth; }
            set { _fallOffDepth = value; }
        }

        // Background color
        [SerializeField]
        Color _backgroundColor = new Color(1, 1, 1, 0);

        public Color backgroundColor {
            get { return _backgroundColor; }
            set { _backgroundColor = value; }
        }

        #endregion

        #region Private Properties

        [SerializeField] Shader _shader;

        Material _material;

        #endregion

        #region MonoBehaviour Functions

        void OnEnable()
        {
            GetComponent<Camera>().depthTextureMode |= DepthTextureMode.Depth;
        }

        void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if (_material == null)
            {
                _material = new Material(_shader);
                _material.hideFlags = HideFlags.DontSave;
            }

            _material.SetFloat("_Strength", _filterStrength);
            _material.SetFloat("_Threshold", _filterThreshold);
            _material.SetFloat("_FallOffDepth", _fallOffDepth);
            _material.SetColor("_Color", _lineColor);
            _material.SetColor("_BgColor", _backgroundColor);

            Graphics.Blit(source, destination, _material);
        }

        #endregion
    }
}
