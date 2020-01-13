using Dao;
using Dao.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Service.Dto;
using Service.Mapper;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Service
{
    public class UserService
    {
        private UserDao _dao;

        public UserService()
        {
            _dao = new UserDao();
        }

        public ResponseDto<List<UserDto>> List()
        {
            try
            {

                var list = new List<UserDto>();

                foreach (var item in _dao.List()) list.Add(item.toDto());

                return new ResponseDto<List<UserDto>>()
                {
                    Status = Status.Ok,
                    Obj = list
                };

            }
            catch (Exception ex)
            {
                return new ResponseDto<List<UserDto>>()
                {
                    Status = Status.Error,
                    Message = String.Format("Erro ao listar as categorias. Mensagem: {0}", ex.Message)
                };
            }
        }

        public ResponseDto<UserDto> Get(RequestDto<int> request)
        {
            try
            {
                var item = _dao.Get(request.Obj);

                return new ResponseDto<UserDto>()
                {
                    Status = Status.Ok,
                    Message = "",
                    Obj = item.toDto()
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<UserDto>()
                {
                    Status = Status.Error,
                    Message = "Usuario não encontrado."
                };
            }
        }

        public ResponseDto<string> Insert(RequestDto<UserDto> request)
        {
            try
            {
                var entity = request.Obj.toEntity();

                return new ResponseDto<string>()
                {
                    Status = Status.Ok,
                    Message = "Usuario cadastrado com sucesso.",
                    Obj = _dao.Insert(entity).ToString()
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<string>()
                {
                    Message = String.Format("Erro ao inserir o usuario. Mensagem: {0}", ex.Message),
                    Status = Status.Error
                };
            }
        }

        public ResponseDto<string> Update(RequestDto<UserDto> request)
        {
            try
            {
                var entity = request.Obj.toEntity();

                _dao.Update(entity);

                return new ResponseDto<string>()
                {
                    Status = Status.Ok,
                    Message = string.Empty,
                    Obj = ""
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<string>()
                {
                    Status = Status.Error,
                    Message = String.Format("Erro ao atualizar o usuario. Mensagem: {0}", ex.Message)
                };
            }
        }

        public ResponseDto<string> Delete(RequestDto<int> request)
        {
            try
            {
                _dao.Delete(request.Obj);

                return new ResponseDto<string>()
                {
                    Status = Status.Ok,
                    Message = string.Empty,
                    Obj = ""
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<string>()
                {
                    Status = Status.Error,
                    Message = String.Format("Erro ao deletar o usuario. Mensagem: {0}", ex.Message),
                    Obj = ""
                };
            }
        }
    }
}
