public interface IMusicManager
{
    void ConfigureAudioSource();
    void PlayMenuMusic();
    void PlayLevelMusic(int levelId);
    void PlayWin(bool isLastLevel);
    void PlayLoose();
}
