using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MovieRoulette.Model;
using Windows.Storage;
using Newtonsoft.Json;
using Windows.UI.Popups;




// next to do; random element prints out all parameters of list. 
// next to do, add button to generate that random selection from the arcive
// split list display and details from movie
// then make it sexy



namespace MovieRoulette.MainViewModel
{
    class MovieViewModel : INotifyPropertyChanged
    {
        
        
        const string fileName = "SavedArchive.txt";
        
        public RelayCommand addCommand { get; set; }
        public RelayCommand removeCommand { get; set; }
        public RelayCommand generateRandomMovieCommand { get; set; }
        public RelayCommand saveArchive { get; set; }
        public RelayCommand openArchive { get; set; }

        private MovieList movieList;
        public MovieList MovieList
        {
            get { return movieList; }
            set { movieList = value; OnPropertyChanged(nameof(MovieList)); }
        }


        private Movie newMovie;
        public Movie NewMovie
        {
            get { return newMovie; }
            set { newMovie = value; }
        }


        private Movie selectedMovie;
        public Movie SelectedMovie
        {
            get { return selectedMovie; }
            set { selectedMovie = value; OnPropertyChanged(nameof(SelectedMovie)); }
        }


        private Movie displayRandomMovie;
        public Movie DisplayRandomMovie
        {
            get { return displayRandomMovie; }
            set { displayRandomMovie = value; OnPropertyChanged(nameof(DisplayRandomMovie)); }
        }


        public MovieViewModel()
        {
            MovieList = new MovieList();

            selectedMovie = new Movie();
            NewMovie = new Movie();

            addCommand = new RelayCommand(AddNewMovie, null);
            removeCommand = new RelayCommand(RemoveMovie, null);
            generateRandomMovieCommand = new RelayCommand(RandomMovie, null);
            saveArchive = new RelayCommand(SaveArchive, null);
            openArchive = new RelayCommand(OpenArchive, null);

        }

        
        public void RandomMovie()
        {
            if (movieList.Count == 0)
            {
            }
            else
            {
                Random randomMovie = new Random();
                int listCount = randomMovie.Next(0, MovieList.Count);
                DisplayRandomMovie = movieList[listCount];
                SelectedMovie = DisplayRandomMovie;
                
        }
    }


        public void AddNewMovie()
        {
            Movie tempMovie = new Movie();
            tempMovie.MovieTitel = NewMovie.MovieTitel;
            tempMovie.Genre = NewMovie.Genre;
            tempMovie.DateOfRelase = NewMovie.DateOfRelase;
            tempMovie.MovieDirector = NewMovie.MovieDirector;

            movieList.Add(tempMovie);
        }


        public void RemoveMovie()
        {
            movieList.Remove(SelectedMovie);
        }


        public async void SaveArchive()
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, 
                                                                           CreationCollisionOption.ReplaceExisting);
            string JsonData = JsonConvert.SerializeObject(movieList);
             await FileIO.WriteTextAsync(localFile, JsonData);
        }


        public async void OpenArchive()
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                string JsonData = await FileIO.ReadTextAsync(localFile);
                MovieList = JsonConvert.DeserializeObject<MovieList>(JsonData);

            }
            catch (Exception)
            {
                MessageDialog noArchive = new MessageDialog("No Saved Archive");
                noArchive.Commands.Add(new UICommand { Label = "Ok"});
                await noArchive.ShowAsync();
                                                
            }

            
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }



    }
}
