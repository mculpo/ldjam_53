Shader "Custom/CameraShake"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _Magnitude("Magnitude", Range(0, 0.1)) = 0.05
        _Speed("Speed", Range(0, 10)) = 1
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

                float _Magnitude;
                float _Speed;

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex) + float4(sin(_Time.y * _Speed + v.vertex.xy), 0, 0) * _Magnitude;
                    o.uv = v.uv;
                    return o;
                }

                sampler2D _MainTex;

                fixed4 frag(v2f i) : SV_Target
                {
                    return tex2D(_MainTex, i.uv);
                }

                ENDCG
            }
        }
}