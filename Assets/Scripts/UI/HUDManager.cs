using UnityEngine;

public class HUDManager : MonoBehaviour
{
    private Score score;
    private Timer timer;

    void Start()
    {
        score = transform.Find("Score").GetComponent<Score>();
        timer = transform.Find("Timer").GetComponent<Timer>();

        timer.OnSecondPassed += score.AddScoreOnSecondPassed;
    }
}
