using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMove : MonoBehaviour
{
    public float power = 3.0f;
    public float scale = 1.0f;
    public float timeScale = 1.0f;

    private float offsetX;
    private float offsetY;
    private MeshFilter mf;

    void Start()
    {
        mf = GetComponent<MeshFilter>();
        MakeNoise();
    }


    void Update()
    {
        MakeNoise();

        offsetX += Time.deltaTime * timeScale;
        if(offsetY <= 0.1) 
        {
            offsetY += Time.deltaTime * timeScale;
        }
        if (offsetY >= power)
        {
            offsetY -= Time.deltaTime * timeScale;
        }
    }

    void MakeNoise() 
    {
        Vector3[] verticies = mf.mesh.vertices;

        for (int i = 0; i < verticies.Length; i++) 
        {
            verticies[i].y = CalculateHeight(verticies[i].x, verticies[i].z) * power;
        }

        mf.mesh.vertices = verticies;
    }

    float CalculateHeight(float x, float y)
    {
        float xCord = x * scale + offsetX;
        float yCord = y * scale + offsetY;

        return Mathf.PerlinNoise(xCord, yCord);
    }
}
