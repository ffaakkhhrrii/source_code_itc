package com.example.recycleviewitc

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.ImageView
import android.widget.TextView
import com.bumptech.glide.Glide
import com.bumptech.glide.request.RequestOptions

class DetailActivity : AppCompatActivity() {

    companion object{
        const val EXTRA_TITLE = "EXTRA_TITLE"
        const val EXTRA_DESC = "EXTRA_DESC"
        const val EXTRA_IMAGE = "EXTRA_IMAGE"
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_detail)

        val titleDetail: TextView = findViewById(R.id.titleDetail)
        val descDetail: TextView = findViewById(R.id.descDetail)
        val imageDetail: ImageView = findViewById(R.id.imageDetail)

        val title = intent.getStringExtra(EXTRA_TITLE)
        val desc = intent.getStringExtra(EXTRA_DESC)
        val image = intent.getIntExtra(EXTRA_IMAGE,0)

        Glide.with(this)
            .load(image)
            .into(imageDetail)
            .apply { RequestOptions().override(300,300) }

        titleDetail.text = title
        descDetail.text = desc

    }
}