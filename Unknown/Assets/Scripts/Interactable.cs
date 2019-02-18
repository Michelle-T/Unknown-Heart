using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
