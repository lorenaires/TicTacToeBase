using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeBase
{
    public class Usuario : ICloneable, IEquatable<Usuario>
    {
        public int IdUsuario { get; private set; }
        
        private string NomeCompleto { get; set; }

        private string Email { get; set; }
        
        private DateTime DataNascimento { get; set; }

        public string NomeUsuario { get; private set; }
        
        private string Senha { get; set; }
        
        private Dictionary<int, string> ListaAmigos { get; set; }
        
        private int Vitorias { get; set; }
        
        private int Derrotas { get; set; }
        
        private int Empates { get; set; }
        
        private string Status { get; set; }

        public Usuario(int idUsuario, string nomeCompleto, string email, DateTime dataNascimento, string nomeUsuario, string senha)
        {
            this.IdUsuario = idUsuario;
         
            this.NomeCompleto = nomeCompleto;
            
            this.Email = email;
            
            this.DataNascimento = dataNascimento;
            
            this.NomeUsuario = nomeUsuario;
            
            this.Senha = senha;
            
            this.ListaAmigos = new Dictionary<int, string>();
            
            this.Vitorias = 0;
            
            this.Derrotas = 0;
            
            this.Empates = 0;
            
            this.Status = "";
        }

        public string RetornaNomeCompleto(string senha)
        {
            if (ValidaSenha(senha))
            {
                return this.NomeCompleto;
            }
            else
            {
                return null;
            }
        }

        public string RetornaEmail(string senha)
        {
            if (ValidaSenha(senha))
            {
                return this.Email;
            }
            else
            {
                return null;
            }
        }

        public DateTime RetornaDataNascimento(string senha)
        {
            if (ValidaSenha(senha))
            {
                return this.DataNascimento;
            }
            else
            {
                return new DateTime(1,1,1);
            }
        }

        public string RetornaNomeUsuario()
        {
            return this.NomeUsuario;
        }

        public Dictionary<int, string> RetornaListaAmigos(string senha)
        {
            if (ValidaSenha(senha))
            {
                var listaRetorno = new Dictionary<int, string>();

                for (int contador = 0; contador < this.ListaAmigos.Count; contador++)
                {
                    listaRetorno.Add(this.ListaAmigos.ElementAt(contador).Key, this.ListaAmigos.ElementAt(contador).Value);
                }
                
                return listaRetorno;
            }
            else
            {
                return null;
            }
        }
         
        public int RetornaVitorias(string senha)
        {
            if (ValidaSenha(senha))
            {
                return this.Vitorias;
            }
            else
            {
                return -1;
            }
        }

        public int RetornaDerrotas(string senha)
        {
            if (ValidaSenha(senha))
            {
                return this.Derrotas;
            }
            else
            {
                return -1;
            }
        }

        public int RetornaEmpates(string senha)
        {
            if (ValidaSenha(senha))
            {
                return this.Empates;
            }
            else
            {
                return -1;
            }
        }

        public string RetornaStatus(string senha)
        {
            if (ValidaSenha(senha))
            {
                return this.Status;
            }
            else
            {
                return null;
            }
        }
                
        public bool ValidaSenha(string senha)
        {
            if (senha == this.Senha)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveAmigo(int idUsuario, string senha)
        {
            if(ValidaSenha(senha)) {
                this.ListaAmigos.Remove(idUsuario);
            }
        }

        public bool AdicionaAmigo(int idUsuario, string nomeUsuario, string senha)
        {
            if (ValidaSenha(senha))
            {
                this.ListaAmigos.Add(idUsuario, nomeUsuario);

                return true;

            } else {
                return false;
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public bool Equals(Usuario outro)
        {
            if (outro != null)
            {
                return (this.NomeUsuario.Equals(outro.NomeUsuario) && this.IdUsuario.Equals(outro.IdUsuario));
            } 
            else {
                return false;
            }
            
        }
    }
}
