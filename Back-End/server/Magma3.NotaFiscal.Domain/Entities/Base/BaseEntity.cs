namespace Magma3.NotaFiscal.Domain.Entities.Base
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            UId = Guid.NewGuid();
        }

        public int Id { get; set; }
        public Guid UId { get; set; }
    }
}