using UnityEngine;
using System.Collections;

public class BlockManager : MonoBehaviour {

	void Awake() {
		m_blockList				= new ArrayList( 100);
		m_releaseBlockParent	= new GameObject();
		m_releaseBlockParent.name = "ReleaseBlockParent";
		m_releaseBlockParent.transform.parent = transform;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void	Initialize()
	{
		for(int i = 0; i < m_blockList.Count; ++i) {
			Object obj = m_blockList[ i] as Object;
			Destroy( obj);
		}
		m_blockList.Clear();
	}

	public GameObject		createBlock()
	{
		GameObject obj = Instantiate( Resources.Load( "Block")) as GameObject;
		obj.transform.parent = transform;
		m_blockList.Add( obj);
		return obj;
	}

	public void				addReleaseBlock( GameObject obj )
	{
		if( obj != null) {
			obj.transform.parent = m_releaseBlockParent.transform;
		}
	}

	private GameObject		m_releaseBlockParent;
	private ArrayList		m_blockList;

	public enum Type {
		  Stone
		, King
		, Num
		, Invalid = -1
	};
}
