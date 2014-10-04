using UnityEngine;
using System.Collections;

public class BlockControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		m_freezeCount	= 0;
		m_freezed		= false;
		m_prePosition	= new Vector3();
	}
	
	// Update is called once per frame
	void Update () {
		if( !m_freezed) {
			if( m_prePosition == transform.position) {
				++m_freezeCount;
				if( m_freezeCount > FreezeCountNum) {
					Rigidbody rigid = GetComponent< Rigidbody>();
					rigid.constraints = RigidbodyConstraints.FreezeAll;
					m_freezed = true;
				}
			}
			else {
				m_freezeCount = 0;
			}
			m_prePosition = transform.position;
		}
	}

	public		BlockManager.Type	m_type = BlockManager.Type.King;

	private		int					m_freezeCount;
	private		bool				m_freezed;
	private		Vector3				m_prePosition;

	public		int					FreezeCountNum;
}
