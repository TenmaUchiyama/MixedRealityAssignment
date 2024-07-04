using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private int enterKeyCount = 0;

    void Update()
    {
        // キーボードのエンターキーが押されたかどうかをチェック
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // エンターキーが押された回数をインクリメント
            enterKeyCount++;

            // カウントされた回数をDebug.Logで表示
            Debug.Log("Enter key pressed " + enterKeyCount + " times.");
        }
    }
}