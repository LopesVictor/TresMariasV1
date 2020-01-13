using Dao;
using Service.Dto;
using Service.Mapper;
using System;
using System.Collections.Generic;

namespace Service
{
    public class RouteService
    {
        private RouteDao _dao;

        public RouteService()
        {
            _dao = new RouteDao();
        }

        public ResponseDto<List<RouteDto>> List()
        {
            try
            {
                List<RouteDto> list = new List<RouteDto>();

                foreach (var item in _dao.List()) list.Add(item.toDto());

                return new ResponseDto<List<RouteDto>>() { 
                    Message = "",
                    Obj = list,
                    Status = Status.Ok                     
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<RouteDto>>()
                {
                    Message = String.Format("erro ao listar as rotas. Msg: {0}", ex.Message),
                    Status = Status.Error
                };
            }
        }

        public ResponseDto<RouteDto> Get(RequestDto<int> request)
        {
            try
            {
                var item = _dao.Get(request.Obj);

                return new ResponseDto<RouteDto>()
                {
                    Status = Status.Ok,
                    Message = "",
                    Obj = item.toDto()
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<RouteDto>()
                {
                    Status = Status.Error,
                    Message = String.Format("Erro ao obter a rota.", ex.Message)
                };
            }
        }

        public ResponseDto<string> Insert(RequestDto<RouteDto> request)
        {
            try
            {
                var entity = request.Obj.toEntity();

                return new ResponseDto<string>()
                {
                    Message = "",
                    Status = Status.Ok,
                    Obj = _dao.Insert(entity).ToString()
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<string>()
                {
                    Message = String.Format("Erro ao inserir a rota. Msg: {0}", ex.Message),
                    Status = Status.Error
                };
            }
        }

        public ResponseDto<string> Update(RequestDto<RouteDto> request)
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
                    Message = String.Format("Erro ao atualizar a rota. Mensagem: {0}", ex.Message)
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
                    Message = String.Format("Erro ao deletar a rota. Mensagem: {0}", ex.Message),
                    Obj = ""
                };
            }
        }
    }
}
