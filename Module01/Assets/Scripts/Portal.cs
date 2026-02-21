using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private int PortalId;
    [SerializeField] private Transform Destination;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player.PlayerId == PortalId)
            {
                other.transform.position = Destination.position;
            }
        }
    }
}
