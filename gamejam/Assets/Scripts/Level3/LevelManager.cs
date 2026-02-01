using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject witchObject;
    public float escapeDelay = 2f;

    [Header("Optional")]
    public GameObject victoryUI;

    private bool levelComplete = false;


    public void OnFireStarted()
    {
        if(levelComplete) return;

        levelComplete = true;
        Debug.Log("Fire started, witch escaping in"+ escapeDelay+ "seconds...");
        Invoke("WitchEscapes", escapeDelay);     
    }

    void WitchEscapes()
    {
        Debug.Log("LEVEL 3 DONE - Witch espaced!");
        //Cinematic or whatevr mayber No clue brochacho

        if(victoryUI != null)
        {
            victoryUI.SetActive(true);
        }

        if (witchObject != null)
        { //we move the witch offscreenw ahtever we may want
            witchObject.transform.position += Vector3.right * 20f;
        }

        //can also add whatever here like fade out before cinematic or WHATEVER MAN I DONT KNOW WHAT OT THINK NO MORE MAN GET OUTTA ME HEAD GET OUTTA ME HEAD MAN
    }
        
    
}
