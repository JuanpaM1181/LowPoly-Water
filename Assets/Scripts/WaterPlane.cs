using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlane : MonoBehaviour
{
    public float size = 1.0f;
    public int gridSize = 16;

    private MeshFilter filter;
    void Start()
    {
        filter = GetComponent<MeshFilter>();
        filter.mesh = GenerateMesh();
        
    }


    private Mesh GenerateMesh() 
    {
        Mesh mesh = new Mesh();

        var verts = new List<Vector3>(); //Stores vert x,y,z
        var normals = new List<Vector3>();
        var uvs = new List<Vector2>(); //Stores x,z

        for(int x = 0; x < gridSize + 1; x++) //Iterate on X 
        {
            for(int y = 0; y < gridSize + 1; y++) //Iterate on Y
            {
                verts.Add(new Vector3(-size * 0.5f + size * (x/((float)gridSize)), 0, -size * 0.5f + size * (y / ((float)gridSize))));
                normals.Add(Vector3.up);
                uvs.Add(new Vector2(x / (float)gridSize, y / (float)gridSize));
            }
        }

        //Triangles

        var triangles = new List<int>();
        var vertCount = gridSize + 1;

        for(int i = 0; i < vertCount * vertCount - vertCount; i++)
        {
            if((i + 1) % vertCount == 0)
            {
                continue;
            }
            triangles.AddRange(new List<int>()
            {
                i + 1 + vertCount, i + vertCount, i,
                i, i + 1, i + vertCount + 1
            });
        }

        mesh.SetVertices(verts);
        mesh.SetNormals(normals);
        mesh.SetUVs(0, uvs);
        mesh.SetTriangles(triangles, 0);
      
        return mesh;
    }

}
