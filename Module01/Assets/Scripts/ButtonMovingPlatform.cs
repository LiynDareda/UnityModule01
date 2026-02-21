using UnityEngine;

public class ButtonMovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject Platform;
    [SerializeField] private Material Blue;
    [SerializeField] private Material Red;
    [SerializeField] private Material Yellow;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player.PlayerId == 0 && Platform != null)
            {
                Platform.layer = LayerMask.NameToLayer("Blue");
                Platform.GetComponent<Renderer>().material = Blue;
            }
            else if (player.PlayerId == 1 && Platform != null)
            {
                Platform.layer = LayerMask.NameToLayer("Red");
                Platform.GetComponent<Renderer>().material = Red;
            }
            else if (player.PlayerId == 2 && Platform != null)
            {
                Platform.layer = LayerMask.NameToLayer("Yellow");
                Platform.GetComponent<Renderer>().material = Yellow;
            }
        }
    }
}
