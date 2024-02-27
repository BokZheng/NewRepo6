    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class pewpew : MonoBehaviour
{
    public GameObject Bullets;
    public float SpawnIntervals = 1f;
    private float _timer = 0f;
    public Transform Target;

    // Start is called before the first frame update
    void Start()
    {
        _timer = SpawnIntervals;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer > 0f)
        {
            _timer -= Time.deltaTime;
            return;
        }
        Vector2 targetdirection = Target.position - transform.position;
        targetdirection = targetdirection.normalized;

       
    }
}
