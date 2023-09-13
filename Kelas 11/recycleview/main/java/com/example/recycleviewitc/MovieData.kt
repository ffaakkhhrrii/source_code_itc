package com.example.recycleviewitc

object MovieData {
    private val title = arrayOf(
        "Cek Toko Sebelah",
        "Dilan 1990",
        "Joker",
        "Money Heist",
        "Parasite"
    )

    private val desc = arrayOf(
        "Cek Toko Sebelah ya iku filem komedi Indonésia prodhuksi Starvision Plus kang dirilis ing 28 Dhésèmbér, 2016 lan disutradarai déning Ernest Prakasa.",
        "Dilan 1990 minangka film drama Indonésia taun 2018. Film iki adhedhasar novel Dilan: Dia is Dilanku Tahun 1990 anggitane Pidi Baiq lan lakon Iqbaal Ramadhan lan Vanesha Prescilla. Para pemain pendukung kalebu Farhan, Ira Wibowo, Tike Priatnakusumah, lan personel grup idola JKT48, Adhisty Zara",
        "Joker adalah film cerita seru psikologis Amerika Serikat tahun 2019 yang disutradarai oleh Todd Phillips dan diproduseri oleh Todd Philips, Bradley Cooper, dan Emma Tillinger Koskoff.",
        "Money Heist (Spanish: La casa de papel, \"The House of Paper\") is a Spanish heist crime drama television series created by Álex Pina.",
        "Parasite inggih punika sesirah filem komedi saking Koréa Kidul taun 2019. Filem punika kaarahaken déning Bong Joon-ho. Juru paraga ingkang kadhapuk sami maragani antawisipun Song Kang-ho, Lee Sun-kyun, Cho Yeo-jeong, Choi Woo-shik lan Park So-dam\n"
    )

    private val image = arrayOf(
        R.drawable.cektokosebelah,
        R.drawable.dilan,
        R.drawable.joker,
        R.drawable.moneyheist,
        R.drawable.parasite
    )

    val listData: ArrayList<Movie>

    get() {
        val list = arrayListOf<Movie>()
        for (position in title.indices){
            val movie = Movie()
            movie.title = title[position]
            movie.desc = desc[position]
            movie.image = image[position]
            list.add(movie)
        }
        return list
    }


}