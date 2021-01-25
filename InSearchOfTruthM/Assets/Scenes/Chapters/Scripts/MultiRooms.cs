using UnityEngine;
public class MultiRooms : MonoBehaviour
{
    public GameObject[] rooms;


    public void Room1()
    {
        foreach (GameObject room in rooms)
        {
            room.SetActive(false);
        }
        rooms[0].SetActive(true);
    }
    public void Room2()
    {

        foreach (GameObject room in rooms)
        {
            room.SetActive(false);
        }
        rooms[1].SetActive(true);
    }
}
