// ChatGPT taraf�ndan olu�turulmu�tur.
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Transform targetPosition;  // Kamera hedef noktas�
    public float moveSpeed = 5f;      // Sabit hareket h�z�

    private Camera mainCamera;
    private bool shouldMove = false;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            shouldMove = true; // Hareketi ba�lat
        }
    }

    void Update()
    {
        if (shouldMove)
        {
            Vector3 targetPos = targetPosition.position;
            targetPos.z = mainCamera.transform.position.z; // Z ekseni sabit kalmal�

            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, targetPos, moveSpeed * Time.deltaTime);

            // Hedefe ula��ld�ysa hareketi durdur
            if (Vector3.Distance(mainCamera.transform.position, targetPos) < 0.1f)
            {
                mainCamera.transform.position = targetPos;
                shouldMove = false;
            }
        }
    }
}
