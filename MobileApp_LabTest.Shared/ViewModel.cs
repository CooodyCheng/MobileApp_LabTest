using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Refit;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace MobileApp_LabTest.Shared
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private readonly Service apiService;

        public ViewModel()
        {
            apiService = RestService.For<Service>("https://jsonplaceholder.typicode.com");
            LoadPosts();
        }

        private ObservableCollection<PostRecord> posts;
        public ObservableCollection<PostRecord> Posts
        {
            get => posts;
            set
            {
                posts = value;
                OnPropertyChanged();
            }
        }

        private async Task LoadPosts()
        {
            var result = await apiService.GetPosts();
            Posts = new ObservableCollection<PostRecord>(result);
        }

        // Implement methods for Create, Update, and Delete operations

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
