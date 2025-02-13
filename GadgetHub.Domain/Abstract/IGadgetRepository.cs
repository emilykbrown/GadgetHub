using GadgetHub.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GadgetHub.Domain.Abstract
{
    public interface IGadgetRepository
    {
        IEnumerable<Gadget> Gadgets { get; }
    }
}
