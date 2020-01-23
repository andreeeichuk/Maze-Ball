using UnityEngine;

[CreateAssetMenu(menuName = "Data/MusicData", fileName = "MusicData")]
public class MusicData : ScriptableObject, IMusicData
{
    public AudioClip MenuMusic => menuMusic;
    public AudioClip LevelMusic => levelMusic;
    public AudioClip WinMusic => winMusic;
    public AudioClip LooseMusic => looseMusic;

    [SerializeField] private AudioClip menuMusic = default;
    [SerializeField] private AudioClip levelMusic = default;
    [SerializeField] private AudioClip winMusic = default;
    [SerializeField] private AudioClip looseMusic = default;
}
