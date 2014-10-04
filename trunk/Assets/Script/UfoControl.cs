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

		m_moveSpeed = MinMoveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		//	add position
		transform.Translate( MoveDirection * m_moveSpeed);
		if( transform.localPosition.x < EndPositionX) {
			Vector3 position = transform.localPosition;
			transform.localPosition = new Vector3( StartPositionX, position.y, position.z);

			if( m_block == null) {
				m_block = createBlock();
				m_moveSpeed += AddMoveSpeed;
				if( m_moveSpeed > MaxMoveSpeed) {
					m_moveSpeed = MaxMoveSpeed;
				}
			}
		}

		// throw block
		if( Input.GetMouseButtonDown(0)) {
			if( m_block != null) {
				releaseBlock();
			}
		}
	}

	GameObject				createBlock()
	{
		GameObject obj = m_blockManager.createBlock();
		obj.transform.localPosition = transform.localPosition;
		obj.transform.parent = transform;
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

	public float			AddMoveSpeed		=  0.01f;
	public float			MinMoveSpeed		=  0.1f;
	public float			MaxMoveSpeed		=  0.5f;
	public float			StartPositionX		=  10.0f;
	public float			EndPositionX		= -10.0f;
	public Vector3			MoveDirection;
}
