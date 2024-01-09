package com.example.myapplication

object DataCharacter {

    private val name = arrayOf(
        "Park Hyung Seok",
        "Park Jong Geon",
        "Kim Joon Goo",
        "Choi Soo Jung",
        "Kim Miru",
        "Lee Ji Hoon (Puncak)"
    )

    private val gender = arrayOf(
        "Male",
        "Male",
        "Male",
        "Female",
        "Female",
        "Male"
    )

    private val debut = arrayOf(
        "Chapter 1",
        "Chapter 25",
        "Chapter 55",
        "Chapter 58",
        "Chapter 21",
        "Chapter 49"
    )

    private val description = arrayOf(
        "Park Hyung-Seok is the main protagonist of Lookism. He is a student at J High School's Fashion Department. As a former victim of the Lookism he was judged and mocked due to his unconventional appearance until one fateful day he found himself in a perfect Alternative body. He found himself being capable of transferring his consciousness between two bodies at will, thus starting the story of Lookism. Currently, he is the crew head of Allied, with the goal being the downfall of the Workers, the last of the Four Major Crews still standing.",
        "\"Park Jong Geon is a major character in Lookism. He is a fighter of legendary status and the personal bodyguard of the HNH Chairman's daughter, Crystal Choi. He is also one of the \"10 Geniuses\" raised by Charles Choi and one of the three children trained by Tom Lee.\"",
        "Kim Joon Goo is a supporting character and an antagonist in Lookism. He is Charles Choi's bodyguard, the debt collector for the HNH Group's illegal money, one of the ten talented individuals raised by the HNH chairman, and one of the three kids trained by Tom Lee.",
        "Choi Soo Jung) is a secondary character in Lookism. She is currently a student in J High School. Like Daniel Park, she also has two bodies. At some point, Crystal was trained by Jong Gun on how to fight and is fully capable of taking care of herself.",
        "Mary Kim is extremely beautiful and tall for the average Korean woman. Having the height of 165 cm, she is taller than Mira Kim and Crystal Choi. Her complexity shows that she has pale skin, dark blue eyes, and an hour-glass figure. Her hair is bleached blonde and is later permed.",
        "Kang Dagyum is a famous Korean idol and also the head of PTJ Entertainment, an idol training agency. He is one of Charles Choi's Ten Geniuses and has close ties with him. He used to be known as James Lee but discarded this identity. He is known as the legend of the 1st generation."
    )

    private val image = intArrayOf(
        R.drawable.phs,
        R.drawable.jonggun,
        R.drawable.junggo,
        R.drawable.crystal,
        R.drawable.miru,
        R.drawable.puncak
    )

    val listChar: ArrayList<Character>
        get() {
            val list = arrayListOf<Character>()
            for (position in name.indices){
                val char = Character()
                char.name = name[position]
                char.gender = gender[position]
                char.debut = debut[position]
                char.description = description[position]
                char.image = image[position]
                list.add(char)
            }
            return list
        }

}