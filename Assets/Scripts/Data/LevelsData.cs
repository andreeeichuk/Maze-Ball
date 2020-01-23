using UnityEngine;

[CreateAssetMenu(menuName ="Data/LevelsData",fileName ="LevelsData")]
public class LevelsData : ScriptableObject, ILevesData
{
    [SerializeField] string[] levelSceneNames = default;

    public int LevelCount()
    {
        return levelSceneNames.Length;
    }

    public string GetSceneNameByLevelId(int id)
    {
        return levelSceneNames[id];
    }
}
