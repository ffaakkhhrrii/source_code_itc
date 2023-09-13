package com.example.recycleviewitc

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView

class MainActivity : AppCompatActivity() {

private lateinit var recyclerView: RecyclerView
private val listData:ArrayList<Movie> = arrayListOf()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        recyclerView = findViewById(R.id.rvHero)
        recyclerView.setHasFixedSize(true)

        showRecycle()

    }

    private fun showRecycle() {
        recyclerView.layoutManager = LinearLayoutManager(this)
        val movieAdapter = MovieListAdapter(listData)
        recyclerView.adapter = movieAdapter
        listData.addAll(MovieData.listData)
    }

    /**private fun showRecycle(){
        rvMovie.layoutManager = LinearLayoutManager(this)
        val movieAdapter = MovieListAdapter(list)
        rvMovie.adapter = movieAdapter
        list.addAll(MovieData.listData)
    }**/
}