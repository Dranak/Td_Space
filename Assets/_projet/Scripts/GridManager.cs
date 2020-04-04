using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Collider Area;
    public TileData Tile;
    BoxCollider _boxTile;
    List<TileData> _grid = new List<TileData>();
    // Start is called before the first frame update
    void Start()
    {
        _boxTile = Tile.GetComponent<BoxCollider>();
        for (int x = (int)Area.bounds.min.x; x<Area.bounds.max.x;++x)
        {
            for (int z = (int)Area.bounds.min.z; z < Area.bounds.max.z; ++z)
            {
                _grid.Add(Instantiate(Tile, new Vector3(x+ (_boxTile.size.x/2), 0, z + (_boxTile.size.z / 2)), Quaternion.identity, this.transform));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     TileData SelectRandomTile()
    {
        float x = UnityEngine.Random.Range(Area.bounds.min.x, Area.bounds.max.x);
        float z = UnityEngine.Random.Range(Area.bounds.min.z, Area.bounds.max.z);
       return _grid.Where(td => td.Collider.bounds.Contains(new Vector3(x, 0, z))).FirstOrDefault();
    }



   
}
