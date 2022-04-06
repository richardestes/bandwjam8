using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    [SerializeField]
    private Timer timer;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            timer.StopTimer();
            string finishTime = timer.GetFinishTime();
            print("Player finished level");
            print("Finish time: " + finishTime);
        }
    }
}
