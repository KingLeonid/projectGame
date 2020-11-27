using UnityEngine.UI;
using UnityEngine;

public class SearchingObject : MonoBehaviour
{
    public Image imageObject;

    private void OnMouseDown()
    {
            Destroy(imageObject.gameObject);
            SpecialEffectsHelper.Instance.SearObjEffect(gameObject.transform.position);
            Destroy(gameObject);
    }
}
