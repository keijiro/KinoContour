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

        // Filter type
        public enum FilterType {
            Thick, ThinInner, ThinOuter
        }

        [SerializeField]
        FilterType _filterType = FilterType.ThinInner;

        public FilterType filterType {
            get { return _filterType; }
            set { _filterType = value; }
        }

        // Line width
        [SerializeField, Range(1, 8)]
        int _lineWidth = 1;

        public int lineWidth {
            get { return _lineWidth; }
            set { _lineWidth = value; }
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

            if (_filterType == FilterType.ThinInner)
            {
                _material.DisableKeyword("DISCARD_INNER");
                _material.EnableKeyword("DISCARD_OUTER");
            }
            else if (_filterType == FilterType.ThinOuter)
            {
                _material.EnableKeyword("DISCARD_INNER");
                _material.DisableKeyword("DISCARD_OUTER");
            }
            else
            {
                _material.DisableKeyword("DISCARD_INNER");
                _material.DisableKeyword("DISCARD_OUTER");
            }

            _material.SetFloat("_Distance", _lineWidth);
            _material.SetColor("_Color", _lineColor);
            _material.SetColor("_BgColor", _backgroundColor);

            Graphics.Blit(source, destination, _material);
        }

        #endregion
    }
}
