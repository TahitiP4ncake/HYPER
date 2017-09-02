// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33149,y:32720,varname:node_3138,prsc:2|emission-8366-OUT,clip-1753-A;n:type:ShaderForge.SFN_Tex2d,id:1753,x:32848,y:32959,ptovrint:False,ptlb:Cross,ptin:_Cross,varname:node_4688,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1a3b735a24a16c541a5d8a334ddad236,ntxv:0,isnm:False|UVIN-1051-UVOUT;n:type:ShaderForge.SFN_Panner,id:1051,x:32559,y:33099,varname:node_1051,prsc:2,spu:0,spv:-1|UVIN-5663-OUT,DIST-2751-OUT;n:type:ShaderForge.SFN_TexCoord,id:8840,x:31806,y:32880,varname:node_8840,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:8366,x:32954,y:32687,varname:node_8366,prsc:2|A-7211-RGB,B-3282-OUT,C-8585-OUT;n:type:ShaderForge.SFN_Append,id:5663,x:32195,y:32947,varname:node_5663,prsc:2|A-8840-U,B-8637-OUT;n:type:ShaderForge.SFN_Multiply,id:8637,x:32000,y:33024,varname:node_8637,prsc:2|A-8840-V,B-2631-OUT;n:type:ShaderForge.SFN_Slider,id:2631,x:31639,y:33135,ptovrint:False,ptlb:U,ptin:_U,varname:node_1354,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:3,max:10;n:type:ShaderForge.SFN_Time,id:4105,x:32119,y:33266,varname:node_4105,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2751,x:32324,y:33236,varname:node_2751,prsc:2|A-4105-T,B-7506-OUT;n:type:ShaderForge.SFN_Slider,id:7506,x:32179,y:33463,ptovrint:False,ptlb:scrollSpeed,ptin:_scrollSpeed,varname:node_4541,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Color,id:7211,x:32728,y:32567,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7211,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Slider,id:3282,x:32603,y:32796,ptovrint:False,ptlb:Power,ptin:_Power,varname:node_3282,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Time,id:2484,x:31777,y:32423,varname:node_2484,prsc:2;n:type:ShaderForge.SFN_Sin,id:5927,x:32214,y:32500,varname:node_5927,prsc:2|IN-1322-OUT;n:type:ShaderForge.SFN_Multiply,id:1322,x:32032,y:32542,varname:node_1322,prsc:2|A-2484-T,B-1716-OUT;n:type:ShaderForge.SFN_Slider,id:1716,x:31675,y:32641,ptovrint:False,ptlb:glowSpeed,ptin:_glowSpeed,varname:node_1716,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:5,max:10;n:type:ShaderForge.SFN_RemapRange,id:8585,x:32360,y:32471,varname:node_8585,prsc:2,frmn:-1,frmx:1,tomn:1,tomx:1.1|IN-5927-OUT;proporder:7211-3282-1753-2631-7506-1716;pass:END;sub:END;*/

Shader "Shader Forge/S_Malus" {
    Properties {
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        _Power ("Power", Range(0, 10)) = 0
        _Cross ("Cross", 2D) = "white" {}
        _U ("U", Range(0, 10)) = 3
        _scrollSpeed ("scrollSpeed", Range(0, 10)) = 0
        _glowSpeed ("glowSpeed", Range(0, 10)) = 5
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
            uniform float4 _TimeEditor;
            uniform sampler2D _Cross; uniform float4 _Cross_ST;
            uniform float _U;
            uniform float _scrollSpeed;
            uniform float4 _Color;
            uniform float _Power;
            uniform float _glowSpeed;
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
                float4 node_4105 = _Time + _TimeEditor;
                float2 node_1051 = (float2(i.uv0.r,(i.uv0.g*_U))+(node_4105.g*_scrollSpeed)*float2(0,-1));
                float4 _Cross_var = tex2D(_Cross,TRANSFORM_TEX(node_1051, _Cross));
                clip(_Cross_var.a - 0.5);
////// Lighting:
////// Emissive:
                float4 node_2484 = _Time + _TimeEditor;
                float3 emissive = (_Color.rgb*_Power*(sin((node_2484.g*_glowSpeed))*0.05000001+1.05));
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
            uniform float4 _TimeEditor;
            uniform sampler2D _Cross; uniform float4 _Cross_ST;
            uniform float _U;
            uniform float _scrollSpeed;
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
                float4 node_4105 = _Time + _TimeEditor;
                float2 node_1051 = (float2(i.uv0.r,(i.uv0.g*_U))+(node_4105.g*_scrollSpeed)*float2(0,-1));
                float4 _Cross_var = tex2D(_Cross,TRANSFORM_TEX(node_1051, _Cross));
                clip(_Cross_var.a - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
