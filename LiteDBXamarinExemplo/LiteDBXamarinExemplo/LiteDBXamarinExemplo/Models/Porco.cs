using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;

namespace LiteDBXamarinExemplo.Models
{
    public class Porco
    {
        [BsonId]
        public int id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string[] Apelidos { get; set; }
        public bool VirouBacon { get; set; }
    }
}
