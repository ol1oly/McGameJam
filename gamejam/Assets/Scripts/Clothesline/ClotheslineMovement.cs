using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class ClotheslineMovement : MonoBehaviour, IClickable 
{
    [SerializeField]
    private bool isRight;

    private float rightMaxPos;
    private float leftMaxPos;

    private GameObject clothing;

    void Awake()
    {

        clothing = GameObject.FindWithTag("Clothing");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rightMaxPos = transform.position.x;
        leftMaxPos = transform.position.x;
    }
    public void OnClick()
    {
        Debug.Log("OnCLick");
        // click on right pulley to move clothes to the right
        if (isRight)
        {
            // clothes move horizontally until they reach the end of the clothesline on the right side
            clothing.GetComponent<ClothingMovement>().moveRight(rightMaxPos);

        }
        // click on left pulley to move clothes to the left
        else
        {
            // clothes move horizontally until they reach the end of the clothesline on the left side
            clothing.GetComponent<ClothingMovement>().moveLeft(leftMaxPos);
        }
    }
    
    
}
