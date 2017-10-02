﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceScript : MonoBehaviour {

	private AudioSource audioSource;
	private float timer = 0f;
	private bool big = false;
	public float scale = 5f;
	private  Rigidbody2D rigidBody2D;
	public float bounceMagnitude = 3.0f;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		rigidBody2D = GameObject.Find("Player").GetComponent<Rigidbody2D>();
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		audioSource.Play();
		if (!big) 
		{
			transform.localScale += new Vector3 (scale, scale, scale);
			//rigidBody2D = col.gameObject.GetComponent<Rigidbody2D>();
			big = true;
		}
	}

	private void Update ()
	{
		if (big)
		{
			if (timer <= 0.3f)
			{
				timer += Time.deltaTime;
				if (rigidBody2D.velocity.magnitude < bounceMagnitude) 
				{
					rigidBody2D.velocity += rigidBody2D.velocity.normalized;
				}
			} 
			else
			{
				timer = 0f;
				transform.localScale -= new Vector3 (scale, scale, scale);
				big = false;
			}
		}
	}
}
