using UnityEngine;

public class PortalAnimation : MonoBehaviour
{
   
   [SerializeField] private Transform pointA;
   [SerializeField] private Transform pointB;

    private Transform currentTarget;
    // Update is called once per frame
    void Start()
    {
        currentTarget = pointA;
    }
    void Update()
    {
        float distanceToA = Vector3.Distance(transform.position, pointA.position);
        float distanceToB = Vector3.Distance(transform.position, pointB.position);
        float speed = 0.1f;
        if (Vector3.Distance(transform.position, currentTarget.position) < 0.01f)
        {
            currentTarget = (currentTarget == pointA) ? pointB : pointA;
        }
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
    }
}
