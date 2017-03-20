using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using EditCollection.Commands;
using EditCollection.Models;

namespace EditCollection.Views
{
    /// <summary>
    /// Контрол для отображения коллекции
    /// </summary>
    public partial class CollectionViewer : UserControl
    {
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
            "ItemsSource", typeof(ObservableCollection<OperationView>), typeof(CollectionViewer), new PropertyMetadata(default(ObservableCollection<OperationView>)));
        
        public ObservableCollection<OperationView> ItemsSource
        {
            get
            {
                return (ObservableCollection<OperationView>)GetValue(ItemsSourceProperty);
            }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
            "SelectedItem", typeof(OperationView), typeof(CollectionViewer), new PropertyMetadata(default(OperationView)));

        public OperationView SelectedItem
        {
            get
            {
                return (OperationView)GetValue(SelectedItemProperty);
            }
            set
            {
                SetValue(SelectedItemProperty, value);
            }
        }

        public static readonly DependencyProperty EditModeProperty = DependencyProperty.Register(
            "EditMode", typeof(bool), typeof(CollectionViewer), new PropertyMetadata(false));

        //Режим отображения списка
        public bool EditMode
        {
            get
            {
                return (bool)GetValue(EditModeProperty);
            }
            set
            {
                SetValue(EditModeProperty, value);
            }
        }

        private ICommand _deleteCommand;

        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new DelegateCommand<OperationView>(DeleteItem, (item) => ItemsSource != null && ItemsSource.Count > 0);
                }
                return _deleteCommand;
            }
        }

        private ICommand _enterEditModeCommand;

        public ICommand EnterEditModeCommand
        {
            get
            {
                if (_enterEditModeCommand == null)
                {
                    _enterEditModeCommand = new DelegateCommand(() => EditMode = true);
                }
                return _enterEditModeCommand;
            }
        }

        private ICommand _exitEditModeCommand;

        public ICommand ExitEditModeCommand
        {
            get
            {
                if (_exitEditModeCommand == null)
                {
                    _exitEditModeCommand = new DelegateCommand(() => EditMode = false);
                }
                return _exitEditModeCommand;
            }
        }

        private void DeleteItem(OperationView item)
        {
            ItemsSource.Remove(item);
        }
        
        public CollectionViewer()
        {
            InitializeComponent();
        }
    }
}
