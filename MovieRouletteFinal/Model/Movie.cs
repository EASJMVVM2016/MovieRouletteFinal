using System;
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
            get { return _movieTitel; }
            set { _movieTitel = value; }
        }

        private string _movieDirector;

        public string MovieDirector
        {
            get { return _movieDirector; }
            set { _movieDirector = value; }
        }

        private string _genre;

        public string Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }


        private string _dateOfRelease;

        public string DateOfRelase
        {
            get { return "" + _dateOfRelease; } // just makes sure that doest crash on empty release field, since the string is never null, aka empty, but it wont mess with the code that checks for numbers in the string.
            set { _dateOfRelease = value; }
        }

        public override string ToString()
        {
            // return $" \nTitel: {_movieTitel} \nGenre: {_genre} \nDirector: {_movieDirector} \nReleased: {_dateOfRelease}";
            return $" \n{_movieTitel}";

        }



    }
}
