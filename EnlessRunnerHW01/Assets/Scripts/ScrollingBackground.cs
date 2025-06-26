using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float speedHorizontal;
    public float speedVertical;

    [SerializeField]
    private Renderer bgRenderer;

    // Update is called once per frame
    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(speedHorizontal * Time.deltaTime, speedVertical * Time.deltaTime);
    }
}
