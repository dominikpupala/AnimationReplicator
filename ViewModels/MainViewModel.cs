using System.Windows.Input;

using AnimationReplicator.Commands;

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

        public string TestInput
        {
            get => _testInput;
            set => OnPropertyChanged(ref _testInput, value);
        }
        private string _testInput;

        public ICommand ReloadCommand { get; }

        public MainViewModel()
        {
            CurrentScene = new SplashViewModel();
            TestInput = @"C:\Users\Yoru\Desktop\Rat.png";

            ReloadCommand = new RelayCommand(() => { CurrentScene = new TestViewModel(); });
        }
    }
}
