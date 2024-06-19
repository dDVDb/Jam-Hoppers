using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MovieController : MonoBehaviour
{
    VideoPlayer player;

    [SerializeField]
    List<GameObject> on;
    private void Awake()
    {
        player = GetComponent<VideoPlayer>();

        player.loopPointReached += OnMovieFinished;
    }

    void OnMovieFinished(UnityEngine.Video.VideoPlayer vp)
    {
        foreach (var item in on)
        {
            item.SetActive(true);
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
