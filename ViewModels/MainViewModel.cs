namespace AnimationReplicator.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public SceneViewModelBase CurrentScene
        {
            get => _currentScene;
            set => OnPropertyChanged(ref _currentScene, value);
        }
        private SceneViewModelBase _currentScene;

        public MainViewModel()
        {
            CurrentScene = new SplashViewModel();
        }
    }
}
