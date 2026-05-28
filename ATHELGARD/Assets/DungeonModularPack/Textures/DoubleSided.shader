Shader "Custom/DoubleSided"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }

    SubShader
    {
        Cull Off

        Tags { "RenderType"="Opaque" }

        Pass
        {
            SetTexture [_MainTex] { combine texture }
        }
    }
}