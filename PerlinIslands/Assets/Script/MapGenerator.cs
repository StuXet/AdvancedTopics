using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public enum DrawMode
    {
        Noise,
        Islands
    }
    public DrawMode drawMode = DrawMode.Noise;
    public int mapWidth;
    public int mapHeight;
    public float noiseScale;
    public int octaves;
    [Range(0, 1)]
    public float persistance;
    public float lacunarity;
    public int seed;
    public Vector2 offest;
    public bool autoUpdate;
    public TerrainType[] regions;


    [SerializeField] private MapDisplay mapDisplay;

    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateMap(mapHeight, mapWidth, seed, noiseScale, octaves, persistance, lacunarity, offest);

        Color[] colorMap = new Color[mapWidth * mapHeight];
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float curHeight = noiseMap[x, y];

                foreach (var item in regions)
                {
                    if (curHeight <= item.height)
                    {
                        colorMap[y * mapWidth + x] = item.color;
                        break;
                    }

                }
            }
        }
        if (drawMode == DrawMode.Noise)
        {
            mapDisplay.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));
        }
        else if (drawMode == DrawMode.Islands)
        {
            mapDisplay.DrawTexture(TextureGenerator.TextureFromColorMap(colorMap, mapWidth, mapHeight));
        }
    }

    private void OnValidate()
    {
        mapWidth = mapWidth < 1 ? 1 : mapWidth;
        mapHeight = mapHeight < 1 ? 1 : mapHeight;
        lacunarity = lacunarity < 1 ? 1 : lacunarity;
        octaves = octaves < 0 ? 0 : octaves;
    }
}

[System.Serializable]
public struct TerrainType
{
    public string name;
    public float height;
    public Color color;
}