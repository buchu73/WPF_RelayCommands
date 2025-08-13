using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Remed_RelayCommand.RelayCommand
{
    internal class SimpleRelayCommand : ICommand
    {
        private readonly Action _execute; //une méthode à exécuter quand la commande l'est, pas de parametre d'entrée, ni de retour
        private readonly Func<bool> _canExecute; //une méthode à exécuter quand on le CanExceute l'est, pas de paramètre d'entrée, un bool en retour

        public SimpleRelayCommand(Action execute, Func<bool> canExecute = null) // par défaut canExecute est null, donc optionnel
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        #region Ce qui vient de l'interface ICommand

        // Méthode appelée par le framework, pour vérifier si la commande est exécutable (focus sur le bouton par exemple)
        public bool CanExecute(object? parameter)
        {
            if (_canExecute != null)
            {
                return _canExecute();
            }

            return true; // si pas de _canExecute, on retourne true par défaut
        }

        // Méthode appelée par le framework quand la commande est exécutée (on clique sur le bouton)
        public void Execute(object? parameter)
        {
            _execute();
        }

        // Evenement permettant de déclencher une vérification du CanExecute.
        // Par simplicité, on branche cet évenment sur le CommandManager du framework,
        // qui va déclencher l'évenement sur chaque rafraichissement et changement de focus de l'application 
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #endregion
    }
}
