//
// ContourLine - Contour line effect with depth Sobel filter
//
// http://github.com/keijiro/ContourLine
//
Shader "Hidden/ContourLine"
{
    Properties
    {
        _MainTex ("-", 2D) = "" {}
        _Color ("-", Color) = (0, 0, 0, 1)
        _BgColor ("-", Color) = (1, 1, 1, 0)
    }
    CGINCLUDE

    #include "UnityCG.cginc"

    sampler2D _MainTex;
    float2 _MainTex_TexelSize;

    float _Strength;
    float _Threshold;
    float _FallOffDepth;
    half4 _Color;
    half4 _BgColor;

    sampler2D_float _CameraDepthTexture;

    float get_depth(float2 uv)
    {
        return Linear01Depth(SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, uv));
    }

    half4 frag(v2f_img i) : SV_Target
    {
        half4 source = tex2D(_MainTex, i.uv);

        float4 d = float4(_MainTex_TexelSize.xy, -_MainTex_TexelSize.x, 0);

        float z0_sample = SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, i.uv);
        float z0_real = LinearEyeDepth(z0_sample);
        float z0 = Linear01Depth(z0_sample);

        float4 z_diag = float4(
            get_depth(i.uv + d.xy), // TR
            get_depth(i.uv + d.zy), // TL
            get_depth(i.uv - d.zy), // BR
            get_depth(i.uv - d.xy)  // BL
        );

        float4 z_axis = float4(
            get_depth(i.uv + d.wy), // T
            get_depth(i.uv - d.xw), // L
            get_depth(i.uv + d.xw), // R
            get_depth(i.uv - d.wy)  // B
        );

        z_diag = max(z_diag, z0.xxxx);
        z_axis = max(z_axis, z0.xxxx);

        z_diag -= z0;
        z_axis /= z0;

        float4 sobel_h = z_diag * float4( 1,  1, -1, -1) + z_axis * float4( 1,  0,  0, -1);
        float4 sobel_v = z_diag * float4(-1,  1, -1,  1) + z_axis * float4( 0,  1, -1,  0);

        float sobel_x = dot(sobel_h, (float4)1);
        float sobel_y = dot(sobel_v, (float4)1);

        float sobel = sqrt(sobel_x * sobel_x + sobel_y * sobel_y);
        float falloff = 1.0 - saturate(z0_real / _FallOffDepth);
        float op = saturate((sobel * falloff - _Threshold) * _Strength);

        half3 c_0 = lerp(source.rgb, _BgColor.rgb, _BgColor.a);
        half3 c_o = lerp(c_0, _Color.rgb, op * _Color.a);
        return half4(c_o, source.a);
    }

    ENDCG
    SubShader
    {
        Pass
        {
            ZTest Always Cull Off ZWrite Off
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
            #pragma target 3.0
            ENDCG
        }
    }
}
