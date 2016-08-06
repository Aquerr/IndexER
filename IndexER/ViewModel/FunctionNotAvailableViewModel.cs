using System;
using System.Threading.Tasks;
using IndexER.Client.ViewModel;

namespace IndexER.Client.View
{
    public class FunctionNotAvailableViewModel : TabControlViewModelBase
    {
        private string _functionName;

        public override Task RefreshAsync()
        {
            throw new NotImplementedException();
        }

        public override bool CanRefresh()
        {
            return false;
        }

        public string FunctionName
        {
            get { return _functionName; }
            set
            {
                _functionName = value;
                OnPropertyChanged();
            }
        }
    }
}