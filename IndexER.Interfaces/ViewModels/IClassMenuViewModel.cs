using System.Threading.Tasks;

namespace IndexER.Interfaces.ViewModels
{
    public interface IClassMenuViewModel
    {
        bool Refreshing { get; }
        Task LoadAsync();
    }
}