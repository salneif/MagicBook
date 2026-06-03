using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance { get; private set; }

    [SerializeField] private Door door;
    [SerializeField] private Plate[] plates;

    private int currentStep = 0;
    private bool isSolved = false;

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
            plates[plateOrder - 1].SetLit(true);
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
            foreach (var plate in plates)
                plate.SetLit(false);
            currentStep = 0;
            // Debug.Log("Wrong order. Reset");
        }
    }
}