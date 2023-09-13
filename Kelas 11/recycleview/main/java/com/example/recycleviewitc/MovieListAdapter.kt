package com.example.recycleviewitc

import android.content.Intent
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.TextView
import androidx.appcompat.view.menu.ActionMenuItemView
import androidx.recyclerview.widget.RecyclerView
import androidx.recyclerview.widget.RecyclerView.ViewHolder
import com.bumptech.glide.Glide
import com.bumptech.glide.request.RequestOptions

class MovieListAdapter(private val listData :  ArrayList<Movie>): RecyclerView.Adapter<MovieListAdapter.MovieViewHolder>() {

    class MovieViewHolder(itemView: View):RecyclerView.ViewHolder(itemView) {
        val title: TextView = itemView.findViewById(R.id.movieTitle)
        val desc: TextView = itemView.findViewById(R.id.movieDesc)
        val image: ImageView = itemView.findViewById(R.id.movieImage)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): MovieViewHolder {
        val view: View = LayoutInflater.from(parent.context).inflate(R.layout.item_movie,parent,false)
        return MovieViewHolder(view)
    }

    override fun getItemCount(): Int {
        return listData.size
    }

    override fun onBindViewHolder(holder: MovieViewHolder, position: Int) {
        val movie = listData[position]
        val mContext = holder.itemView.context
        Glide.with(holder.itemView.context)
            .load(movie.image)
            .apply { RequestOptions().override(100,100) }
            .into(holder.image)

        holder.title.text = movie.title
        holder.desc.text = movie.desc

        holder.itemView.setOnClickListener{
            val detail = Intent(mContext,DetailActivity::class.java)
            detail.putExtra(DetailActivity.EXTRA_TITLE,movie.title)
            detail.putExtra(DetailActivity.EXTRA_DESC,movie.desc)
            detail.putExtra(DetailActivity.EXTRA_IMAGE,movie.image)
            mContext.startActivity(detail)
        }
    }
}