using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using EditCollection.Commands;
using EditCollection.Models;

namespace EditCollection.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public static readonly DependencyProperty OperationViewsProperty = DependencyProperty.Register(
            "OperationViews", typeof(ObservableCollection<OperationView>), typeof(MainViewModel),
            new PropertyMetadata(default(ObservableCollection<OperationView>)));

        public ObservableCollection<OperationView> OperationViews
        {
            get
            {
                return (ObservableCollection<OperationView>)GetValue(OperationViewsProperty);
            }
            set
            {
                SetValue(OperationViewsProperty, value);
            }
        }

        public static readonly DependencyProperty ViewsCopyProperty = DependencyProperty.Register(
            "ViewsCopy", typeof(ObservableCollection<OperationView>), typeof(MainViewModel), new PropertyMetadata(default(ObservableCollection<OperationView>)));

        public ObservableCollection<OperationView> ViewsCopy
        {
            get
            {
                return (ObservableCollection<OperationView>)GetValue(ViewsCopyProperty);
            }
            set
            {
                SetValue(ViewsCopyProperty, value);
            }
        }

        public static readonly DependencyProperty SelectedViewProperty = DependencyProperty.Register(
            "SelectedView", typeof(OperationView), typeof(MainViewModel), new PropertyMetadata(default(OperationView)));

        public OperationView SelectedView
        {
            get
            {
                return (OperationView)GetValue(SelectedViewProperty);
            }
            set
            {
                SetValue(SelectedViewProperty, value);
            }
        }

        private ICommand _deleteCommand;

        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new DelegateCommand(DeleteItem, () => SelectedView != null);
                }
                return _deleteCommand;
            }
        }
        private ICommand _copyCommand;

        public ICommand CopyCommand
        {
            get
            {
                if (_copyCommand == null)
                {
                    _copyCommand = new DelegateCommand(CopyItem, () => SelectedView != null);
                }
                return _copyCommand;
            }
        }

        private void CopyItem()
        {
            if (ViewsCopy == null)
            {
                ViewsCopy = new ObservableCollection<OperationView>();
            }
            ViewsCopy.Add(SelectedView.Clone());
        }

        private void DeleteItem()
        {
            OperationViews.Remove(SelectedView);
        }

        #region Constructor

        public MainViewModel()
        {
            OperationViews = new ObservableCollection<OperationView>(
                new[]
                {
                    new OperationView
                    {
                        ViewName = "Первый вид",
                        Owner = "Петров",
                        Department = "Второй",
                        Description = "Описание"
                    },
                    new OperationView
                    {
                        ViewName = "Второй вид",
                        Owner = "Сидоров",
                        Department = "Девятый",
                        Description = "Описание"
                    },
                    new OperationView
                    {
                        ViewName = "Третий вид",
                        Owner = "Кузнецов",
                        Department = "Шестой",
                        Description = "Описание"
                    },
                    new OperationView
                    {
                        ViewName = "Четвёртый вид",
                        Owner = "Николаев",
                        Department = "Первый",
                        Description = "Описание",
                        Alarms = "Alarms"
                    },
                    new OperationView
                    {
                        ViewName = "Пятый вид",
                        Owner = "Егоров",
                        Department = "Третий",
                        Description = "Описание"
                    },
                    new OperationView
                    {
                        ViewName = "Шестой вид",
                        Owner = "Семёнов",
                        Department = "Второй",
                        Description = "Описание"
                    },
                });
        }

        #endregion
    }
}