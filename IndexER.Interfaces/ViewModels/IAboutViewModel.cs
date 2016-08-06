using System.Threading.Tasks;

namespace IndexER.Interfaces.ViewModels
{
    public interface IAboutViewModel
    {
        bool Refreshing { get; }
        Task LoadAsync();
    }
}