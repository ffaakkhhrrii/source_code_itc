package com.example.myapplication

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.bumptech.glide.Glide

class ListCharAdapter(private val listChar: ArrayList<Character>):RecyclerView.Adapter<ListCharAdapter.MyViewHolder>(){
    
    class MyViewHolder(itemView: View):RecyclerView.ViewHolder(itemView) {
        val imageChar: ImageView = itemView.findViewById(R.id.movieImage)
        val nameChar: TextView = itemView.findViewById(R.id.nameCharacter)
        val descriptionChar: TextView = itemView.findViewById(R.id.descCharacter)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): MyViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(R.layout.list_char_item,parent,false)
        return MyViewHolder(view)
    }

    override fun getItemCount(): Int {
        return listChar.size
    }

    override fun onBindViewHolder(holder: MyViewHolder, position: Int) {
        holder.nameChar.text = listChar[position].name
        holder.descriptionChar.text = listChar[position].description

        Glide.with(holder.itemView.context)
            .load(listChar[position].image)
            .into(holder.imageChar)

    }

}

