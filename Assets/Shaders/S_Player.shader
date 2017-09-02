// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33510,y:32688,varname:node_3138,prsc:2|emission-1630-OUT;n:type:ShaderForge.SFN_Tex2d,id:1565,x:32483,y:32423,ptovrint:False,ptlb:Atlas,ptin:_Atlas,varname:node_1565,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9b288c7a8e228ae498658e5fbcb4cc89,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:6114,x:32262,y:32605,ptovrint:False,ptlb:Mask1,ptin:_Mask1,varname:node_6114,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:36e7d9d87f90fe444a90f8354a463143,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:2081,x:32593,y:33339,ptovrint:False,ptlb:Mask2,ptin:_Mask2,varname:node_2081,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:146841eb4f6b966448a511744dd333db,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:6638,x:32667,y:32227,ptovrint:False,ptlb:Player_Color,ptin:_Player_Color,varname:node_6638,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.3103448,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:4210,x:33011,y:32577,varname:node_4210,prsc:2|A-6638-RGB,B-6114-R;n:type:ShaderForge.SFN_Add,id:1630,x:33252,y:32690,varname:node_1630,prsc:2|A-2720-OUT,B-4210-OUT,C-9363-OUT,D-9200-OUT;n:type:ShaderForge.SFN_Subtract,id:4611,x:32716,y:32842,varname:node_4611,prsc:2|A-1565-RGB,B-6114-R;n:type:ShaderForge.SFN_Subtract,id:2720,x:32900,y:32854,varname:node_2720,prsc:2|A-4611-OUT,B-2081-R;n:type:ShaderForge.SFN_Multiply,id:9363,x:33194,y:33303,varname:node_9363,prsc:2|A-2081-R,B-6638-RGB,C-6779-OUT;n:type:ShaderForge.SFN_Time,id:5741,x:32337,y:33448,varname:node_5741,prsc:2;n:type:ShaderForge.SFN_Sin,id:5801,x:32673,y:33561,varname:node_5801,prsc:2|IN-5523-OUT;n:type:ShaderForge.SFN_Multiply,id:5523,x:32510,y:33585,varname:node_5523,prsc:2|A-5741-T,B-3942-OUT;n:type:ShaderForge.SFN_Slider,id:3942,x:32190,y:33708,ptovrint:False,ptlb:Speed,ptin:_Speed,varname:node_3942,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:20,max:100;n:type:ShaderForge.SFN_RemapRange,id:6334,x:32859,y:33530,varname:node_6334,prsc:2,frmn:-1,frmx:1,tomn:1,tomx:2|IN-5801-OUT;n:type:ShaderForge.SFN_Multiply,id:6779,x:33033,y:33515,varname:node_6779,prsc:2|A-6334-OUT,B-4549-OUT;n:type:ShaderForge.SFN_Slider,id:4549,x:32870,y:33760,ptovrint:False,ptlb:Strenght,ptin:_Strenght,varname:node_4549,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:5;n:type:ShaderForge.SFN_Tex2d,id:116,x:32685,y:33005,ptovrint:False,ptlb:Mask3,ptin:_Mask3,varname:node_116,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:47c9ae5ebef1f0b41b13c29ad4984218,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:9200,x:32934,y:33031,varname:node_9200,prsc:2|A-116-RGB,B-4670-OUT;n:type:ShaderForge.SFN_Slider,id:4670,x:32718,y:33177,ptovrint:False,ptlb:Light,ptin:_Light,varname:node_4670,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:5;proporder:1565-6114-6638-2081-3942-4549-116-4670;pass:END;sub:END;*/

Shader "Shader Forge/S_Player" {
    Properties {
        _Atlas ("Atlas", 2D) = "white" {}
        _Mask1 ("Mask1", 2D) = "white" {}
        _Player_Color ("Player_Color", Color) = (1,0.3103448,0,1)
        _Mask2 ("Mask2", 2D) = "white" {}
        _Speed ("Speed", Range(0, 100)) = 20
        _Strenght ("Strenght", Range(0, 5)) = 1
        _Mask3 ("Mask3", 2D) = "white" {}
        _Light ("Light", Range(0, 5)) = 1
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Atlas; uniform float4 _Atlas_ST;
            uniform sampler2D _Mask1; uniform float4 _Mask1_ST;
            uniform sampler2D _Mask2; uniform float4 _Mask2_ST;
            uniform float4 _Player_Color;
            uniform float _Speed;
            uniform float _Strenght;
            uniform sampler2D _Mask3; uniform float4 _Mask3_ST;
            uniform float _Light;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 _Atlas_var = tex2D(_Atlas,TRANSFORM_TEX(i.uv0, _Atlas));
                float4 _Mask1_var = tex2D(_Mask1,TRANSFORM_TEX(i.uv0, _Mask1));
                float4 _Mask2_var = tex2D(_Mask2,TRANSFORM_TEX(i.uv0, _Mask2));
                float4 node_5741 = _Time + _TimeEditor;
                float4 _Mask3_var = tex2D(_Mask3,TRANSFORM_TEX(i.uv0, _Mask3));
                float3 emissive = (((_Atlas_var.rgb-_Mask1_var.r)-_Mask2_var.r)+(_Player_Color.rgb*_Mask1_var.r)+(_Mask2_var.r*_Player_Color.rgb*((sin((node_5741.g*_Speed))*0.5+1.5)*_Strenght))+(_Mask3_var.rgb*_Light));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
