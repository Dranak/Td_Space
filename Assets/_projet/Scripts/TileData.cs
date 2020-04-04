using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData : MonoBehaviour
{
    public float Size = 1f;
    public GameObject ObjetOn { get; set; } = null;
    public Collider Collider { get; set; } 

    // Start is called before the first frame update
    void Awake()
    {
        Collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
