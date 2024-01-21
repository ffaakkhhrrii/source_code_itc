package com.example.myapplication

import android.content.Intent
import android.net.Uri
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.Toast
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView

class ProjectActivity : AppCompatActivity() {

    private lateinit var rv : RecyclerView
    private val list : ArrayList<Character> = arrayListOf()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_project)

        list.addAll(DataCharacter.listChar)
        rv = findViewById(R.id.myRv)
        rv.setHasFixedSize(true)

        val layoutManager = LinearLayoutManager(this)
        rv.layoutManager = layoutManager
        val adapter = ListCharAdapter(list)
        rv.adapter = adapter

    }
}