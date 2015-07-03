﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopManagment.Commands
{
    public class RelayCommand : ICommand
    {
        private Action execute;
        private Func<bool> canExecute; 

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if(this.canExecute == null)
            {
                return true;
            }
            return this.canExecute();
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            this.execute();
        }
    }
}
