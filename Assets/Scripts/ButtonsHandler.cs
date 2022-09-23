using UnityEngine;
using UnityEngine.UI;

public class ButtonsHandler : MonoBehaviour
{
    GameManager game_manager;
    Button button;

    private void Awake()
    {
        game_manager = GameManager.Instance;
        button = GetComponent<Button>();

        button.onClick.AddListener(OnButtonClicked);
    }
    void OnButtonClicked()
    {
        if (this.name == "reloadBtn")
        {
            game_manager.ReloadScene();
        }
    }
}
