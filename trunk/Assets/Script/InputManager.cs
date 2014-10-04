using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		m_Pressing = new bool[TOUCH_MAX];
		m_Release = new bool[TOUCH_MAX];
		m_Click = new bool[TOUCH_MAX];
	}
	
	// Update is called once per frame
	void Update () {
		updateTouch ();
	}

	void updateTouch() {
		for (int i = 0; i < m_Pressing.Length; ++i) {
			if( m_Pressing[i] ) {
				m_Release[i] = isMouseButtonUp(i);
				m_Pressing[i] = !m_Release[i];
				m_Click[i] = false;
			}
			else {
				m_Pressing[i] = isMouseButtonDown(i);
				m_Click[i] = m_Pressing[i];
				m_Release[i] = false;
			}
		}
	}

	public bool isTouchClick( int i ) {
		// TODO: assert
		return m_Click[i];
	}

	public bool isTouchPressing( int i ) {
		// TODO: assert
		return m_Pressing [i];
	}

	public bool isTouchRelease( int i ) {
		// TODO: assert
		return m_Release [i];
	}

	// private
	private bool isMouseButtonDown( int i ) {
		return Input.GetMouseButtonDown (i);
	}

	private bool isMouseButtonUp( int i ) {
		return Input.GetMouseButtonUp (i);
	}

	const int TOUCH_MAX = 2;
	private bool[] m_Pressing;
	private bool[] m_Release;
	private bool[] m_Click;
}
