using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrzepisyV2.ViewModels
{
    public class RecipeDetailsFormViewModel : ViewModelBase
    {
		private string _name;
		public string Name
		{
			get 
			{ 
				return _name; 
			}
			set 
			{ 
				_name = value;
				OnPropertyChanged(nameof(Name));
			}
		}

        private string _category;
        public string Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        private string _description;


        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public RecipeDetailsFormViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }

    }
}
