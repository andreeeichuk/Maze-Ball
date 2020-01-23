using UnityEngine;

public interface IMusicData
{
    AudioClip MenuMusic { get; }
    AudioClip LevelMusic { get; }
    AudioClip WinMusic { get; }
    AudioClip LooseMusic { get; }
}
