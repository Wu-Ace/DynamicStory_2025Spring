using UnityEngine;
using UnityEngine.Playables;

public class IntroManager : MonoBehaviour
{
    [SerializeField] private PlayableDirector cameraTimeline;
    [SerializeField] private GameManager gameManager;

    private bool hasPlayedIntro = false;
    private bool hasWon = false;

    private void Start()
    {
        // Ensure the timeline doesn't play at the start
        if (cameraTimeline != null)
        {
            cameraTimeline.Stop();
        }
    }

    private void Update()
    {
        // Check if the game has been won and the animation hasn't been played yet
        if (!hasPlayedIntro && !hasWon)
        {
            // Check if all pellets have been eaten
            if (!gameManager.HasRemainingPellets())
            {
                hasWon = true;
                PlayCameraTimeline();
            }
        }
    }

    private void PlayCameraTimeline()
    {
        if (cameraTimeline != null)
        {
            cameraTimeline.Play();
            hasPlayedIntro = true;
        }
    }
}