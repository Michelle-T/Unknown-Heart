using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class PlayerController : MonoBehaviour {

    public Interactable focus;

    public LayerMask enemyMask;

    public int health = 0;

    private int count = 0;

    Camera cam;

    public GameObject WinScreen;
    public GameObject LoseScreen;

    public GameObject[] lose;
    public GameObject[] win;

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

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log("We hit " + hit.collider.name + " " + hit.point);
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null)
                {
                    SetFocus(interactable);
                }
                else 
                {
                    //OnTriggerEnter(1);
                }
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Heart"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            Debug.Log("Hi!");
            WinScreen.SetActive(true);
            win = GameObject.FindGameObjectsWithTag("Win");
            hideWin();
        }
        
        else if(other.gameObject.CompareTag("Enemy"))
        {
            LoseScreen.SetActive(true);
        }
    }

    /*private void Winc()
    {
        if (count <= 1)
        {
            Debug.Log("Hi!");
            win = GameObject.FindGameObjectsWithTag("Win");
            hideWin();
            WinScreen.SetActive(true);
        }
    }*/

    public void showWin()
    {
        foreach (GameObject g in lose)
        {
            g.SetActive(true);
        }
        foreach (GameObject g in win)
        {
            g.SetActive(false);
        }
    }

    public void hideWin()
    {
        foreach (GameObject g in lose)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in win)
        {
            g.SetActive(true);
        }
    }

    void SetFocus(Interactable newFocus)
    {
        focus = newFocus;
        newFocus.OnFocused(transform);
    }
}
