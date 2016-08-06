using System.Threading.Tasks;

namespace IndexER.Client.ViewModel
{
    public interface ISettingViewModel
    {
        bool Refreshing { get; }
        Task LoadAsync();
    }
}