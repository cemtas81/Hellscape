
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelChanger2 : MonoBehaviour
{
    private static LevelChanger2 instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene(3);
        } 
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene(4);
        }
    }
}
