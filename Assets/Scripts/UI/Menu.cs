using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private Animator menuAnimator;
    private Button playButton;
    private Button quitButton;

    void Start()
    {
        menuAnimator = GetComponent<Animator>();
        playButton = transform.Find("PlayPart").Find("PlayButton").GetComponent<Button>();
        quitButton = transform.Find("QuitPart").Find("QuitButton").GetComponent<Button>();
    }

    public void Disappear() {
        menuAnimator.SetTrigger("startGameTrigger");
        playButton.interactable = false;
        quitButton.interactable = false;
    }
}
