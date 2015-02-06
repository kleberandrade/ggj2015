// Character shader with alpha

Shader "Wetiasami/Character" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_SpecColor ("Specular Color", Color) = (1,1,1,1)
	_MainTex ("Base (RGBA)", 2D) = "white" {}
	_BumpMap ("Normalmap", 2D) = "bump" {} 
	_Specular ("Specular", 2D) = "white" {}
	_Specular_Amount ("Specular Amount",Range(0.0,2.0)) = 1.0
	_Gloss_Amount("Gloss Amount",Range(0.0,2.0)) = 1.0
	
	_RimColor ("Rim Color", Color) = (0.2, 0.2, 0.2, 0.0)
	_RimPower ("Rim Power", Range(0.5, 8.0)) = 2.5
		
}

CGINCLUDE

	sampler2D _MainTex;
	sampler2D _BumpMap;
	sampler2D _Specular;
	float4 _RimColor;
	float _RimPower;

	half _Specular_Amount;
	half _Gloss_Amount;

	float4 _Color;
	
	half4 LightingSimpleBlinnPhong (SurfaceOutput s, half3 lightDir, half3 viewDir, half atten) {
	    half3 h = normalize (lightDir + viewDir);
	    half diff = saturate(dot (s.Normal, lightDir));

	    float nh = max (0, dot (s.Normal, h));
	    float spec = pow (nh, s.Gloss * 128.0) * s.Specular;

	    half4 c;
	    c.rgb = (s.Albedo * _LightColor0.rgb * diff + _LightColor0.rgb * spec) * (atten * 2);
	    c.a = s.Alpha;
	    return c;
	  }

	struct Input {
		float2 uv_MainTex;
		float2 uv_BumpMap;
		float3 viewDir;
	};

	void surf (Input IN, inout SurfaceOutput o) {
		half4 tex = tex2D(_MainTex, IN.uv_MainTex);
		half4 spec = tex2D(_Specular,IN.uv_MainTex);
		
		o.Albedo = tex.rgb * _Color.rgb;
		o.Alpha = tex.a;
		o.Gloss = (spec.r + spec.g + spec.b) / 3.0 * _Gloss_Amount;
		o.Specular = (spec.r + spec.g + spec.b) / 3.0 * _Specular_Amount;
		o.Normal = UnpackNormal(tex2D (_BumpMap, IN.uv_BumpMap));
		half rim = 1.0 - saturate(dot (normalize(IN.viewDir).xyz, o.Normal));
		o.Emission = _RimColor.rgb * pow (rim, _RimPower);
	}
ENDCG


SubShader { 
	Tags { "RenderType" = "Opaque"}
	LOD 400
	
	ZWrite On
	ZTest LEqual
	Cull Off
	AlphaTest Equal 1
	Blend SrcAlpha OneMinusSrcAlpha
	ColorMask RGBA
	
CGPROGRAM
#pragma surface surf BlinnPhong



ENDCG
}

FallBack "Diffuse"
}
