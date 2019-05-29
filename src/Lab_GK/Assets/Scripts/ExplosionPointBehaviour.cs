using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPointBehaviour : MonoBehaviour
{
    private float initTime;

    // Start is called before the first frame update
    void Start()
    {
        initTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - initTime > 3.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
