Shader "Custom/Binoculars" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _Zoom ("Zoom", Range(0, 1)) = 0.5
        _Distortion ("Distortion", Range(-1, 1)) = 0.1
    }
    SubShader {
        Tags {"Queue"="Transparent" "RenderType"="Opaque"}
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _Zoom;
            float _Distortion;

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                float2 dist = i.uv - 0.5;
                float2 zoomedUV = i.uv + (dist * _Zoom);
                zoomedUV += sin(zoomedUV * 40.0) * _Distortion; // add distortion
                fixed4 col = tex2D(_MainTex, zoomedUV);
                return col;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
