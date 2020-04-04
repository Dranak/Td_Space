using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSystem : MonoBehaviour
{

    public Image BuildingCursor;
    GameObject _objectToPlace;
    public float SpeedCursor;
    bool _drawCursor;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SelectCube();
        MoveCursor();
    }


    void SelectCube()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        ray.direction = Camera.main.transform.forward;
        Debug.DrawLine(ray.origin, Vector3.positiveInfinity, Color.red);
        Debug.Log(ray.origin + " --- " + ray.direction);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                TileData _groundTile = hit.transform.gameObject.GetComponent<TileData>();

                if (_groundTile != null)
                {
                    if (_groundTile.ObjetOn)
                        BuildingCursor.color = Color.red;
                    else
                    {
                        BuildingCursor.color = Color.green;
                        if (Input.GetMouseButton(0) && _objectToPlace)
                        {
                            _groundTile.ObjetOn = Instantiate(_objectToPlace, _groundTile.transform.position, Quaternion.identity, _groundTile.transform);
                            _drawCursor = false;
                            BuildingCursor.gameObject.SetActive(false);
                        }
                    }
                   ;
                }


            }
        }

    }


    void SelectCube2()
    {
        RaycastHit hit;
        
        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
                TileData _groundTile = hit.transform.gameObject.GetComponent<TileData>();

                if (_groundTile != null)
                {
                    if (_groundTile.ObjetOn)
                        BuildingCursor.color = Color.red;
                    else
                    {
                        BuildingCursor.color = Color.green;
                        if (Input.GetMouseButton(0) && _objectToPlace)
                        {
                            _groundTile.ObjetOn = Instantiate(_objectToPlace, _groundTile.transform.position, Quaternion.identity, _groundTile.transform);
                            _drawCursor = false;
                            BuildingCursor.gameObject.SetActive(false);
                        }
                    }
                   ;
                }


            }
        }

    }

    public void ChangeObjectToPlace(GameObject _obj)
    {
        _objectToPlace = _obj;
        _drawCursor = true;
        BuildingCursor.gameObject.SetActive(true);
    }

    void MoveCursor()
    {
        if (_drawCursor)
        {  
            Vector3 _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            BuildingCursor.transform.position =_mousePosition;
        }
    }
}
