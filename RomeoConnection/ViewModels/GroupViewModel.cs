using System.Collections.Generic;
using RomeoConnection.Models;

namespace RomeoConnection.ViewModels
{
    public class GroupViewModel
    {
        public IEnumerable<Group> Groups { get; set; }
        public bool ShowActions { get; set; }
    }
}