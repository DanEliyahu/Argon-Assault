using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float levelLoadDelay = 1f;
    [SerializeField] private ParticleSystem crashVFX;

    private bool _isTransitioning = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_isTransitioning)
        {
            return;
        }

        StartCrashSequence();
    }

    private void StartCrashSequence()
    {
        _isTransitioning = true;
        crashVFX.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<PlayerControls>().enabled = false;
        Invoke(nameof(ReloadLevel), levelLoadDelay);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}