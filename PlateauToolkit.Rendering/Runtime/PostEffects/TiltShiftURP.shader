Shader "Hidden/TiltShiftURP" {
    SubShader {
        Tags {"RenderType"="Opaque" }
        Pass {
            HLSLPROGRAM
            #pragma shader_feature __ UNITY_PIPELINE_URP
            #if UNITY_PIPELINE_URP
                #pragma vertex vert 
                #pragma fragment frag
                #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
                #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/DeclareDepthTexture.hlsl"
                TEXTURE2D_X(_blurBuffer); 
                SAMPLER(sampler_blurBuffer);
                float _BlurSize;
                uint _Samples;
                float _BlurStartRange;
                
                static const float2 POISSON_DISKS[128] =
                {
                    float2(-0.2367787, 0.4901892),
                    float2(-0.3067145, 0.6599227),
                    float2(-0.1616595, 0.7254592),
                    float2(-0.4227801, 0.3229555),
                    float2(-0.4746405, 0.4624885),
                    float2(-0.02666831, 0.4906617),
                    float2(-0.1461937, 0.3522153),
                    float2(-0.2836505, 0.3249041),
                    float2(-0.03740598, 0.6329193),
                    float2(-0.1292047, 0.1889183),
                    float2(0.06661285, 0.3683913),
                    float2(-0.2859527, 0.1483711),
                    float2(0.01433537, 0.2475814),
                    float2(-0.01132843, 0.7631852),
                    float2(-0.2184855, 0.8846649),
                    float2(-0.3903657, 0.7600643),
                    float2(-0.07552132, 0.9133397),
                    float2(0.1710439, 0.7008814),
                    float2(0.1391777, 0.5709726),
                    float2(0.07363454, 0.8635173),
                    float2(-0.4941275, 0.1842116),
                    float2(-0.5412169, 0.6853794),
                    float2(-0.425546, 0.5922924),
                    float2(-0.6466808, 0.03978668),
                    float2(-0.6634844, 0.2321819),
                    float2(-0.4938175, -0.001419672),
                    float2(-0.3278933, -0.01152995),
                    float2(-0.7977815, 0.2398731),
                    float2(-0.8286724, 0.3857125),
                    float2(-0.7988419, 0.05790134),
                    float2(-0.6623837, 0.3731333),
                    float2(0.08254691, 0.09132266),
                    float2(0.1745314, 0.2063142),
                    float2(-0.0703319, 0.01107812),
                    float2(0.2536064, 0.3460345),
                    float2(-0.6207574, 0.5073496),
                    float2(-0.7248882, 0.5964983),
                    float2(-0.6806865, 0.72211),
                    float2(0.3832989, 0.5220767),
                    float2(0.3028488, 0.6359207),
                    float2(-0.6465305, -0.1068089),
                    float2(-0.4692663, -0.2492552),
                    float2(-0.3643594, -0.1591648),
                    float2(0.4516504, 0.6501877),
                    float2(0.5113109, 0.4880795),
                    float2(0.5895482, 0.6321136),
                    float2(0.5106937, 0.3271424),
                    float2(0.6451618, 0.3510359),
                    float2(0.6413455, 0.4992366),
                    float2(0.3909793, 0.3858602),
                    float2(0.283926, 0.8730315),
                    float2(0.476542, 0.7805386),
                    float2(0.727109, 0.6244066),
                    float2(0.6144412, 0.181504),
                    float2(0.4096124, 0.1739766),
                    float2(0.278091, -0.02838729),
                    float2(0.2909363, 0.1169052),
                    float2(-0.3609014, -0.3968496),
                    float2(-0.5727078, -0.3509097),
                    float2(-0.2417752, -0.2238419),
                    float2(-0.5011169, -0.5000672),
                    float2(0.8973918, 0.3360424),
                    float2(0.752505, 0.2383271),
                    float2(0.6567625, 0.7472429),
                    float2(-0.9467769, 0.2731125),
                    float2(-0.9252222, 0.09196262),
                    float2(-0.4713456, 0.8770475),
                    float2(-0.3161662, -0.5501466),
                    float2(-0.5205767, -0.7258629),
                    float2(-0.6948451, -0.4750859),
                    float2(-0.3531139, -0.6912672),
                    float2(-0.6919448, -0.6388381),
                    float2(0.7677299, 0.4491784),
                    float2(-0.458206, -0.872004),
                    float2(-0.3055792, -0.850623),
                    float2(-0.8475943, 0.5245672),
                    float2(0.9406309, 0.1386568),
                    float2(0.7253717, 0.08629423),
                    float2(-0.9118658, -0.07326309),
                    float2(-0.202966, -0.7705109),
                    float2(-0.1247103, -0.5884792),
                    float2(-0.1998137, -0.08350364),
                    float2(-0.2088391, -0.4162863),
                    float2(-0.8804737, -0.1069524),
                    float2(-0.0820531, -0.3091766),
                    float2(-0.7659051, -0.1831385),
                    float2(-0.7991378, -0.3809945),
                    float2(-0.1684138, -0.9658166),
                    float2(-0.03333611, -0.8163373),
                    float2(-0.6914942, -0.2980516),
                    float2(-0.8284369, -0.5358804),
                    float2(0.2550101, 0.4957033),
                    float2(0.5583357, -0.04477769),
                    float2(0.4610983, 0.05115379),
                    float2(-0.02488372, -0.9829083),
                    float2(0.1322045, -0.09329918),
                    float2(-0.9220811, -0.2793948),
                    float2(0.8650895, 0.02036999),
                    float2(0.124429, -0.2666473),
                    float2(0.2596441, -0.2372703),
                    float2(0.7572334, -0.1326314),
                    float2(0.5060279, -0.180913),
                    float2(0.6361921, -0.2048395),
                    float2(0.8838742, -0.1960855),
                    float2(0.7770295, -0.3713599),
                    float2(0.4667997, -0.3812411),
                    float2(0.5975081, -0.3628165),
                    float2(-0.05966386, -0.4422135),
                    float2(0.09921371, -0.4335754),
                    float2(0.02576026, -0.6545462),
                    float2(0.1637208, -0.8230984),
                    float2(0.3726746, -0.1253497),
                    float2(0.1559616, -0.9565104),
                    float2(0.9600466, -0.07366105),
                    float2(0.2623834, -0.414741),
                    float2(0.1862826, -0.6195262),
                    float2(0.1383334, 0.9898438),
                    float2(0.4451495, -0.5591879),
                    float2(0.3375484, -0.6613742),
                    float2(0.3923327, -0.2581888),
                    float2(0.3842012, -0.8586627),
                    float2(0.5498597, -0.7814276),
                    float2(0.5922456, -0.6579062),
                    float2(0.923216, -0.3776534),
                    float2(0.7154181, -0.5230829),
                    float2(0.5640847, -0.4905176),
                    float2(0.7366304, -0.671463),
                    float2(0.8643044, -0.4947536)
                };

                struct appdata_t 
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                    float4 screenPos : TEXCOORD2;
                };
                
                struct v2f 
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                    float4 screenPos : TEXCOORD2;
                };

                v2f vert (appdata_t v) {
                    v2f o;
                    UNITY_SETUP_INSTANCE_ID(input);
                    UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);
                    VertexPositionInputs vertexInput = GetVertexPositionInputs(v.vertex.xyz);
                    o.vertex = vertexInput.positionCS;
                    o.screenPos = ComputeScreenPos(o.vertex);
                    o.uv = v.uv;

                    return o;
                }
                
                float4 frag (v2f i) : SV_Target {
                    float4 sum = float4(0, 0, 0, 0);
                    float screenSizeRatio = _ScreenSize.x / _ScreenSize.y;
                    float nv = saturate(distance(i.uv.y, 0.5)); 
                    float fade = saturate(smoothstep(_BlurStartRange, 1.0, nv));
                    fade *= screenSizeRatio;

                    float4 col = SAMPLE_TEXTURE2D(_blurBuffer, sampler_blurBuffer, i.uv);

                    for (int j = 0; j < _Samples; j++) {
                        uint t = j * (128 / _Samples);
                        if(t >= 128) 
                        t -= 128;

                        float2 uv = i.uv;
                        float2 offset = POISSON_DISKS[t] * fade * 0.01;
                        uv += offset * _BlurSize;

                        // Skip unnecessary samplings
                        if(fade > 0.01)
                        {
                            sum += SAMPLE_TEXTURE2D(_blurBuffer, sampler_blurBuffer, uv);
                        }
                        else 
                        {
                            sum += col;
                        }
                    }

                    sum /= _Samples;
                    return sum;
                }
            #else
                struct appdata_t { };
                struct v2f { };

                v2f vert (appdata_t v)
                {
                    v2f o;
                    return o;
                }

                float4 frag (v2f i) : SV_Target
                {
                    return float4(1.0, 0.0, 0.0, 1.0); // Returns red color
                }
            #endif
            ENDHLSL
        }
    }
    FallBack "Diffuse"
}
