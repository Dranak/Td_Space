using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject PointNorth;
    public GameObject PointEst;
    public GameObject PointSouth;
    public GameObject PointWest;

    public Dictionary<string, Cube> Neighboors { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Neighboors.Add("North", RaycastCube(PointNorth));
        Neighboors.Add("Est", RaycastCube(PointEst));
        Neighboors.Add("South", RaycastCube(PointSouth));
        Neighboors.Add("West", RaycastCube(PointWest));
    }

    // Update is called once per frame
    void Update()
    {

    }


    Cube RaycastCube(GameObject _start)
    {
        RaycastHit _hit;

        Physics.Raycast(_start.transform.position, Vector3.forward, out _hit, 1f);
        if (_hit.collider != null)
        {
            return _hit.collider.gameObject.GetComponent<Cube>();
        }
        else
            return null;
    }


   public void ShowNeighboors()
    {
       foreach(var item in Neighboors)
        {
            if(item.Value != null)
            {
                item.Value.gameObject.GetComponent<Material>().color = Color.red;
            }
          
        }

    }




}
