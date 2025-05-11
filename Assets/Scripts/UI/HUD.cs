using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private Animator hudAnimator;

    void Start()
    {
        hudAnimator = GetComponent<Animator>();
    }
        
    public void Disappear() {
        GetComponent<CanvasGroup>().alpha = 0f;
        transform.Find("Pause").GetComponent<Button>().interactable = false;
    }

    public void Display() {
        hudAnimator.SetTrigger("startGameTrigger");
        transform.Find("Pause").GetComponent<Button>().interactable = true;
    }
}
