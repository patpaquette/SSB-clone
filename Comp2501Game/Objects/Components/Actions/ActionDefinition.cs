using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comp2501Game.Objects.Components.Actions
{
    struct ActionDefinition
    {
        public DirectionalAction DirectionalAction;
        public PrimaryAction PrimaryAction;
        public SecondaryAction SecondaryAction;

        public ActionDefinition(
            DirectionalAction dirAction,
            PrimaryAction primaryAction,
            SecondaryAction secondAction
            )
        {
            this.DirectionalAction = dirAction;
            this.PrimaryAction = primaryAction;
            this.SecondaryAction = secondAction;
        }
    }
}
