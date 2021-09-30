using DSCSJsonEditor.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSCSJsonEditor.WPF.Events
{
    public class SelectedStepChangedEventArgs : EventArgs
    {
        public SelectedStepChangedEventArgs(Step oldStep, Step newStep)
        {
            this.OldStep = oldStep;
            this.NewStep = newStep;
        }

        public Step OldStep { get; }

        public Step NewStep { get; }
    }
}
