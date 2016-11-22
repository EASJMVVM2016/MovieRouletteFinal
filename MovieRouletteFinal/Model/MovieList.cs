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
            this.Add(new Movie() { MovieTitel = "Shogun Assassin", MovieDirector = "Robert Houston", Genre = "Samurai Sword Flicks", DateOfRelase = "1980" });
            this.Add(new Movie() { MovieTitel = "Big Trouble in Little China Town", MovieDirector = "John Carpenter", Genre = "Action", DateOfRelase = "1986" });
            this.Add(new Movie() { MovieTitel = "Trolls 2", MovieDirector = "Claudio Fragasso", Genre = "Cult Movie", DateOfRelase = "1990" });
            this.Add(new Movie() { MovieTitel = "Cyborg Nemesis", MovieDirector = "Albert Pyun", Genre = "Sci-fi Action", DateOfRelase = "1989" });

        }


    }
}
