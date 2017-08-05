// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Light" {
	Properties {
		_MainTex("Main Texture", 2D) = "white" {}
		_PartTex("Particle Texture", 2D) = "black" {}
		_Color("Tint", Color) = (1, 1, 1, 1)
		_Contrast("Contrast", Float) = 0.8
		_Colorise("Colorise", Float) = 0.7
		_PartAmp("Particle wave amplitude", Float) = 0.2
		_PartBlend("Particle blending", Float) = 0.3
	}
	SubShader {
		Tags {
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
			"ForceNoShadowCasting" = "True"
		}
		Pass {
			Cull Off
			AlphaTest Greater 0.0
			Blend DstColor One

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;
			uniform float4 _Color;
			uniform float _Contrast;

			struct vert_in {
				float4 vertex	: POSITION;
				float2 uv		: TEXCOORD0;
				float4 color	: COLOR;
			};
			struct vert_out {
				float4 pos		: SV_POSITION;
				float2 uv		: TEXCOORD0;
				float4 color	: COLOR;
				float intensity : TEXCOORD1;
			};

			vert_out vert(vert_in vin) {
				vert_out vout;
				vout.pos = UnityObjectToClipPos(vin.vertex);
				float4 centre = UnityObjectToClipPos(float4(0, 0, 0, 1));
				vout.uv = vin.uv;
				vout.color = vin.color;
				vout.intensity = length(vout.pos * _SinTime.x * 0.2 - centre);

				return vout;
			}

			float4 frag(vert_out vin) : COLOR {
				float4 col = tex2D(_MainTex, vin.uv);
				col.rgb *= _Color.rgb * vin.color.rgb * _Color.a;
				col.rgb *= vin.intensity;
				//col.rgb *=  vin.color.a;
				col *= _Contrast;
				//return float4(vin.intensity, vin.intensity, vin.intensity, vin.intensity);
				return col;
			}

			ENDCG
		}
		Pass {
			AlphaTest Greater 0.0
			Blend SrcAlpha One

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;
			uniform sampler2D _PartTex;
			float4 _PartTex_ST;
			uniform float4 _Color;
			uniform float _Colorise;
			uniform float _PartAmp;
			uniform float _PartBlend;

			struct vert_in {
				float4 vertex	: POSITION;
				float2 uv		: TEXCOORD0;
				float4 color	: COLOR;
			};
			struct vert_out {
				float4 pos		: SV_POSITION;
				float2 uv		: TEXCOORD0;
				float2 uv_part	: TEXCOORD1;
				float4 color	: COLOR;
			};

			vert_out vert(vert_in vin) {
				vert_out vout;
				vout.pos = UnityObjectToClipPos(vin.vertex);
				vout.uv = vin.uv;
				vout.color = vin.color;

				// calculate particle waving
				float u = vin.uv.x + vin.uv.y * _SinTime.y * _PartAmp;
				float v = vin.uv.y + vin.uv.y * _SinTime.x * _CosTime.y * _SinTime.x * _PartAmp;
				vout.uv_part = TRANSFORM_TEX(float2(u, v), _PartTex);

				return vout;
			}

			float4 frag(vert_out vin) : COLOR{
				float4 col = tex2D(_MainTex, vin.uv);
				col.rgb *= _Color.rgb * vin.color.rgb * _Color.a;
				col.rgb *= vin.color.a;
				col.a = _Color.a * vin.color.a;
				col *= _Colorise;
				float4 part_col = tex2D(_PartTex, vin.uv_part);
				part_col.rgb *= vin.color.rgb * vin.color.a;

				return col + part_col * _PartBlend;
			}
			ENDCG
		}
	}
}