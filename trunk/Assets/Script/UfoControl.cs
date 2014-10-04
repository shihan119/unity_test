using UnityEngine;
using System.Collections;

public class UfoControl : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		//	initiralize position
		Vector3 position = transform.localPosition;
		transform.localPosition = new Vector3( StartPositionX, position.y, position.z);
		//	create block
		m_blockManager = FindObjectOfType< BlockManager>();
		m_block 	   = createBlock();

		m_moveSpeed	= MinMoveSpeed;

		StartPosition = new Vector3( StartPositionX, position.y, position.z);

		m_inputManager = FindObjectOfType<InputManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		//	add position
		transform.Translate( MoveDirection * m_moveSpeed * Time.deltaTime);
		//	positon reset
		if( transform.localPosition.x < EndPositionX) {

			transform.localPosition = StartPosition;

			if( m_block == null) {
				// block
				m_block = createBlock();
				// speed up
				m_moveSpeed += AddMoveSpeed;
				if( m_moveSpeed > MaxMoveSpeed) {
					m_moveSpeed = MaxMoveSpeed;
				}
			}
		}

		// throw block
		if( m_inputManager.isTouchClick( 0 )) {
			if( m_block != null) {
				releaseBlock();
			}
		}
	}

	GameObject				createBlock()
	{
		GameObject obj = m_blockManager.createBlock();
		obj.transform.parent		= transform;
		obj.transform.localPosition = Vector3.zero;
		return obj;
	}

	void					releaseBlock()
	{
		//	on use gravity from block.
		m_block.rigidbody.useGravity = true;
		m_block.transform.parent = null;

		m_blockManager.addReleaseBlock( m_block);

		m_block = null;
	}

	private BlockManager	m_blockManager;
	private GameObject		m_block;
	public float			m_moveSpeed;

	public InputManager		m_inputManager;

	public float			AddMoveSpeed;
	public float			MinMoveSpeed;
	public float			MaxMoveSpeed;
	public float			StartPositionX;
	public float			EndPositionX;
	public Vector3			MoveDirection;
	private Vector3			StartPosition;
}
