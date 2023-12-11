using ProgramacaoDoZero.Common;
using ProgramacaoDoZero.Entities;
using ProgramacaoDoZero.Models;
using ProgramacaoDoZero.Repositories;
using System;

namespace ProgramacaoDoZero.Services
{
    public class UsuarioService
    {
        private string _connectionString;
        public UsuarioService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public LoginResult Login(string email, string senha)
        {
            var result = new LoginResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario == null)
            {
                result.sucesso = false;
                result.mensagem = "Usuário ou senha inválidos";
            }
            else
            {
                if (usuario.Senha == senha)
                {
                    result.sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else
                {
                    result.sucesso = false;
                    result.mensagem = "Usuário ou senha inválidos";
                }
            }

            return result;
        }

        public CadastroResult Cadastro(string nome,
            string sobrenome,
            string telefone,
            string email,
            string genero,
            string senha)
        {
            var result = new CadastroResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario != null)
            {
                result.sucesso = false;
                result.mensagem = "Usuário já existe";
            }
            else
            {

                usuario = new Usuario();
                usuario.Nome = nome;
                usuario.Sobrenome = sobrenome;
                usuario.Telefone = telefone;
                usuario.Email = email;
                usuario.Genero = genero;
                usuario.Senha = senha;
                usuario.UsuarioGuid = Guid.NewGuid();

                var insertResult = usuarioRepository.Inserir(usuario);

                if (insertResult > 0)
                {
                    result.sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else
                {
                    result.sucesso = false;
                    result.mensagem = "Erro ao inserir o usuário. Tente novamente";
                }
            }
            return result;
        }

        public EsqueceuSenhaResult EsqueceuSenha(string email)
        {
            var result = new EsqueceuSenhaResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario == null)
            {
               
                result.sucesso = false;
                result.mensagem = "Usuário não existe para esse email";
            }
            else
            {
                
                var assunto = "Recuperação de senha";
                var corpo = "Sua senha é " + usuario.Senha;

                var emailSender = new EmailSender();

                emailSender.Enviar(assunto, corpo, usuario.Email);
            }

            return result;
        }

        public Usuario ObterUsuario(Guid usuarioGuid)
        {
            var usuario = new UsuarioRepository(_connectionString).ObterPorGuid(usuarioGuid);

            return usuario;
        }
    }
}
