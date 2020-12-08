using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyPositions {
    public static Vector3 East21 = new Vector3(-86.45428f, 7.3f, 160.3046f);
    public static Vector3 South21 = new Vector3(-70.79049f, 7.3f, 121.2165f);
    public static Vector3 North21 = new Vector3(-89.20461f, 7.3f, 117.6416f);
    public static Vector3 West11 = new Vector3(-74.16982f, .75f, 116.6589f);
    public static Vector3 North11 = new Vector3(-89.10271f, .75f, 125.3998f);
    public static Vector3 North12 = new Vector3(-89.41917f, .75f, 149.119f);
    public static Vector3 East11 = new Vector3(-79.32796f, .75f, 160.3064f);
    public static Vector3 South11 = new Vector3(-55.50831f, .75f, 139.4101f);

    public static Vector3[] positions = new Vector3[]{East21, South21, North21, West11, North11, North12, East11, South11};
}
