using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] Camera _camera;
    private Ray _ray;
    private RaycastHit _hit;
    [SerializeField] float _distance;
    [SerializeField] Transform arm;
    GameObject selected;


    private void Ray() {
        _ray = _camera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
    }
    private void Hit()
    {
        if (Physics.Raycast(_ray, out _hit, 100)) {
            Debug.DrawRay(_ray.origin, _ray.direction * _distance, Color.red);
            if (_hit.collider.gameObject.tag == "Pick" && Input.GetKey(KeyCode.E)) {
                if (selected == null)
                {
                    selected = _hit.collider.gameObject;
                    selected.transform.position = arm.transform.position;
                    selected.transform.rotation = arm.transform.rotation;
                    selected.GetComponent<Collider>().enabled = false;
                    selected.transform.SetParent(arm);
                    selected.GetComponent<Rigidbody>().isKinematic = true;
                    
                }
                else {
                    print("LOX");
                    selected.transform.GetComponent<Rigidbody>().isKinematic = false;
                    selected.transform.GetComponent<Rigidbody>().AddForce(Vector3.left * 100);
                    selected.GetComponent<Collider>().enabled = true;
                    selected = null;

                    selected = _hit.collider.gameObject;
                    selected.transform.position = arm.transform.position;
                    selected.transform.rotation = arm.transform.rotation;
                    selected.transform.SetParent(arm);
                    selected.GetComponent<Rigidbody>().isKinematic = true;
                    selected.GetComponent<Collider>().enabled = false;
                }
            }
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
