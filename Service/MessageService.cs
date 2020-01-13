using Dao;
using Service.Dto;
using Service.Mapper;
using System;
using System.Collections.Generic;

namespace Service
{
    public class MessageService
    {
        private MessageDao _dao;

        public MessageService()
        {
            _dao = new MessageDao();
        }

        public ResponseDto<List<MessageDto>> List()
        {
            try
            {
                List<MessageDto> list = new List<MessageDto>();

                foreach (var item in _dao.List()) list.Add(item.toDto());

                return new ResponseDto<List<MessageDto>>()
                {
                    Message = "",
                    Obj = list,
                    Status = Status.Ok
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<MessageDto>>()
                {
                    Message = String.Format("Erro ao listar as mensagens do chat. Msg: {0}", ex.Message),
                    Status = Status.Error
                };
            }

        }

        public ResponseDto<MessageDto> Get(RequestDto<int> request)
        {
            try
            {
                var item = _dao.Get(request.Obj);

                return new ResponseDto<MessageDto>()
                {
                    Status = Status.Ok,
                    Message = "",
                    Obj = item.toDto()
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<MessageDto>()
                {
                    Message = String.Format("Erro ao obter a mensagem. Msg: {0}", ex.Message),
                    Status = Status.Error
                };
            }
        }

        public ResponseDto<string> Insert(RequestDto<MessageDto> request)
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
                    Message = String.Format("Erro ao inserir a mensagem. Msg: {0}", ex.Message),
                    Status = Status.Error
                };
            }
        }

        public ResponseDto<string> Update(RequestDto<MessageDto> request)
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
                    Message = String.Format("Erro ao inserir a mensagem. Msg: {0}", ex.Message),
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
                    Message = String.Format("Erro ao deletar a mensagem. Msg: {0}", ex.Message),
                    Status = Status.Error
                };
            }
        }
    }
}
