using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using IndexER.Logic.Entities;

namespace IndexER.Interfaces.ViewModels
{
    public interface ISettingViewModel
    {
        bool Refreshing { get; }
        Task LoadAsync();
      //  ObservableCollection<Class> Classes { get; }
      //  Task<List<Class>> GetClassesAsync();
    }
}