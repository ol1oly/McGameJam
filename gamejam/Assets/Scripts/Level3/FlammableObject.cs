using UnityEngine;

public class FlammableObject : MonoBehaviour
{
    public GameObject firePrefab; //fireparticle system or wtv they come up with
    public float ignitionRadius = 2f;
    public string torchTag = "Torch";
    

    [Header("Optionnal Visual Feedback")]
    public bool changeColorWhenBurning = true;
    public Color burningColor = new Color(1f,0.5f,0f); //orange

    private bool isOnFire = false;
    private GameObject fireEffect;

    void Update()
    {
        if (!isOnFire)
        {
            CheckForIgnition();
        }
    }

    void CheckForIgnition()
    {
        GameObject[] torches = GameObject.FindGameObjectsWithTag(torchTag);

        foreach(GameObject torch in torches)
        {
            float distance = Vector2.Distance(transform.position, torch.transform.position);

            if(distance <= ignitionRadius)
            {
                Ignite();
                break;
            }
        }
    }


    void Ignite()
    {
        if(isOnFire)return;

        isOnFire = true;

        Debug.Log(gameObject.name+" caugh on FIRE !!!");

        if(firePrefab != null)
        {
            fireEffect = Instantiate(firePrefab, transform.position, Quaternion.identity, transform);
        }

        if (changeColorWhenBurning)
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if(sr != null)
            {
                sr.color = burningColor;
            }
        }

        //whatever it may be but basically the implementation of win
        /*
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        if(levelManager != null)
        {
            levelManager.OnFireStarted
        }*/
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ignitionRadius);
    }
}
