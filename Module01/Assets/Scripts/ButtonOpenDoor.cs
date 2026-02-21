using UnityEngine;

public class ButtonOpenDoor : MonoBehaviour
{
    [SerializeField] private GameObject BlueDoor;
    [SerializeField] private GameObject RedDoor;
    [SerializeField] private GameObject YellowDoor; 

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player.PlayerId == 0 && BlueDoor != null)
            {
                Destroy(BlueDoor.gameObject);
            }
            else if (player.PlayerId == 1 && RedDoor != null)
            {
                Destroy(RedDoor.gameObject);
            }
            else if (player.PlayerId == 2 && YellowDoor != null)
            {
                Destroy(YellowDoor.gameObject);
            }
        }
    }
}
