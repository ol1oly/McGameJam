using System.Collections;
using UnityEngine;

public class Window : MonoBehaviour
{
    [SerializeField] private float minWaitTimeToShowGirl = 5f;
    [SerializeField] private float maxWaitTimeToShowGirl = 15f;
    private Animator anim;
    void Start()
    {
        StartCoroutine(RandomShowGirlTime());
        anim = GetComponent<Animator>();
    }

    private IEnumerator RandomShowGirlTime()
    {
        while (true)
        {
            float waitTime = Random.Range(minWaitTimeToShowGirl, maxWaitTimeToShowGirl);
            yield return new WaitForSeconds(waitTime);
            anim.SetTrigger("Show");
        }
    }
    public void Escape()
    {
        StopAllCoroutines();
    }
}
