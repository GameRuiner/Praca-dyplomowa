using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintable : MonoBehaviour
{
    public GameObject Brush;
    public float BrushSize = 0.1f;

    public GameManager GameManager;

    // GameObject plane;

    // Start is called before the first frame update
    void Start()
    {
        //   plane = GameObject.Find("Plane");
          //Debug.Log(plane.GetComponent<Transform>());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(Ray, out hit ) && hit.transform.gameObject.name == "Plane" && GameManager.inMenu != true) {
                var go = Instantiate(Brush, hit.point + Vector3.up * 10, Quaternion.identity, transform);
                go.transform.localScale = Vector3.one * BrushSize;
                go = Instantiate(Brush, hit.point + Vector3.up * 1, Quaternion.identity, transform);
                go.transform.localScale = Vector3.one * BrushSize;
            }
        }
        
    }
}
