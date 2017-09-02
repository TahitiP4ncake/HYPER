// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33174,y:32724,varname:node_3138,prsc:2|emission-8832-OUT,clip-4688-A;n:type:ShaderForge.SFN_Color,id:7241,x:32645,y:32523,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2284036,c2:0.9558824,c3:0.1686851,c4:1;n:type:ShaderForge.SFN_Tex2d,id:4688,x:32784,y:32895,ptovrint:False,ptlb:Arrow,ptin:_Arrow,varname:node_4688,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1a3b735a24a16c541a5d8a334ddad236,ntxv:0,isnm:False|UVIN-4517-UVOUT;n:type:ShaderForge.SFN_Panner,id:4517,x:32495,y:33035,varname:node_4517,prsc:2,spu:0,spv:-1|UVIN-3961-OUT,DIST-8630-OUT;n:type:ShaderForge.SFN_TexCoord,id:7028,x:31742,y:32816,varname:node_7028,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:8832,x:32890,y:32623,varname:node_8832,prsc:2|A-7241-RGB,B-5781-OUT;n:type:ShaderForge.SFN_Slider,id:5781,x:32483,y:32695,ptovrint:False,ptlb:power,ptin:_power,varname:node_5781,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:5;n:type:ShaderForge.SFN_Append,id:3961,x:32131,y:32883,varname:node_3961,prsc:2|A-7028-U,B-2987-OUT;n:type:ShaderForge.SFN_Multiply,id:2987,x:31936,y:32960,varname:node_2987,prsc:2|A-7028-V,B-1354-OUT;n:type:ShaderForge.SFN_Slider,id:1354,x:31657,y:33078,ptovrint:False,ptlb:U,ptin:_U,varname:node_1354,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:3,max:10;n:type:ShaderForge.SFN_Time,id:18,x:32055,y:33202,varname:node_18,prsc:2;n:type:ShaderForge.SFN_Multiply,id:8630,x:32260,y:33172,varname:node_8630,prsc:2|A-18-T,B-4541-OUT;n:type:ShaderForge.SFN_Slider,id:4541,x:32115,y:33399,ptovrint:False,ptlb:scrollSpeed,ptin:_scrollSpeed,varname:node_4541,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:8.034188,max:10;proporder:7241-4688-5781-1354-4541;pass:END;sub:END;*/

Shader "Shader Forge/S_Bonus" {
    Properties {
        _Color ("Color", Color) = (0.2284036,0.9558824,0.1686851,1)
        _Arrow ("Arrow", 2D) = "white" {}
        _power ("power", Range(0, 5)) = 2
        _U ("U", Range(0, 10)) = 3
        _scrollSpeed ("scrollSpeed", Range(0, 10)) = 8.034188
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
            uniform float4 _Color;
            uniform sampler2D _Arrow; uniform float4 _Arrow_ST;
            uniform float _power;
            uniform float _U;
            uniform float _scrollSpeed;
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
                float4 node_18 = _Time + _TimeEditor;
                float2 node_3961 = float2(i.uv0.r,(i.uv0.g*_U));
                float2 node_4517 = (node_3961+(node_18.g*_scrollSpeed)*float2(0,-1));
                float4 _Arrow_var = tex2D(_Arrow,TRANSFORM_TEX(node_4517, _Arrow));
                clip(_Arrow_var.a - 0.5);
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
            uniform float4 _TimeEditor;
            uniform sampler2D _Arrow; uniform float4 _Arrow_ST;
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
                float4 node_18 = _Time + _TimeEditor;
                float2 node_3961 = float2(i.uv0.r,(i.uv0.g*_U));
                float2 node_4517 = (node_3961+(node_18.g*_scrollSpeed)*float2(0,-1));
                float4 _Arrow_var = tex2D(_Arrow,TRANSFORM_TEX(node_4517, _Arrow));
                clip(_Arrow_var.a - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
