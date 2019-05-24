// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-5991-OUT;n:type:ShaderForge.SFN_Tex2d,id:774,x:32163,y:32835,ptovrint:False,ptlb:node_774,ptin:_node_774,varname:node_774,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:03d96cde6cb696e4a9be0e2d1072c93b,ntxv:0,isnm:False|UVIN-9223-UVOUT;n:type:ShaderForge.SFN_Color,id:4255,x:32163,y:32660,ptovrint:False,ptlb:node_4255,ptin:_node_4255,varname:node_4255,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.8980393,c3:1,c4:1;n:type:ShaderForge.SFN_Rotator,id:9223,x:31950,y:32835,varname:node_9223,prsc:2|UVIN-4034-UVOUT,SPD-4050-OUT;n:type:ShaderForge.SFN_TexCoord,id:4034,x:31724,y:32835,varname:node_4034,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:3284,x:31563,y:32993,varname:node_3284,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4050,x:31724,y:33055,varname:node_4050,prsc:2|A-3284-TSL,B-4040-OUT;n:type:ShaderForge.SFN_Vector1,id:4040,x:31563,y:33121,varname:node_4040,prsc:2,v1:0.015;n:type:ShaderForge.SFN_Lerp,id:5991,x:32445,y:32816,varname:node_5991,prsc:2|A-3951-RGB,B-4255-RGB,T-774-RGB;n:type:ShaderForge.SFN_Color,id:3951,x:32163,y:32487,ptovrint:False,ptlb:node_4255_copy,ptin:_node_4255_copy,varname:_node_4255_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.1650627,c2:0.4856593,c3:0.5220588,c4:1;proporder:774-4255-3951;pass:END;sub:END;*/

Shader "Shader Forge/Swirlie" {
    Properties {
        _node_774 ("node_774", 2D) = "white" {}
        _node_4255 ("node_4255", Color) = (0,0.8980393,1,1)
        _node_4255_copy ("node_4255_copy", Color) = (0.1650627,0.4856593,0.5220588,1)
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
            #include "UnityCG.cginc"
            uniform sampler2D _node_774; uniform float4 _node_774_ST;
            uniform float4 _node_4255;
            uniform float4 _node_4255_copy;
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
                float4 node_4103 = _Time;
                float4 node_3284 = _Time;
                float node_9223_ang = node_4103.g;
                float node_9223_spd = (node_3284.r*0.015);
                float node_9223_cos = cos(node_9223_spd*node_9223_ang);
                float node_9223_sin = sin(node_9223_spd*node_9223_ang);
                float2 node_9223_piv = float2(0.5,0.5);
                float2 node_9223 = (mul(i.uv0-node_9223_piv,float2x2( node_9223_cos, -node_9223_sin, node_9223_sin, node_9223_cos))+node_9223_piv);
                float4 _node_774_var = tex2D(_node_774,TRANSFORM_TEX(node_9223, _node_774));
                float3 emissive = lerp(_node_4255_copy.rgb,_node_4255.rgb,_node_774_var.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
