using UnityEditor.SearchService;
using UnityEngine;

public class FireballShoot : MonoBehaviour
{
    public GameObject fireballObject;
    public float fireballCooldown;
    public float currentCooldown;

    void Start()
    {
        currentCooldown = fireballCooldown;
    }

    void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E) && currentCooldown <= 0)
        {
            currentCooldown = fireballCooldown;
            Instantiate(fireballObject, transform.position, transform.rotation);
        }
    }
}
