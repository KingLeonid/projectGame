using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    [SerializeField]
    float _velocity = 20;

    private void OnMouseDown()
    {
        switch (gameObject.name)
        {
            case "Armchair":

                Vector3 _endPos = new Vector3(2.98f, -2.26f, -2f);
                Vector3 _startPos = new Vector3(3.29f, -2.38f, -2f);
                if (transform.localPosition == _startPos)
                    transform.localPosition = Vector3.MoveTowards(_startPos, _endPos, Time.deltaTime * _velocity);
                else
                     if (transform.localPosition == _endPos)
                    transform.localPosition = Vector3.MoveTowards(_endPos, _startPos, Time.deltaTime * _velocity);
                break;

        }
    }
}
