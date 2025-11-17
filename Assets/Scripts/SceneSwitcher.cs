using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private readonly string[] sceneNames = {
        "MainGame",
        "1.1_CommunityCenter",
        "1.2_CommunityCenter",
        "1.2.1_CommunityCenter",
        "2.0_CommunityCenter",
        "2.0.1_CommunityCenter",
        "3.0_Dr.-Chen's-Medical-Center",
        "3.0.1_Dr.-Chen's-Medical-Center",
        "3.0.2_Dr.-Chen's-Medical-Center",  // Placeholder for additional scene 9 
        "3.1.1_Dr.-Chen's-Medical-Center", // Placeholder for additional scene 10 (Save Sofia. She's young.)
        "3.1.2_Dr.-Chen's-Medical-Center", // Placeholder for additional scene 11 (Balance therapy. Give them all some.)
        "3.1.3_Dr.-Chen's-Medical-Center", // Placeholder for additional scene 12 (This was Dr. Chen's decision.)
        "3.1.4_Dr.-Chen's-Medical-Center", // Placeholder for additional scene 13 (I'm sorry, I can't help you.)
        "4.0.1_Government-Building", // Placeholder for additional scene 14 和平重建和新秩序線結局
        "4.0.2_Government-Building", // Placeholder for additional scene 15 和平重建和新秩序線結局
        "4.0.3_Government-Building", // Placeholder for additional scene 16 孤狼逃脫結局
        "4.0.4_Government-Building", // Placeholder for additional scene 17 平衡結局
        "Peace-Reconstruction-and-New Order-Ending", // Placeholder for additional scene 18 
        "Lone-Wolf-Escape-Ending", // Placeholder for additional scene 19
        "Balanced-Ending"  // Placeholder for additional scene 20
    };

    public void SwitchScenes1() { LoadSceneByIndex(0); }
    public void SwitchScenes2() { LoadSceneByIndex(1); }
    public void SwitchScenes3() { LoadSceneByIndex(2); }
    public void SwitchScenes4() { LoadSceneByIndex(3); }
    public void SwitchScenes5() { LoadSceneByIndex(4); }
    public void SwitchScenes6() { LoadSceneByIndex(5); }
    public void SwitchScenes7() { LoadSceneByIndex(6); }
    public void SwitchScenes8() { LoadSceneByIndex(7); }
    public void SwitchScenes9() { LoadSceneByIndex(8); }
    public void SwitchScenes10() { LoadSceneByIndex(9); }
    public void SwitchScenes11() { LoadSceneByIndex(10); }
    public void SwitchScenes12() { LoadSceneByIndex(11); }
    public void SwitchScenes13() { LoadSceneByIndex(12); }
    public void SwitchScenes14() { LoadSceneByIndex(13); }
    public void SwitchScenes15() { LoadSceneByIndex(14); }
    public void SwitchScenes16() { LoadSceneByIndex(15); }
    public void SwitchScenes17() { LoadSceneByIndex(16); }
    public void SwitchScenes18() { LoadSceneByIndex(17); }
    public void SwitchScenes19() { LoadSceneByIndex(18); }
    public void SwitchScenes20() { LoadSceneByIndex(19); }

    private void LoadSceneByIndex(int index)
    {
        if (index >= 0 && index < sceneNames.Length)
        {
            SceneManager.LoadScene(sceneNames[index]);
        }
        else
        {
            Debug.LogWarning("场景索引无效: " + index);
        }
    }
}