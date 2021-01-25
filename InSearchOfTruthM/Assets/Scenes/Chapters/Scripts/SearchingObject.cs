using UnityEngine;
using UnityEngine.UI;

public class SearchingObject : MonoBehaviour
{
    public Image imageObject;
    private Vector3 posEffect; 

    public void OnMouseDown()
    {
        if (imageObject.GetComponent<Renderer>().IsVisibleFrom(Camera.main))
        {
            posEffect = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -2f);
            Destroy(imageObject.gameObject);
            SpecialEffectsHelper.Instance.SearObjEffect(posEffect);
            Destroy(gameObject);
        }
    }
}



