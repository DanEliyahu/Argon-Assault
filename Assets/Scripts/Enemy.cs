using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int score = 50;
    [SerializeField] private int hitPoints = 6;
    [SerializeField] private ParticleSystem deathVFX;
    [SerializeField] private ParticleSystem hitVFX;
    [SerializeField] private float timeToVfxDestroy = 2f;

    private ScoreBoard _scoreBoard;
    private Transform _parent;

    private void Start()
    {
        _scoreBoard = FindObjectOfType<ScoreBoard>();
        _parent = GameObject.FindWithTag("SpawnAtRuntime").transform;
        AddRigidBody();
    }

    private void AddRigidBody()
    {
        var rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
    }
    private void OnParticleCollision(GameObject other)
    {
        _scoreBoard.IncreaseScore(score);
        hitPoints--;
        if (hitPoints <= 0)
        {
            DestroyEnemy();
        }
        else
        {
            var hit = Instantiate(hitVFX, transform.position, Quaternion.identity, _parent);
            Destroy(hit.gameObject, timeToVfxDestroy); 
        }
    }

    private void DestroyEnemy()
    {
        var explosion = Instantiate(deathVFX, transform.position, Quaternion.identity, _parent);
        Destroy(explosion.gameObject, timeToVfxDestroy);
        Destroy(this.gameObject);
    }
}