//Standard shader (no effects) taken from tutorial: https://community.monogame.net/t/writing-your-own-2d-pixel-shader-in-monogame-for-absolute-beginners/10883

#if OPENGL
#define SV_POSITION POSITION
#define VS_SHADERMODEL vs_3_0
#define PS_SHADERMODEL ps_3_0
#else
#define VS_SHADERMODEL vs_4_0_level_9_1
#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

Texture2D SpriteTexture;
float4 Pallet[32];

sampler2D SpriteTextureSampler = sampler_state
{
    Texture = <SpriteTexture>;
};

struct VertexShaderOutput
{
    float4 Position : SV_POSITION;
    float4 Color : COLOR0;
    float2 TextureCoordinates : TEXCOORD0;
};

float4 MainPS(VertexShaderOutput input) : COLOR
{
    float4 index = tex2D(SpriteTextureSampler, input.TextureCoordinates);
    float4 sampledColor = Pallet[index.r * 256] * input.Color;
    if (index.a == 0)
    {
        sampledColor = float4(0, 0, 0, 0);

    }
    return sampledColor;
}

technique SpriteDrawing
{
    pass P0
    {
        PixelShader = compile PS_SHADERMODEL MainPS();
    }
};