using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject gameManger;

    public void Awake()
    {
        if (GameManger.Instance == null)
        {
            Instantiate(gameManger);
        }
    }
}
