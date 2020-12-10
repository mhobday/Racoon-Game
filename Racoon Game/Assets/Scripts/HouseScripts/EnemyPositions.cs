using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyPositions {
    
    public static Vector3 East21 = new Vector3(-92.62269f, 6.5f, 172.4388f);
    public static Vector3 South21 = new Vector3(-76.8931f, 6.5f, 132.6249f);
    public static Vector3 North21 = new Vector3(-94.71333f, 6.5f, 130.5865f);
    public static Vector3 West11 = new Vector3(-80.5144f, 0f, 129.6594f);
    public static Vector3 North11 = new Vector3(-94.71333f, 0f, 138.5858f);
    public static Vector3 North12 = new Vector3(-94.70668f, 0f, 161.7488f);
    public static Vector3 East11 = new Vector3(-85.895f, 0f, 172.3509f);
    public static Vector3 South11 = new Vector3(-61.97862f, 0f, 151.2376f);

    public static Vector3[] positions = new Vector3[]{East21, South21, North21, West11, North11, North12, East11, South11};
}
