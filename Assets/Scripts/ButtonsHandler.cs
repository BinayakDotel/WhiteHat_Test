using UnityEngine;
using UnityEngine.UI;

public class ButtonsHandler : MonoBehaviour
{
    [SerializeField] GameManager game_manager;
    [SerializeField] Button button;

    private void Awake()
    {
        game_manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        button = GetComponent<Button>();

        button.onClick.AddListener(OnButtonClicked);
    }
    void OnButtonClicked()
    {
        if (this.name == "reloadBtn")
        {
            game_manager.ReloadScene();
        }
        if (this.name == "closeBtn")
        {
            print("CLOSE");
            game_manager.QuitApplication();
        }
    }
}
