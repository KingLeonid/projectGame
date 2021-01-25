using UnityEngine;

public class Responsive2D : MonoBehaviour
{


    private void Start()
    {
        fitCameraWidthAndHeight();
    }
    void fitCameraWidthAndHeight()
    {
        SpriteRenderer sr = (SpriteRenderer)GetComponent("Renderer");
        if (sr == null)
            return;

        sr.sprite.texture.filterMode = FilterMode.Point;

        double width = sr.sprite.bounds.size.x;
        double height = sr.sprite.bounds.size.y;
        double worldScreenHeight = Camera.main.orthographicSize * 2.0;
        double worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;


        transform.localScale = new Vector3(1 * (float)(worldScreenWidth / width), 1 * (float)(worldScreenHeight / height), 1);

    }
}