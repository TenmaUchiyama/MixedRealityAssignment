using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private int enterKeyCount = 0;

    void Update()
    {
        // �L�[�{�[�h�̃G���^�[�L�[�������ꂽ���ǂ������`�F�b�N
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // �G���^�[�L�[�������ꂽ�񐔂��C���N�������g
            enterKeyCount++;

            // �J�E���g���ꂽ�񐔂�Debug.Log�ŕ\��
            Debug.Log("Enter key pressed " + enterKeyCount + " times.");
        }
    }
}