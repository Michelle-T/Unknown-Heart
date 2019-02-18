using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Interactable focus;

    public LayerMask enemyMask;

    Camera cam;

	// Use this for initialization
	void Start ()
    {
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, enemyMask))
            {
                Debug.Log("We hit " + hit.collider.name + " " + hit.point);
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
	}
    
    void SetFocus(Interactable newFocus)
    {
        focus = newFocus;
        newFocus.OnFocused(transform);
    }
}
