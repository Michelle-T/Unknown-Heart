using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    /*public float distance;*/
    public Transform player;
    public float maxAngle;
    public float maxRadius;

    private bool isInFov = false;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxRadius);

        Vector3 fovLine1 = Quaternion.AngleAxis(maxAngle, transform.up) * transform.forward * maxRadius;
        Vector3 fovLine2 = Quaternion.AngleAxis(-maxAngle, transform.up) * transform.forward * maxRadius;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, fovLine1);
        Gizmos.DrawRay(transform.position, fovLine2);

        if (!isInFov)
            Gizmos.color = Color.red;
        else
            Gizmos.color = Color.green;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, (player.position - transform.position).normalized * maxRadius) ;

        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.forward * maxRadius);
    }

    public static bool inFOV (Transform checkingObject, Transform target, float maxAngle, float maxRadius)
    {
        Collider[] overlaps = new Collider[10];
        int count = Physics.OverlapSphereNonAlloc(checkingObject.position, maxRadius, overlaps);

        for (int i = 0; i < count + 1; i++)
        {
            if (overlaps[i] != null)
            {
                if (overlaps[i].transform == target)
                {
                    Vector3 directionBetween = (target.position - checkingObject.position).normalized;
                    directionBetween.y *= 0;

                    float angle = Vector3.Angle(checkingObject.forward, directionBetween);

                    if (angle <= maxAngle)
                    {
                        Ray ray = new Ray(checkingObject.position, target.position - checkingObject.position);
                        RaycastHit hit;

                        if (Physics.Raycast(ray, out hit, maxRadius))
                        {
                            if (hit.transform == target)
                                return true;
                        }
                    }
                }
            }
        }

        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        isInFov = inFOV(transform, player, maxAngle, maxRadius);
    }

    /*/ Update is called once per frame
    void Update()
    {
        
        RaycastHit hitInfo = Physics.Raycast(transform.position, transform.forward, distance);
        if(hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
        }

        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
        }
        
    }*/
}
