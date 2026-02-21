using UnityEngine;
using UnityEngine.InputSystem;
//Utilizza le librerie di unity

[RequireComponent(typeof(Rigidbody))] //Assicura che il GameObject abbia un componente Rigidbody
public class PlayerController : MonoBehaviour
{
	[Header("CharacterID")] //Intestazione per l'ID del personaggio nell'ispector
		[SerializeField] private int playerId = 0;
	[Header("Movement")] //Intestazione per il movimento nell'ispector
		[SerializeField] private float moveSpeed = 6f; //[SerializeField] rende la variabile visibile e modificabile nell'Inspector di Unity

	[Header("Jump")] //Intestazione per il salto nell'ispectora
		[SerializeField] private float jumpForce = 6f;
		[SerializeField] private LayerMask groundMask = ~0;

	private Rigidbody rb;
	private Vector2 moveInput;
	private bool isActive;
	private Collider col;
	public static PlayerController ActivePlayer { get; private set; }

	public int PlayerId => playerId;

	private void Awake() //Viene chiamato prima di start e serve per inizializzare le variabili o componenti
	{
		rb = GetComponent<Rigidbody>();
		col = GetComponent<Collider>();
		isActive = false;
	}

	// Collegato dal PlayerInput (Unity Events)
	public void OnMove(InputAction.CallbackContext context)
	{
		if (isActive == false) return;
		moveInput = context.ReadValue<Vector2>();
	}

	// Collegato dal PlayerInput (Unity Events)
	public void OnJump(InputAction.CallbackContext context)
	{
		if (!context.performed) return;
		if (isActive == false) return;
		if (IsGrounded())
		{
			Jump();
		}
	}
	public bool GetActive()
	{
		return (isActive);
	}

	public void SetActive(bool value)
	{
		isActive = value;

		if (isActive)
		{
			ActivePlayer = this;
		}
		else
			moveInput = Vector2.zero;

		Vector3 v = rb.linearVelocity;
		rb.linearVelocity = new Vector3(0f, v.y, 0f);
	}

	private void Update()
	{
		if (Keyboard.current.digit1Key.wasPressedThisFrame) SetActive(playerId == 0);
		if (Keyboard.current.digit2Key.wasPressedThisFrame) SetActive(playerId == 1);
		if (Keyboard.current.digit3Key.wasPressedThisFrame) SetActive(playerId == 2);
	}

	private void FixedUpdate()
	{
		if (isActive == false) return;
		Vector3 desired = new Vector3(moveInput.x, 0f, moveInput.y).normalized * moveSpeed;

		Vector3 v = rb.linearVelocity;
		rb.linearVelocity = new Vector3(desired.x, v.y, desired.z);
	}

	private void Jump()
	{
		Vector3 v = rb.linearVelocity;
		v.y = 0f;
		rb.linearVelocity = v;

		rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
	}

	private bool IsGrounded()
    {
        Bounds b = col.bounds;

        float height = b.size.y;

        // distanza proporzionale all'altezza (generica per tutti)
        float castDistance = Mathf.Max(0.05f, height * 0.12f);

        // box più piccola della base
        Vector3 halfExtents = new Vector3(b.extents.x * 0.9f, 0.02f, b.extents.z * 0.9f);

        // parti appena sopra i piedi
        Vector3 origin = new Vector3(b.center.x, b.min.y + 0.03f, b.center.z);

        return Physics.BoxCast(
            origin,
            halfExtents,
            Vector3.down,
            Quaternion.identity,
            castDistance,
            groundMask,
            QueryTriggerInteraction.Ignore
        );
    }
}