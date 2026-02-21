using UnityEngine;

public class Exit : MonoBehaviour
{
    [Header("Exit ID")]
    	[SerializeField] private int exitId = 0;

	[SerializeField] private GameObject dotIndicator;

	private void OnTriggerEnter(Collider other)
	{
		PlayerController player = other.GetComponent<PlayerController>();
		if (player != null && player.PlayerId == exitId)
		{
			dotIndicator.SetActive(true);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		PlayerController player = other.GetComponent<PlayerController>();
		if (player != null && player.PlayerId == exitId)
		{
			dotIndicator.SetActive(false);
		}
	}


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {

    }
}
