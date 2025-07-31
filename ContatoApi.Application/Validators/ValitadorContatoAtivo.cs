using ContatoApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatoApi.Application.Validators
{
    public static class ValidarContato
    {
            public static List<ContatoModel> SomenteAtivos(this List<ContatoModel> contatos)
            {
                return contatos.Where(c => c.Ativo).ToList();
            }
        }
    }

