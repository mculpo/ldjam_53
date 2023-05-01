Shader "Custom/Pulsing"
{
    Properties
    {
        [PerRendererData] _MainTex("Sprite Texture2D", 2D) = "white" {}
        _Color("Tint", Color) = (1,1,1,1)
        [MaterialToggle] PixelSnap("Pixel snap", Float) = 0
        _PulseColor("Pulse Color", Color) = (1,1,1,1)
        _PulseSpeed("Pulse Speed", Range(0, 10)) = 1
    }

        SubShader
        {
            Tags
            {
                "Queue" = "Transparent"
                "IgnoreProjector" = "True"
                "RenderType" = "Transparent"
                "PreviewType" = "Plane"
                "CanUseSpriteAtlas" = "True"
            }

            Cull Off
            Lighting Off
            ZWrite Off
            Fog { Mode Off }
            Blend One OneMinusSrcAlpha

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma multi_compile DUMMY PIXELSNAP_ON
                #include "UnityCG.cginc"

                struct appdata_t
                {
                    float4 vertex   : POSITION;
                    float4 color    : COLOR;
                    float2 texcoord : TEXCOORD0;
                };

                struct v2f
                {
                    float4 vertex   : SV_POSITION;
                    fixed4 color : COLOR;
                    half2 texcoord  : TEXCOORD0;
                };

                fixed4 _Color;
                fixed4 _PulseColor;
                float _PulseSpeed;

                v2f vert(appdata_t IN)
                {
                    v2f OUT;
                    OUT.vertex = UnityObjectToClipPos(IN.vertex);
                    OUT.texcoord = IN.texcoord;
                    OUT.color = IN.color * _Color;
                    #ifdef PIXELSNAP_ON
                    OUT.vertex = UnityPixelSnap(OUT.vertex);
                    #endif

                    return OUT;
                }

                sampler2D _MainTex;

                fixed4 frag(v2f IN) : SV_Target
                {
                    // Sample the sprite color and calculate its alpha
                    fixed4 spriteColor = tex2D(_MainTex, IN.texcoord) * IN.color;
                    float spriteAlpha = spriteColor.a;

                    // Calculate the pulse color using a triangular wave
                    float t = (_Time.y * _PulseSpeed) - floor(_Time.y * _PulseSpeed);
                    float pulse = (t < 0.5) ? t * 2.0 : (1.0 - t) * 2.0;
                    fixed4 pulseColor = lerp(_Color, _PulseColor, pulse);
                    pulseColor.rgb *= pulseColor.a;

                    // Combine the sprite color and pulse color using the sprite alpha as a mask
                    fixed4 finalColor = lerp(spriteColor, pulseColor, pulse);
                    finalColor.rgb *= spriteAlpha;
                    finalColor.a = spriteAlpha;

                    return finalColor;
                }



                ENDCG
            }
        }
}
