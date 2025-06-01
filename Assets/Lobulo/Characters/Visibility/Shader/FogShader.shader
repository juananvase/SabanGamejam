Shader "Hidden/FogDraw"
{
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        Pass
        {
            ZTest Always Cull Off ZWrite Off
            Blend DstColor Zero

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata { float4 vertex : POSITION; float2 uv : TEXCOORD0; };
            struct v2f { float4 pos : SV_POSITION; float2 uv : TEXCOORD0; };

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 center = float2(0.5, 0.5);
                float2 normUV = (i.uv - center) * 2.0;
                float dist = length(normUV);

                float radius = 0.5; // puedes ajustar esto según tu necesidad
                if (dist > radius)
                    clip(-1); // descarta fragmento fuera del círculo

                return fixed4(1, 1, 1, 0.2); // dentro del círculo, color blanco pero alfa 0 (transparente)
            }
            ENDCG
        }
    }
}
