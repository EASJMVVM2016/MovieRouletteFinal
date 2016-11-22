using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MovieRoulette.Model;


// next to do; random element prints out all parameters of list. 
// next to do, add button to generate that random selection from the arcive
// split list display and details from movie
// then make it sexy



namespace MovieRoulette.MainViewModel
{
    class MovieViewModel : INotifyPropertyChanged
    {
        public MovieList movieList { get; set; }

        public RelayCommand addCommand { get; set; }
        public RelayCommand removeCommand { get; set; }
        public RelayCommand generateRandomMovieCommand { get; set; }


        private Movie _newMovie;

        public Movie NewMovie
        {
            get { return _newMovie; }
            set { _newMovie = value; }
        }

        private Movie selectedMovie;

        public Movie SelectedMovie
        {
            get
            {
                return selectedMovie;
            }
            set
            {
                selectedMovie = value; OnPropertyChanged(nameof(SelectedMovie));

            }
        }

        private Movie _displayRandomMovie;

        public Movie DisplayRandomMovie
        {
            get { return _displayRandomMovie; }
            set { _displayRandomMovie = value; OnPropertyChanged(nameof(DisplayRandomMovie)); }
        }


        public MovieViewModel()
        {
            movieList = new MovieList();
            selectedMovie = new Movie();
            NewMovie = new Movie();

            addCommand = new RelayCommand(AddNewMovie, null);
            removeCommand = new RelayCommand(RemoveMovie, null);
            generateRandomMovieCommand = new RelayCommand(RandomMovie, null);


        }

        public void RandomMovie()
        {
            Random randomMovie = new Random();
            int listCount = randomMovie.Next(0, movieList.Count);
            DisplayRandomMovie = movieList[listCount];
        }

        public void AddNewMovie()
        {
            movieList.Add(NewMovie);
        }

        public void RemoveMovie()
        {
            movieList.Remove(NewMovie);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }



    }
}
