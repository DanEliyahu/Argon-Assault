using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int score = 50;
    [SerializeField] private ParticleSystem deathVFX;
    [SerializeField] private Transform parent;
    [SerializeField] private float timeToVfxDestroy = 2f;

    private ScoreBoard _scoreBoard;

    private void Start()
    {
        _scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        _scoreBoard.IncreaseScore(score);
        var explosion = Instantiate(deathVFX, transform.position, Quaternion.identity, parent);
        Destroy(explosion.gameObject, timeToVfxDestroy);
        Destroy(this.gameObject);
    }
}