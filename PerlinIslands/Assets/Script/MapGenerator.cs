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
    int _mapWidth = 100;
    int _mapHeight = 100;
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
        float[,] noiseMap = Noise.GenerateMap(_mapHeight, _mapWidth, seed, noiseScale, octaves, persistance, lacunarity, offest);

        Color[] colorMap = new Color[_mapWidth * _mapHeight];
        for (int y = 0; y < _mapHeight; y++)
        {
            for (int x = 0; x < _mapWidth; x++)
            {
                float curHeight = noiseMap[x, y];

                foreach (var item in regions)
                {
                    if (curHeight <= item.height)
                    {
                        colorMap[y * _mapWidth + x] = item.color;
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
            mapDisplay.DrawTexture(TextureGenerator.TextureFromColorMap(colorMap, _mapWidth, _mapHeight));
        }
    }

    private void OnValidate()
    {
        _mapWidth = _mapWidth < 1 ? 1 : _mapWidth;
        _mapHeight = _mapHeight < 1 ? 1 : _mapHeight;
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