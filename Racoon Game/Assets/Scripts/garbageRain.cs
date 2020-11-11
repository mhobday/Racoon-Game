using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbageRain : MonoBehaviour
{
    public Queue garbage = new Queue();
    public GameObject[] garbageOptions;
    public int garbageMax;
    public float garbageRate;
    private int garbageCount = 0;
    private float timeElapsed = 0.0f;

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > garbageRate) {
            garbage.Enqueue(
                Instantiate(
                    garbageOptions[(int) Mathf.Floor(Random.Range(0.0f, 0.999f) * garbageOptions.Length)],
                    this.gameObject.transform.position,
                    Random.rotation
                )
            );
            garbageCount++;
            timeElapsed = 0;
            if (garbageCount > garbageMax) {
                Destroy((GameObject) garbage.Dequeue());
            }
        }
    }
}
