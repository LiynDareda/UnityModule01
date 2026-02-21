using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed;
    [SerializeField] private int projectileId;

    void Update()
    {
        transform.Translate(new Vector3(projectileSpeed * Time.deltaTime, 0f, 0f));
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player.PlayerId == projectileId)
            {
                Debug.Log("Game Over");
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }
        if(!(other.CompareTag("Player") || other.CompareTag("Enemy")))
        {
            Destroy(this.gameObject);
        }
    }
}
