using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float rateOfFire = 1f;
    [SerializeField] private Transform point;
    private float fireRateDelta;
   
    private void Awake()
    {
        fireRateDelta = 0f;
    }

    void Update()
    {
        fireRateDelta -= Time.deltaTime;
        if(fireRateDelta <= 0)
        {
            fireRateDelta = rateOfFire;
            Instantiate(projectile, point.position, point.rotation);
        }
    }

}
