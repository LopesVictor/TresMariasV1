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
    public class ChatService
    {
        private ChatDao _dao;

        public ChatService()
        {
            _dao = new ChatDao();
        }

        public ChatService(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)
            );
        }

        public ResponseDto<List<ChatDto>> List()
        {
            try
            {
                List<ChatDto> list = new List<ChatDto>();

                foreach (var item in _dao.List()) list.Add(item.toDto());

                return new ResponseDto<List<ChatDto>>()
                {
                    Message = "",
                    Status = Status.Ok,
                    Obj = list
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<ChatDto>>()
                {
                    Message = String.Format("Erro ao listar chat. Msg: {0}", ex.Message),
                    Status = Status.Error
                };
            }
        }

        public ResponseDto<ChatDto> Get(RequestDto<int> request)
        {
            try
            {
                var item = _dao.Get(request.Obj);

                return new ResponseDto<ChatDto>()
                {
                    Status = Status.Ok,
                    Message = "",
                    Obj = item.toDto()
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<ChatDto>()
                {
                    Message = String.Format("Erro ao obter o chat. Msg: {0}", ex.Message),
                    Status = Status.Error
                };
            }
        }

        public ResponseDto<string> Insert(RequestDto<ChatDto> request)
        {
            try
            {
                var entity = request.Obj.toEntity();

                return new ResponseDto<string>()
                {
                    Message = "",
                    Obj = _dao.Insert(entity).ToString(),
                    Status = Status.Ok
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<string>()
                {
                    Message = String.Format("Erro ao inserir o chat. Msg: {0}", ex.Message),
                    Status = Status.Error
                };
            }
        }

        public ResponseDto<string> Update(RequestDto<ChatDto> request)
        {
            try
            {
                var entity = request.Obj.toEntity();

                _dao.Update(entity);

                return new ResponseDto<string>()
                {
                    Message = "",
                    Status = Status.Ok
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<string>()
                {
                    Message = String.Format("Erro ao inserir o chat. Msg: {0}", ex.Message),
                    Status = Status.Error
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
                    Message = "",
                    Status = Status.Ok
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<string>()
                {
                    Message = String.Format("Erro ao atualizar o chat. Msg: {0}", ex.Message),
                    Status = Status.Error
                };
            }
        }
    }
}
