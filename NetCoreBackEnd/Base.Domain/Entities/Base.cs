using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Domain
{
    public class Base
    {
        public int? UsuarioCadastro { get; set; }
        public int? UsuarioAtualizacao { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public int? Ativo { get; set; }
    }
}
