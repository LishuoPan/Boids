using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public enum GizmoType { Never, SelectedOnly, Always }

    public Boid prefab;
    public float spawnRadius = 10;
    public int spawnCount = 10;
    public Color colour;
    public GizmoType showSpawnRegion;

    void Awake () {
        using (System.IO.StreamReader sr = new System.IO.StreamReader(@"C:\Users\pls19\Boids\3D_swarm_trajs.txt"))
        {
            string line;
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 pos = new Vector3(0,0,0);
                Vector3 ori = new Vector3(0,0,0);
                for (int j=0; j<6; j++)
                {
                    if (j==0) {
                        line = sr.ReadLine();
                        pos.x = float.Parse(line);
                    }
                    if (j == 1)
                    {
                        line = sr.ReadLine();
                        pos.y = float.Parse(line);
                    }
                    if (j == 2)
                    {
                        line = sr.ReadLine();
                        pos.z = float.Parse(line);
                    }
                    if (j == 3)
                    {
                        line = sr.ReadLine();
                        ori.x = float.Parse(line);
                    }
                    if (j == 4)
                    {
                        line = sr.ReadLine();
                        ori.y = float.Parse(line);
                    }
                    if (j == 5)
                    {
                        line = sr.ReadLine();
                        ori.z = float.Parse(line);
                    }

                    //line = sr.ReadLine();
                    //Debug.Log("read " + line);
                    //Debug.Log(line.GetType());
                }
                //line = sr.ReadLine();
                //Debug.Log("read " + line);
                Boid boid = Instantiate(prefab);
                boid.transform.position = pos;
                //boid.transform.forward = ori;




                // Original code
                //Vector3 pos = transform.position + Random.insideUnitSphere * spawnRadius;
                //Boid boid = Instantiate(prefab);
                //boid.transform.position = pos;
                boid.transform.forward = Random.insideUnitSphere;
                // Original code

                boid.SetColour(colour);
            }
        }
    }

    private void OnDrawGizmos () {
        if (showSpawnRegion == GizmoType.Always) {
            DrawGizmos ();
        }
    }

    void OnDrawGizmosSelected () {
        if (showSpawnRegion == GizmoType.SelectedOnly) {
            DrawGizmos ();
        }
    }

    void DrawGizmos () {

        Gizmos.color = new Color (colour.r, colour.g, colour.b, 0.3f);
        Gizmos.DrawSphere (transform.position, spawnRadius);
    }

}