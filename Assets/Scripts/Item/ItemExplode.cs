using UnityEngine;
using System.Collections;

public class ItemExplode : MonoBehaviour 
{

    public float explosionForce = 100.0f;
    public float explosionRadius = 30.0f;
    public float time = 0.02f;
    public AudioClip explodeClip;

    private AudioSource itemAudio;
    private MeshFilter filter;
    private MeshRenderer meshRender;
    private Mesh meshRef;

    private Vector3[] verts;
    private Vector3[] normals;
    private Vector2[] uvs;
    private int[] indices;
    private Vector3[] newVerts = new Vector3[3];
    private Vector3[] newNormals = new Vector3[3];
    private Vector2[] newUvs = new Vector2[3];

    void Awake()
    {
        itemAudio = GetComponent<AudioSource>();
        filter = GetComponent<MeshFilter>();
        meshRender = GetComponent<MeshRenderer>();
        meshRef = filter.mesh;
        verts = meshRef.vertices;
        normals = meshRef.normals;
        uvs = meshRef.uv;
    }

    public void Destroy()
    {
        audio.clip = explodeClip;
        StartCoroutine("Desintegrate");
    }

    IEnumerator Desintegrate()
    {
        for (int submesh = 0; submesh < meshRef.subMeshCount; submesh++)
        {
            indices = meshRef.GetTriangles(submesh);

            for (int i = 0; i < indices.Length; i += 3)
            { 
                for (int n = 0; n < 3; n++)
                {
                    int index = indices[i + n];
                    newVerts[n] = verts[index];
                    newUvs[n] = uvs[index];
                    newNormals[n] = normals[index];
                }

                Mesh mesh = new Mesh();
                mesh.vertices = newVerts;
                mesh.normals = newNormals;
                mesh.uv = newUvs;
                mesh.triangles = new int[] { 0, 1, 2, 2, 1, 0 };

                GameObject go = new GameObject("Triangle " + (i / 3));
                go.transform.position = transform.position;
                go.transform.rotation = transform.rotation;
                go.AddComponent<MeshRenderer>().material = meshRender.materials[submesh];
                go.AddComponent<MeshFilter>().mesh = mesh;
                go.AddComponent<BoxCollider>();
                go.GetComponent<BoxCollider>().isTrigger = true;
                go.AddComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius);

                Destroy(go, 1 + Random.Range(0.0f, 1.0f));
            }
        }

        meshRender.enabled = false;
        yield return new WaitForSeconds(time);
        itemAudio.Play();
        Destroy(gameObject, itemAudio.clip.length);
    }
}
