using UnityEngine;

public class Boss3 : MonoBehaviour
{
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    public void BackToStartPosition()
    {
        transform.position = startPosition;
    }
}
