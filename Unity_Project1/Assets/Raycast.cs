using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] Camera _camera;
    private Ray _ray;
    private RaycastHit _hit;
    [SerializeField] float _distance;

    private void Ray() {
        _ray = _camera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
    }
    private void Hit()
    {
        //if (Physics.Raycast(_ray.origin,  _hit, _distance))
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray();
        Hit();
    }
}
