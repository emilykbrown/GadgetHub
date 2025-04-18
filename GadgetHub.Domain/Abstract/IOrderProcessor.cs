﻿using GadgetHub.Domain.Entities;

namespace GadgetHub.Domain.Abstract
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}