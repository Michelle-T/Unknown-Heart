using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerHe : MonoBehaviour
{
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                //Debug.Log("We hit " + hit.collider.name + " " + hit.point);
                if (gameObject.CompareTag("Heart"))
                {
                    Debug.Log("HEART");
                    gameObject.SetActive(false);
                }
            }
        }
    }
}
