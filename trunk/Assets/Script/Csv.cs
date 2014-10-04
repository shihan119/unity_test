using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Csv {

	private int			m_row;
	private string[][]	m_dataArray;

	public int		row {
		get {
			return m_row;
		}
	}

	public int		col( int row ) {
		return m_dataArray[ row].Length;
	}

	public string	this[ int x, int y ] {
		get {
			if( x < m_row && y < col( x)) {
				return m_dataArray[ m_row][ y];
			}
			return null;
		}
	}

	public bool		loadResource( string filePath ) {

		TextAsset resource = Resources.Load ( filePath) as TextAsset;
		if( resource == null ) {
			return false;
		}

		string[] lineArray = resource.text.Replace("\r\n", "\n").Split('\n');   
		ArrayList list = new ArrayList( lineArray);

		m_row = list.Count;
		m_dataArray = new string[ m_row][];
		for(int i = 0; i < m_row; ++i) {
			// m_dataArray[ i] = new string[];
			m_dataArray[ i] = (lineArray[ i] as string).Split( ',');
		}

		return true;
	}
}
