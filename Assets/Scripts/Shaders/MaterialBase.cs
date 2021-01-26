using UnityEngine;

public class MaterialBase : MonoBehaviour
{
    public Renderer renderer;
    public Color color;
    public float glossiness;

    public MaterialBase()
    {

    }

    private void Update()
    {
        if (renderer)
        {
            renderer.material.color = color;
            renderer.material.SetFloat("_Glossiness", glossiness);
        }
        else
        {
            Debug.Log("Not finding renderer");
        }
    }

}
