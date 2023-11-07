package com.example.myapplication

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val btnProject : Button = findViewById(R.id.btnProject)

        btnProject.setOnClickListener {
            val intent = Intent(this@MainActivity,ProjectActivity::class.java)
            startActivity(intent)
        }

    }
}