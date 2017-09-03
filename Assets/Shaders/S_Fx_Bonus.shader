// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33293,y:32714,varname:node_3138,prsc:2|emission-1901-OUT,clip-630-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32810,y:32487,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.03448272,c2:1,c3:0,c4:1;n:type:ShaderForge.SFN_TexCoord,id:9418,x:31230,y:32655,varname:node_9418,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_RemapRange,id:3046,x:31439,y:32653,varname:node_3046,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-9418-UVOUT;n:type:ShaderForge.SFN_Length,id:4301,x:31663,y:32660,varname:node_4301,prsc:2|IN-3046-OUT;n:type:ShaderForge.SFN_Floor,id:7654,x:32143,y:32841,varname:node_7654,prsc:2|IN-5920-OUT;n:type:ShaderForge.SFN_OneMinus,id:9387,x:32309,y:32846,varname:node_9387,prsc:2|IN-7654-OUT;n:type:ShaderForge.SFN_Add,id:5920,x:32000,y:32745,varname:node_5920,prsc:2|A-4301-OUT,B-452-OUT;n:type:ShaderForge.SFN_Add,id:3744,x:31999,y:33021,varname:node_3744,prsc:2|A-4301-OUT,B-452-OUT,C-7623-OUT;n:type:ShaderForge.SFN_Floor,id:4601,x:32164,y:33020,varname:node_4601,prsc:2|IN-3744-OUT;n:type:ShaderForge.SFN_Multiply,id:630,x:32518,y:32848,varname:node_630,prsc:2|A-9387-OUT,B-4601-OUT,C-6672-OUT;n:type:ShaderForge.SFN_Multiply,id:1901,x:32998,y:32665,varname:node_1901,prsc:2|A-7241-RGB,B-8986-OUT;n:type:ShaderForge.SFN_Slider,id:8986,x:32601,y:32700,ptovrint:False,ptlb:power,ptin:_power,varname:node_8986,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:3;n:type:ShaderForge.SFN_ValueProperty,id:7623,x:31777,y:33118,ptovrint:False,ptlb:inner,ptin:_inner,varname:node_7623,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.2;n:type:ShaderForge.SFN_Add,id:2637,x:32108,y:32443,varname:node_2637,prsc:2|A-4301-OUT,B-1280-OUT;n:type:ShaderForge.SFN_Slider,id:1280,x:31710,y:32467,ptovrint:False,ptlb:-0.5s,ptin:_05s,varname:node_1280,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0.09487263,max:1;n:type:ShaderForge.SFN_Floor,id:5730,x:32305,y:32452,varname:node_5730,prsc:2|IN-2637-OUT;n:type:ShaderForge.SFN_OneMinus,id:6672,x:32452,y:32435,varname:node_6672,prsc:2|IN-5730-OUT;n:type:ShaderForge.SFN_RemapRange,id:452,x:31654,y:32895,varname:node_452,prsc:2,frmn:0,frmx:1,tomn:1.1,tomx:-0.5|IN-5516-OUT;n:type:ShaderForge.SFN_Slider,id:5516,x:31209,y:32887,ptovrint:False,ptlb:lerp,ptin:_lerp,varname:node_5516,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;proporder:7241-8986-7623-1280-5516;pass:END;sub:END;*/

Shader "Shader Forge/S_Fx_Bonus" {
    Properties {
        _Color ("Color", Color) = (0.03448272,1,0,1)
        _power ("power", Range(0, 3)) = 2
        _inner ("inner", Float ) = 0.2
        _05s ("-0.5s", Range(-1, 1)) = 0.09487263
        _lerp ("lerp", Range(0, 1)) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
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
            uniform float4 _Color;
            uniform float _power;
            uniform float _inner;
            uniform float _05s;
            uniform float _lerp;
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
                float node_4301 = length((i.uv0*2.0+-1.0));
                float node_452 = (_lerp*-1.6+1.1);
                clip(((1.0 - floor((node_4301+node_452)))*floor((node_4301+node_452+_inner))*(1.0 - floor((node_4301+_05s)))) - 0.5);
////// Lighting:
////// Emissive:
                float3 emissive = (_Color.rgb*_power);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _inner;
            uniform float _05s;
            uniform float _lerp;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float node_4301 = length((i.uv0*2.0+-1.0));
                float node_452 = (_lerp*-1.6+1.1);
                clip(((1.0 - floor((node_4301+node_452)))*floor((node_4301+node_452+_inner))*(1.0 - floor((node_4301+_05s)))) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
