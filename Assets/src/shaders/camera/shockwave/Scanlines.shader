Shader "Custom/Scanlines"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _ScanlineIntensity("Scanline Intensity", Range(0, 1)) = 0.5
        _ScanlineFrequency("Scanline Frequency", Range(0, 200)) = 100
    }

        SubShader
        {
            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                sampler2D _MainTex;
                float _ScanlineIntensity;
                float _ScanlineFrequency;

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    float4 col = tex2D(_MainTex, i.uv);
                    float scanline = (frac(i.vertex.y * _ScanlineFrequency) < 0.5) ? 1.0 : 0.0;
                    col.rgb -= col.rgb * scanline * _ScanlineIntensity;
                    return col;
                }

                ENDCG
            }
        }

            FallBack "Diffuse"
}
