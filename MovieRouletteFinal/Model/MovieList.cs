using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MovieRoulette.Model
{
    class MovieList : ObservableCollection<Movie>
    {
        public MovieList() : base()
        {
           // this.Add(new Movie() { MovieTitel = "Shogun Assassin", MovieDirector = "Robert Houston", Genre = "Samurai Sword Flicks", DateOfRelase = "1980" });

        }


    }
}
