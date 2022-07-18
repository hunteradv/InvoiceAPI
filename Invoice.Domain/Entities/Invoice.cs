using System.Collections.Generic;

namespace InvoiceApi.Domain.Entities
{
    public class Invoice : Base
    {

        public virtual Client Client { get; private set; }        
        public int ClientId { get; private set; }        
        public int SerialNumber { get; private set; }        
        public int Number { get; private set; }        
        public decimal Total { get; private set; }
        public virtual List<Payment> Payments { get; private set; }
        public virtual List<Item> Items { get; private set; }

        //EF
        public Invoice()
        {

        }

        public Invoice(int clientId, int serialNumber, int number, decimal total)
        {
            ClientId = clientId;
            SerialNumber = serialNumber;
            Number = number;
            Total = total;            
        }

        public override bool Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
