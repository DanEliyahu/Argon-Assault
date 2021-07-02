using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        var numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if (numMusicPlayers > 1)
        {
            GameObject o;
            (o = gameObject).SetActive(false);
            Destroy(o);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
