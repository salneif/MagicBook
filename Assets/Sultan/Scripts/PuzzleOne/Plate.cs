using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField] private int plateOrder;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material litMaterial;

    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            PuzzleManager.Instance.PlateTriggered(plateOrder);
    }

    public void SetLit(bool on)
    {
        meshRenderer.material = on ? litMaterial : defaultMaterial;
    }
}