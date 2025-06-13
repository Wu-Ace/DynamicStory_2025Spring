//Copyright (c) 2025 Kai Clavier [kaiclavier.com] Do Not Distribute
using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
/*
 * Similar to STMSketchify, but this can be attached to any Unity UI element!
 */
[AddComponentMenu("UI/Effects/Sketchify", 18)]
public class STMSketchifyMeshModifier : BaseMeshEffect 
{
	[Range(0.001f,8f)]
	public float sketchDelay = 0.25f;
	private float _sketchLastTime = -1.0f;
	public float sketchAmount = 1f;
	public bool unscaledTime = true;

	private float _newTime = 0f;
	
	private Vector3[] _storedOffsets = new Vector3[0];
	
	protected override void Awake()
	{
		base.Awake();
		_sketchLastTime = -1f;
	}

	protected void Update()
	{
		//get a limited frame rate
		_newTime = Mathf.Floor((unscaledTime ? Time.unscaledTime : Time.time) / sketchDelay) * sketchDelay;
		if(!(_newTime > _sketchLastTime)) return;
		
		_sketchLastTime = _newTime;
		//update offsets only when the right amount of time has passed
		SketchOffsets();
		
		//set dirty to make ModifyMesh get called. Works with STM and other objects, too!
		this.graphic.SetVerticesDirty();
	}

	private void SketchOffsets()
	{
		//remember offsets
		for(int i=0; i<_storedOffsets.Length; i++)
		{
			_storedOffsets[i].x = Random.Range(-sketchAmount,sketchAmount);
			_storedOffsets[i].y = Random.Range(-sketchAmount,sketchAmount);
			_storedOffsets[i].z = Random.Range(-sketchAmount,sketchAmount);
		}
	}
	public override void ModifyMesh(VertexHelper vh)
	{
		if (!this.IsActive())
			return;
		//fill array for first time, or if length of verts change
		if(_storedOffsets.Length != vh.currentVertCount)
		{
			Array.Resize(ref _storedOffsets, vh.currentVertCount); //resize array
			SketchOffsets(); //immediately apply effect in this situation
		}
		
		//and then apply offsets to verts!
		var vertex = new UIVertex();
		for (var i = 0; i < vh.currentVertCount; ++i)
		{
			//set UI vertex information from the vertexHelper.
			vh.PopulateUIVertex(ref vertex, i);
			//Apply offsets
			vertex.position.x += _storedOffsets[i].x;
			vertex.position.y += _storedOffsets[i].y;
			vertex.position.z += _storedOffsets[i].z;
			//Set modified value back to vertexHelper.
			vh.SetUIVertex(vertex, i);
		}
	}
}
