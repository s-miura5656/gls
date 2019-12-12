Shader "Toon/LitWithOutline" {
	Properties{
		_Color("Main Color", Color) = (0.5, 0.5, 0.5, 1)
		_MainTex("Base (RGB)", 2D) = "white" {}
		_Ramp("Toon Ramp (RGB)", 2D) = "gray" {}
	}

		SubShader{
			Tags { "RenderType" = "Opaque" }
			LOD 200

	CGPROGRAM
	#pragma surface surf ToonRamp

	sampler2D _Ramp;
	sampler2D _MainTex;
	half4     _Color;

	inline half4 LightingToonRamp(SurfaceOutput s, half3 lightDir, half3 viewDir, half atten)
	{
	   #ifndef USING_DIRECTIONAL_LIGHT
		lightDir = normalize(lightDir);
	   #endif

		half u = dot(s.Normal, lightDir) * 0.5 + 0.5;
		half v = dot(s.Normal, viewDir);
		half3 ramp = tex2D(_Ramp, half2(u, v)).rgb;

		half4 c;
		c.rgb = s.Albedo * _LightColor0.rgb * ramp;
		c.a = 0;
		return c;
	}

	struct Input {
		half2 uv_MainTex : TEXCOORD0;
	};

	void surf(Input IN, inout SurfaceOutput o) {
		half4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
		o.Albedo = c.rgb;
		o.Alpha = c.a;
	}
	ENDCG

	}

		Fallback "Diffuse"
}
