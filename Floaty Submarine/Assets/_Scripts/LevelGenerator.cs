using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public float terrainScale = 5f;
    public float terrainHeight = 10f;
    public float valleyWidth = 20f;
    public float valleyDepth = 5f;
    public Transform playerTransform;
    public GameObject terrainPrefab;

    private List<GameObject> terrainChunks = new List<GameObject>();
    private float lastTerrainX = 0f;

    private void Start()
    {
        GenerateInitialTerrain();
    }

    private void Update()
    {
        if (playerTransform.position.x > lastTerrainX - valleyWidth)
        {
            GenerateTerrain();
        }
    }

    private void GenerateInitialTerrain()
    {
        for (int i = 0; i < 5; i++)
        {
            float x = i * 100f;
            GenerateTerrainChunk(x);
            lastTerrainX = x;
        }
    }

    private void GenerateTerrain()
    {
        float x = lastTerrainX + 100f;
        GenerateTerrainChunk(x);
        lastTerrainX = x;
    }

    private void GenerateTerrainChunk(float x)
    {
        GameObject terrainObject = Instantiate(terrainPrefab, transform);
        terrainObject.transform.position = new Vector3(x, 0f, 0f);

        Terrain terrain = terrainObject.GetComponent<Terrain>();
        TerrainData terrainData = terrain.terrainData;

        float[,] heightMap = new float[terrainData.heightmapResolution, terrainData.heightmapResolution];

        for (int i = 0; i < terrainData.heightmapResolution; i++)
        {
            for (int j = 0; j < terrainData.heightmapResolution; j++)
            {
                float xCoord = (float)i / (float)terrainData.heightmapResolution * terrainScale + x;
                float zCoord = (float)j / (float)terrainData.heightmapResolution * terrainScale;
                float height = Mathf.PerlinNoise(xCoord, zCoord) * terrainHeight;

                if (x + valleyWidth > playerTransform.position.x && x - valleyWidth < playerTransform.position.x)
                {
                    float valleyHeight = (Mathf.Abs(x - playerTransform.position.x) / valleyWidth) * valleyDepth;
                    height -= valleyHeight;
                }

                heightMap[i, j] = height;
            }
        }

        terrainData.SetHeights(0, 0, heightMap);
        terrainChunks.Add(terrainObject);
    }
}
