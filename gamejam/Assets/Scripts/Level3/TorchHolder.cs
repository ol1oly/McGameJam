using UnityEngine;

public class TorchHolder : MonoBehaviour
{
    public GameObject torchObject;
    public Vector2 torchOffset = new Vector2(0.5f, 0.3f);

    void Start()
    {
        if(torchObject == null)
        {
            Transform torchTransform = transform.Find("Torch");

            if(torchTransform != null)
            {
                torchObject= torchTransform.gameObject;
            }
        }
    }

    void Update()
    {
        if(torchObject != null)
        {//keep at pos, maybe useless mayeb useful we neevr know if we move gurd
            torchObject.transform.position = (Vector2)transform.position + torchOffset;
        }
    }
}
