﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRoulette.Model
{
    class Movie
    {
        private string _movieTitel;

        public string MovieTitel
        {
            get { return "Title " + _movieTitel; }
            set { _movieTitel = value; }
        }

        private string _movieDirector;

        public string MovieDirector
        {
            get { return "Director " + _movieDirector; }
            set { _movieDirector = value; }
        }

        private string _genre;

        public string Genre
        {
            get { return "Genre " + _genre; }
            set { _genre = value; }
        }


        private string _dateOfRelease;

        public string DateOfRelase
        {
            get { return "Released " + _dateOfRelease; }
            set { _dateOfRelease = value; }
        }

        public override string ToString()
        {
            // return $" \nTitel: {_movieTitel} \nGenre: {_genre} \nDirector: {_movieDirector} \nReleased: {_dateOfRelease}";
            return $" \n{_movieTitel}";

        }



    }
}
