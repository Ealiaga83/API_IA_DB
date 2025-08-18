namespace API_IA_DB.Modelo
{
    public class RegistrarFactura
    {
        // Empresa
        public string EmpresaNombreComercial { get; set; }
        public string EmpresaRazonSocial { get; set; }
        public string EmpresaRuc { get; set; }
        public string EmpresaContribuyenteEspecial { get; set; }
        public bool EmpresaObligadoContabilidad { get; set; }
        public string EmpresaDireccionMatriz { get; set; }
        public string EmpresaDireccionSucursal { get; set; }

        // Cliente
        public string ClienteNombre { get; set; }
        public string ClienteIdentificacion { get; set; }
        public string ClienteCorreo { get; set; }

        // Factura
        public string NumeroFactura { get; set; }
        public string NumeroAutorizacion { get; set; }
        public string ClaveAcceso { get; set; }

        // Cambiado a string (llegan como texto)
        public string FechaEmision { get; set; }
        public string HoraAutorizacion { get; set; }

        public string Ambiente { get; set; }
        public string Emision { get; set; }
        public string PlacaMatricula { get; set; }

        // JSONs como string
        public string Detalles { get; set; }
        public string Totales { get; set; }
        public string FormasPago { get; set; }
        public string JsonFactura { get; set; }
    }
}
