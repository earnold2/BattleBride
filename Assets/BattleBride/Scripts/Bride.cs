using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bride : MonoBehaviour
{
    public bool youWin;
    private bool youAlreadyWon;

    // Start is called before the first frame update
    void Start()
    {
        youWin = false;
        youAlreadyWon = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!youAlreadyWon)
        {
            youWin = true;

            youAlreadyWon = true;
        }
    }
}
