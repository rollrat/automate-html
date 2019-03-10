/* Copyright (C) 2018-2019. rollrat All Rights Reserved. */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace automate_html_gui.Domain
{
    public class HTMLDataGridItemViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int i;
        public int j;

        private string _index;
        public string Index
        {
            get { return _index; }
            set
            {
                if (_index == value) return;
                _index = value;
                OnPropertyChanged();
            }
        }

        private string _depth;
        public string Depth
        {
            get { return _depth; }
            set
            {
                if (_depth == value) return;
                _depth = value;
                OnPropertyChanged();
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _specific;
        public string Content
        {
            get { return _specific; }
            set
            {
                if (_specific == value) return;
                _specific = value;
                OnPropertyChanged();
            }
        }
    }

    public class HTMLDataGridViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<HTMLDataGridItemViewModel> _items;
        public ObservableCollection<HTMLDataGridItemViewModel> Items => _items;

        public HTMLDataGridViewModel(IEnumerable<HTMLDataGridItemViewModel> collection = null)
        {
            if (collection == null)
                _items = new ObservableCollection<HTMLDataGridItemViewModel>();
            else
                _items = new ObservableCollection<HTMLDataGridItemViewModel>(collection);
        }
    }
}
