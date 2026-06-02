using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance { get; private set; }

    private int currentStep = 0;
    private bool isSolved = false;

    [SerializeField] private Door door;

    private void Awake()
    {
        Instance = this;
    }

    public void PlateTriggered(int plateOrder)
    {
        if (isSolved) return;

        if (plateOrder == currentStep + 1)
        {
            currentStep++;
            // Debug.Log("Step++");

            if (currentStep == 3)
            {
                isSolved = true;
                door.Open(); 
                // Debug.Log("isSolved = True");
            }
        }
        else
        {
            // Debug.Log("Wrong order. Reset");
            currentStep = 0;
        }
    }
}