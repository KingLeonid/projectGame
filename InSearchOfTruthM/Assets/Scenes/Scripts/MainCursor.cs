using UnityEngine;
using UnityEngine.EventSystems;
public class MainCursor : MonoBehaviour
{

    public RectTransform[] cursors;

    private Vector2 offset;
    private int index = -1;
    private int i = 0;
    private bool center = false;

    void Awake()
    {
        Cursor.visible = false;
    }

    public void OnPointerEnterButtons()
    {
        i = 1;
        center = true;
    }
    public void OnPointerExitButtons()
    {
        i = 0;
        center = true;
    }
    public void OnPointerEnterRoom()
    {
        i = 2;
        center = true;
    }
    public void OnPointerEnterRoom2()
    {
        i = 3;
        center = true;
    }
    void SetCursor()
    {
        center = false;
        if (!EventSystem.current.IsPointerOverGameObject())
            i = 0;
        if (index != i)
        {

            foreach (RectTransform obj in cursors)
            {
                obj.gameObject.SetActive(false);
            }
            cursors[i].gameObject.SetActive(true);

            if (center) offset = Vector2.zero;
            else offset = new Vector2(cursors[i].sizeDelta.x / 2, -cursors[i].sizeDelta.y / 2);
        }

        index = i;

        SetPosition(cursors[i]);
    }

    void SetPosition(RectTransform rectTransform)
    {
        rectTransform.anchoredPosition = new Vector2(Input.mousePosition.x + offset.x, Input.mousePosition.y + offset.y);
    }

    void LateUpdate()
    {
        SetCursor();
    }
}

