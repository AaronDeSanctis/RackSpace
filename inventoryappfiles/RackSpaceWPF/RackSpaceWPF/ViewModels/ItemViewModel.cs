using RackSpaceWPF.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RackSpaceWPF.ViewModels
{
    class ItemViewModel : ViewModelBase
    {
        ////Change these to my relevant data
        //private string _firstName;
        //My Relevant Data
        //private List<Item> _items = Globals.AllItems;
        //Change these to my relevant data
        //public string FirstName
        //{
        //    get => _firstName;
        //    set => SetProperty(ref _firstName, value);
        //}
        ////My Relevant Data
        //public List<Item> ItemsList
        //{
        //    get => _items;
        //    set => SetProperty(ref _items, value);
        //}
        ////Change these to my relevant data
        //private readonly DelegateCommand _changeNameCommand;

        ////My Relevant Data
        //private readonly DelegateCommand _itemsListChangeCommand;

        ////Change these to my relevant data
        //public ICommand ChangeNameCommand => _changeNameCommand;
        ////My Relevant Data
        //public ICommand ItemsListChangeCommand => _itemsListChangeCommand;

        //public ItemViewModel()
        //{                                           
        //    //Change these to my relevant data
        //    _changeNameCommand = new DelegateCommand(OnChangeName, CanChangeName);
        //    //My Relevant Data
        //    _itemsListChangeCommand = new DelegateCommand(OnItemsListChanged, CanItemsListChange);
        //}

        ////Run Code When Button Is Clicked
        //private void OnChangeName(object commandParameter)
        //{
        //    FirstName = "Walter";
        //    _changeNameCommand.InvokeCanExecuteChanged();
        //}
        ////My Relevant Data
        //private void OnItemsListChanged(object commandParameter)
        //{
        //    //ItemsList = ListItemGrid ???
        //    _itemsListChangeCommand.InvokeCanExecuteChanged();
        //}
        ////Decides If Button Click  Operates or not
        //private bool CanChangeName(object commandParameter)
        //{
        //    return FirstName != "Walter";
        //}
        ////My Relevant Data
        //private bool CanItemsListChange(object commandParameter)
        //{
        //    return FirstName != "Walter";
        //}
        
    }
}
