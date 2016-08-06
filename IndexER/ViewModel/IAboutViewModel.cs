using System.Threading.Tasks;

namespace IndexER.Client.ViewModel
{
    public interface IAboutViewModel
    {
        bool Refreshing { get; }
        Task LoadAsync();
    }
}