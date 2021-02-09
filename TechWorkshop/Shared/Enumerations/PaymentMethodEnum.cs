using InmobiliariaDashboard.Shared.Enumerations;

namespace TechWorkshop.Shared.Enumerations
{
    public class PaymentMethodEnum : BaseEnumeration
    {
        public static readonly PaymentMethodEnum Cash = new PaymentMethodEnum(1, "E", "Efectivo");
        public static readonly PaymentMethodEnum Card = new PaymentMethodEnum(2, "T", "Tarjeta");
        public static readonly PaymentMethodEnum Transference = new PaymentMethodEnum(3, "TR", "Transferencia");
        public static readonly PaymentMethodEnum Other = new PaymentMethodEnum(4, "X", "Otro");

        public PaymentMethodEnum() { }
        public PaymentMethodEnum(int id, string code, string name)
            : base(id, code, name)
        {
        }
    }
}