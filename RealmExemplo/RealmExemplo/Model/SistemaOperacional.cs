using System;
using Realms;

namespace RealmExemplo.Model
{
    public class SistemaOperacional : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Versao { get; set; }

    }
}
