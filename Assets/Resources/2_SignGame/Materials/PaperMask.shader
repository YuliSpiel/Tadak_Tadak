Shader "Custom/PaperMask"
{
    Properties
    {
        _MainTex ("Sprite Texture", 2D) = "white" {}
    }
    
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        ColorMask 0
        ZWrite Off

        Stencil
        {
            Ref 1
            Comp always
            Pass replace
        }

        Pass {}
    }
}
