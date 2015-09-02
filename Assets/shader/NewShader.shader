
Shader "Custom/NewShader" {
    Properties{
        _Color ("Main Color", Color) = (1,1,1,1)
        _MainTex ("Base (RGB) Trans. (Alpha)", 2D) = "white" { }
    }
 
    Category{
       
        ZWrite On
        Alphatest Greater 0.5
        Cull Off
        

        SubShader{
        Tags{"LightMode"="ForwardBase"}
            Pass
            {
//        CGPROGRAM
//        #pragma multi_compile_fwdbase
//        #include "UnityCG.cginc"、#include "AutoLight.cginc"
                Lighting On
//                LIGHTING_COORDS(idx1, idx2)
                SetTexture [_MainTex]
                {
                    constantColor [_Color]
                    Combine texture * constant, texture * constant
                }
            }
        }
    }
 }
