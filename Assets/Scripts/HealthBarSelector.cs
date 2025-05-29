using UnityEngine;

public class HealthBarSelector : MonoBehaviour
{
    [SerializeField] Sprite[] healthbars;

    private void Start()
    {
        //Debug.Log("Triggered");

        gameObject.GetComponent<SpriteRenderer>().sprite = healthbars[0];
    }

    public void updateHealthBar(float healthPercentage)
    {
        if (healthPercentage <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = healthbars[5];
        }
        else if (healthPercentage <= 20)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = healthbars[4];
        }
        else if (healthPercentage <= 40)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = healthbars[3];
        }
        else if (healthPercentage <= 60)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = healthbars[2];
        }
        else if (healthPercentage <= 80)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = healthbars[1];
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = healthbars[0];
        }
    }
}
