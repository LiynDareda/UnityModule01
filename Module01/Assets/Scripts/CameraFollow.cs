using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CameraFollowAndReset : MonoBehaviour
{
    [Header("Follow")]
    [SerializeField] private Vector3 offset = new Vector3(0f, 5f, -10f);
    [SerializeField] private float smoothSpeed = 10f;

    private void Update()
    {
        // Reset della scena
        if (Keyboard.current.rKey.wasPressedThisFrame || Keyboard.current.backspaceKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void LateUpdate()
    {
        // Follow sul player attivo
        PlayerController active = PlayerController.ActivePlayer;
        if (active == null || !(active.GetActive())) return;

        Vector3 desiredPos = active.transform.position + offset;

        transform.position = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
    }
}