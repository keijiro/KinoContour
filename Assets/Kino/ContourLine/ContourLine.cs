//
// ContourLine - Contour line effect with depth Sobel filter
//
// http://github.com/keijiro/ContourLine
//
using UnityEngine;

namespace Kino
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Camera))]
    [AddComponentMenu("Kino Image Effects/Contour Line")]
    public class ContourLine : MonoBehaviour
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
