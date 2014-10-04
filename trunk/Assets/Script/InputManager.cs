using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		m_touchState = new TouchState[TOUCH_MAX];
		for( int i = 0; i < m_touchState.Length; ++i ) {
			clearTouchState( ref m_touchState[i] );
		}
	}
	
	// Update is called once per frame
	void Update () {
		updateTouch ();
	}

	void updateTouch() {
		for( int i = 0; i < m_touchState.Length; ++i ) {
			updateTouch ( i );
		}
	}

	void updateTouch( int i ) {
		if( m_touchState[i].pressing ) {
			m_touchState[i].release = isMouseButtonUp(i);
			m_touchState[i].pressing = !m_touchState[i].release;
			m_touchState[i].click = false;
		}
		else {
			m_touchState[i].pressing = isMouseButtonDown(i);
			m_touchState[i].click = m_touchState[i].pressing;
			m_touchState[i].release = false;
		}
	}

	public bool isTouchClick( int i ) {
		// TODO: assert
		return m_touchState[i].click;
	}

	public bool isTouchPressing( int i ) {
		// TODO: assert
		return m_touchState[i].pressing;
	}

	public bool isTouchRelease( int i ) {
		// TODO: assert
		return m_touchState[i].release;
	}

	// private
	private bool isMouseButtonDown( int i ) {
		return Input.GetMouseButtonDown (i);
	}

	private bool isMouseButtonUp( int i ) {
		return Input.GetMouseButtonUp (i);
	}

	const int TOUCH_MAX = 2;
	struct TouchState{
		public bool pressing;
		public bool release;
		public bool click;
	};
	private TouchState[] m_touchState;

	private void clearTouchState( ref TouchState s ) {
		s.pressing = false;
		s.release = false;
		s.click = false;
	}
}
