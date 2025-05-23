﻿namespace Handler.MediatorHandler.MediatorCommand.Carts
{
    public class UpdateCartCommand : IRequest<Cart>
    {

        public int Id { get; set; }
        public string Custom { get; set; }
        public int Size { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public UpdateCartCommand(CartDto cartDto)
        {
            Id = cartDto.Id;
            Custom = cartDto.Custom;
            Size = cartDto.Size;
            Quantity = cartDto.Quantity;
            ProductId = cartDto.ProductId;
            OrderId = cartDto.OrderId;
        }
    }
}
