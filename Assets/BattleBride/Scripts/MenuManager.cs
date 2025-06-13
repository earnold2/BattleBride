using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("BBLevel");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("BBMenuScene");
    }

    public void Checkpoint(Transform transform)
    {
        GameObject.Find("BBPlayer").gameObject.transform.localPosition = transform.localPosition;
    }
}
