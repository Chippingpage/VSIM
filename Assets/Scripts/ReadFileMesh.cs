using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadFileMesh : MonoBehaviour
{

    public static void ReadString()
    {
        string path = "Assets/Scripts/Read.txt";
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }


    public string filePath = "Assets/Scripts/Read.txt";

    void Start()
    {
        if (File.Exists(filePath)) {
           

            string[] lines = File.ReadAllLines(filePath);

            
            List<Vector3> vertices = new List<Vector3>();

            foreach (string line in lines)
            {

                string[] values = line.Split(' ');
                float x = float.Parse(values[0]);
                float y = float.Parse(values[1]);
                float z = float.Parse(values[2]);

                vertices.Add(new Vector3(x, y, z));
            }

            if (vertices.Count % 3 == 0)
            {
                Mesh mesh = new Mesh();
                mesh.vertices = vertices.ToArray();
                int[] triangles = new int[vertices.Count];

                for (int i = 0; i < vertices.Count; i++)
                {
                    triangles[i] = i;
                }

                mesh.triangles = triangles;

                GameObject meshObject = new GameObject("CustomMesh");
                MeshFilter meshFilter = meshObject.AddComponent<MeshFilter>();
                MeshRenderer meshRenderer = meshObject.AddComponent<MeshRenderer>();
                meshFilter.mesh = mesh;
               

                mesh.RecalculateNormals();
            }

        }
        else
            Debug.LogError("file not found" + filePath);
        }
    
}
