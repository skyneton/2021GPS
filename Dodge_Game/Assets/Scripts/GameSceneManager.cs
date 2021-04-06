using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    private Player player;
    private EnemySpawner spawner;
    private UITime timer;
    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<EnemySpawner>();
        timer = FindObjectOfType<UITime>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.getHP() <= 0) {
            gameOverUI.SetActive(true);
            spawner.OffSpawner();
            timer.OffTimer();
        }
    }

    public void RestartButton() {
        SceneManager.LoadScene("SampleScene");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitButton() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
