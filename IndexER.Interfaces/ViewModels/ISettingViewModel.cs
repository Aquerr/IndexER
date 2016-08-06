using System.Threading.Tasks;

namespace IndexER.Interfaces.ViewModels
{
    public interface ISettingViewModel
    {
        bool Refreshing { get; }
        Task LoadAsync();
    }
}