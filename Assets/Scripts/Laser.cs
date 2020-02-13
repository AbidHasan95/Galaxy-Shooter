using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    // Start is called before the first frame update
    private float _speed = 10f;
    void Start()
    {
        Debug.Log(name + _speed);

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.up * _speed* Time.deltaTime);
        if(transform.position.y>=5.36f)
        {
            Destroy(this.gameObject);
        }
    }
}
