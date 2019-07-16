using Dolittle.Commands;
using System;

namespace Domain.Alerts
{
    public class CloseAlert : ICommand
    {
        public int AlertNumber { get; set; }
    }
}
