﻿using SmartoothAI.Domain.Entities;
using SmartoothAI.Domain.Repositories;
using SmartoothAI.Application.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SmartoothAI.Application.Services
{
    public class UsuarioPacienteService
    {
        private readonly IUsuarioPacienteRepository _usuarioPacienteRepository;

        public UsuarioPacienteService(IUsuarioPacienteRepository usuarioPacienteRepository)
        {
            _usuarioPacienteRepository = usuarioPacienteRepository;
        }

        // Método para obter todos os usuários
        public async Task<IEnumerable<UsuarioPaciente>> GetAllAsync()
        {
            return await _usuarioPacienteRepository.GetAllAsync();
        }

        // Método para obter um usuário por ID
        public async Task<UsuarioPaciente> GetByIdAsync(int id)
        {
            return await _usuarioPacienteRepository.GetByIdAsync(id);
        }

        // Método para criar um novo usuário
        public async Task<UsuarioPaciente> CreateAsync(UsuarioPacienteDTO usuarioPacienteDTO)
        {
            var usuarioPaciente = new UsuarioPaciente
            {
                Nome = usuarioPacienteDTO.Nome,
                Sobrenome = usuarioPacienteDTO.Sobrenome,
                Email = usuarioPacienteDTO.Email,
                DataNasc = usuarioPacienteDTO.DataNasc,
                Genero = usuarioPacienteDTO.Genero,
                Cep = usuarioPacienteDTO.Cep,
                Logradouro = usuarioPacienteDTO.Logradouro,
                Numero = usuarioPacienteDTO.Numero,
                Complemento = usuarioPacienteDTO.Complemento,
                Bairro = usuarioPacienteDTO.Bairro,
                Cidade = usuarioPacienteDTO.Cidade,
                Uf = usuarioPacienteDTO.Uf,
                Contato = usuarioPacienteDTO.Contato,
                Pontos = usuarioPacienteDTO.Pontos,
                Descontos = usuarioPacienteDTO.Descontos
            };

            await _usuarioPacienteRepository.AddAsync(usuarioPaciente);
            return usuarioPaciente;
        }

        // Método para atualizar um usuário existente
        public async Task<UsuarioPaciente> UpdateAsync(int id, UsuarioPacienteDTO usuarioPacienteDTO)
        {
            var usuarioPaciente = await _usuarioPacienteRepository.GetByIdAsync(id);
            if (usuarioPaciente == null)
            {
                return null;
            }

            usuarioPaciente.Nome = usuarioPacienteDTO.Nome;
            usuarioPaciente.Sobrenome = usuarioPacienteDTO.Sobrenome;
            usuarioPaciente.Email = usuarioPacienteDTO.Email;
            usuarioPaciente.DataNasc = usuarioPacienteDTO.DataNasc;
            usuarioPaciente.Genero = usuarioPacienteDTO.Genero;
            usuarioPaciente.Cep = usuarioPacienteDTO.Cep;
            usuarioPaciente.Logradouro = usuarioPacienteDTO.Logradouro;
            usuarioPaciente.Numero = usuarioPacienteDTO.Numero;
            usuarioPaciente.Complemento = usuarioPacienteDTO.Complemento;
            usuarioPaciente.Bairro = usuarioPacienteDTO.Bairro;
            usuarioPaciente.Cidade = usuarioPacienteDTO.Cidade;
            usuarioPaciente.Uf = usuarioPacienteDTO.Uf;
            usuarioPaciente.Contato = usuarioPacienteDTO.Contato;
            usuarioPaciente.Pontos = usuarioPacienteDTO.Pontos;
            usuarioPaciente.Descontos = usuarioPacienteDTO.Descontos;

            await _usuarioPacienteRepository.UpdateAsync(usuarioPaciente);
            return usuarioPaciente;
        }

        // Método para excluir um usuário
        public async Task<bool> DeleteAsync(int id)
        {
            var usuarioPaciente = await _usuarioPacienteRepository.GetByIdAsync(id);
            if (usuarioPaciente == null)
            {
                return false;
            }

            await _usuarioPacienteRepository.DeleteAsync(usuarioPaciente);
            return true;
        }
    }
}
