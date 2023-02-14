using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoAula04.Entities
{
    public class Cliente
    {
        #region Atributos
        private Guid _id;
        private string _nome;
        private string _cpf;
        private Guid _idPlano;
        private string _plano;
        #endregion

        #region Propriedades

        public Guid Id { 
            set => _id = value;
            get => _id;
         }  

        public string? Nome
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Por favor infome o nome do cliente.");

                var regex = new Regex("^[A-Za-zÀ-Üa-ü0-9\\s]{8,150}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Informe um nome válido de 8 a 150 caracteres.");
                
                _nome = value;

            }
            get => _nome;

        }
        public string? Cpf
        {
            set {
                
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("Por favor,  informe o CPF do cliente.");
                var regex = new Regex("^[0-9]{11}$");
                if (!regex.IsMatch(value))
                    throw new ArgumentException("Informe um CPF extamenteo com 11 dígitos.");
                
                _cpf = value;

            }
            get => _cpf;    
        }

        public Guid IdPlano
        {
            set => _idPlano = value;
            get => _idPlano;
        }

        public Plano? Plano
        {
            set => Plano = value; 
            get => Plano;
        }

        #endregion
    }
}
