using UnityEngine;
using UnityEngine.SceneManagement;

public class CommunityCenter_SwtichScenes : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("1_CommunityCenter"); // 或你的主场景名字
    }
}
