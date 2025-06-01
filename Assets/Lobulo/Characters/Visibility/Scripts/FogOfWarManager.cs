using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class FogOfWarManager : MonoBehaviour
{
    public static FogOfWarManager Instance;

    [Header("Referencias")]
    public FogSettings settings;
    public RawImage fogImageUI;

    private RenderTexture fogTexture;
    private Material drawMaterial;

    public Vector3 offSet;

    public struct UnitInfo
    {
        public Vector3 position;
        public float radius;
    }

    private List<UnitInfo> units = new List<UnitInfo>();

    void Awake()
    {
        Instance = this;

        fogTexture = new RenderTexture(settings.textureSize, settings.textureSize, 0, RenderTextureFormat.ARGB32);
        fogTexture.Create();

        Shader.SetGlobalTexture("_FogTex", fogTexture);

        if (fogImageUI != null)
            fogImageUI.texture = fogTexture;

        drawMaterial = new Material(Shader.Find("Hidden/FogDraw"));
    }

    void Update()
    {
        DrawFogTexture();
    }

    public int RegisterUnit(UnitInfo unit)
    {
        units.Add(unit);
        return units.Count - 1;
    }

    public void UpdateUnitPosition(int index, Vector3 position)
    {
        if (index >= 0 && index < units.Count)
        {
            var u = units[index];
            u.position = position + offSet;
            units[index] = u;
        }
    }

    void DrawFogTexture()
    {
        RenderTexture.active = fogTexture;
        GL.Clear(true, true, new Color(0f, 0f, 0f, 0.85f));

        GL.PushMatrix();
        GL.LoadPixelMatrix(0, settings.textureSize, settings.textureSize, 0);

        drawMaterial.SetPass(0);

        foreach (var unit in units)
        {
            Vector2 uv = WorldToUV(unit.position);
            float radiusUV_X = unit.radius / settings.worldSize.x * settings.textureSize;
            float radiusUV_Y = unit.radius / settings.worldSize.y * settings.textureSize;

            float aspect = (float)Screen.width / Screen.height;

            float adjustedRadiusX = radiusUV_X;
            float adjustedRadiusY = radiusUV_Y;

            if (aspect > 1f)
                adjustedRadiusX /= aspect;
            else
                adjustedRadiusY *= aspect;

            Graphics.DrawTexture(
                new Rect(
                    uv.x * settings.textureSize - radiusUV_X,
                    uv.y * settings.textureSize - radiusUV_Y,
                    radiusUV_X * 2,
                    radiusUV_Y * 2
                ),
                Texture2D.whiteTexture,
                drawMaterial
            );
        }

        GL.PopMatrix();
        RenderTexture.active = null;
    }

    Vector2 WorldToUV(Vector3 worldPos)
    {
        float x = (worldPos.x - settings.worldCenter.x + settings.worldSize.x * 0.5f) / settings.worldSize.x;
        float y = (worldPos.z - settings.worldCenter.z + settings.worldSize.y * 0.5f) / settings.worldSize.y;

        return new Vector2(Mathf.Clamp01(x), Mathf.Clamp01(1f - y));
    }


}
