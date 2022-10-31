Shader "Graph/Point Surface"
{
    Properties
    {
        _Smoothness ("Smoothness", Range(0,1)) = 0.5
    }
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows
        #pragma target 3.0

        struct Input
        {
            float3 worldPos;
        };

        float _Smoothness;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            o.Albedo.rg = IN.worldPos.xy * 0.5 + 0.5;
            o.Smoothness = _Smoothness;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
