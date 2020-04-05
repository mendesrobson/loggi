using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Models
{
    public class Pedidos
    {
        public int IdLoja { get; set; }//shopId
        public string ChaveRastreamento { get; set; }//trackingkey
        public Destinatarios Destinatario { get; set; } //pickups
        public Pacotes Pacotes { get; set; } //packages
    }

    public class Destinatarios
    {
        public Enderecos Endereco { get; set; }//address
    }
    public class Pacotes
    {
        public int IdPacote { get; set; } //pickupIndex
        public Clientes Cliente { get; set; }  //recipient
        public Enderecos Endereco { get; set; }//address
        public Pagamentos Pagamento { get; set; }//charge
    }

    public class Enderecos
    {
        public float Latitude { get; set; }//lat
        public float Longitude { get; set; } //lng
        public string Endereco { get; set; }//address
        public string Complemento { get; set; }//complement
    }

    public class Clientes
    {
        public string Nome { get; set; }//client
        public string Telefone { get; set; }//phone
    }

    public class Pagamentos
    {
        public string Valor { get; set; }//value
        public int Metodo { get; set; }//method
        public string Troco { get; set; }//change
    }

    public class Dimensoes
    {
        public int Largura { get; set; }//width
        public int Altura { get; set; } //height
        public int Comprimento { get; set; }//length
    }
}
