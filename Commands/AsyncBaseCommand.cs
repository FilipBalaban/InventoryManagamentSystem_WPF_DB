using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagamentSystem_WPF_DB.Commands
{
    public abstract class AsyncBaseCommand : BaseCommand
    {
        private bool _isExecuting;
        private bool IsExecuting
        {
            get => _isExecuting;
            set
            {
                OnCanExecuteChanged(this, new EventArgs());
            }
        }
        public override bool CanExecute(object? parameter)
        {
            return !_isExecuting && base.CanExecute(parameter);
        }
        public override void Execute(object? parameter)
        {
            IsExecuting = true;
            ExecuteAsync(parameter);
            IsExecuting = false;
        }
        /// <summary>
        /// Executes commands functionallity async
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public abstract Task ExecuteAsync(object? parameter);
    }
}
