using Entities;
using Service.Dto;

namespace Service.Mapper
{
    public static class Mapper
    {
        public static UserDto toDto(this User obj)
        {
            return new UserDto()
            {
                Id = obj.Id,
                Nome = obj.Nome,
                Cadastro = obj.Cadastro
            };
        }

        public static User toEntity(this UserDto obj)
        {
            return new User()
            {
                Id = obj.Id,
                Nome = obj.Nome,
                Cadastro = obj.Cadastro
            };
        }

        public static ChatDto toDto(this Chat obj)
        {
            return new ChatDto()
            {
                Id = obj.Id,
                userFrom = obj.userFrom.toDto(),
                userTo = obj.userTo.toDto(),
                CreatedAt = obj.CreatedAt
            };
        }

        public static Chat toEntity(this ChatDto obj)
        {
            return new Chat()
            {
                Id = obj.Id,
                userFrom = obj.userFrom.toEntity(),
                userTo = obj.userTo.toEntity(),
                CreatedAt = obj.CreatedAt
            };
        }

        public static MessageDto toDto(this Message obj)
        {
            return new MessageDto()
            {
                Id = obj.Id,
                User = obj.User.toDto(),
                Chat = obj.Chat.toDto(),
                Text = obj.Text
            };
        }

        public static Message toEntity(this MessageDto obj)
        {
            return new Message()
            {
                Id = obj.Id,
                User = obj.User.toEntity(),
                Chat = obj.Chat.toEntity(),
                Text = obj.Text
            };
        }

        public static RouteDto toDto(this Route obj)
        {
            return new RouteDto()
            {
                CreatedAt = obj.CreatedAt,
                Destination = obj.Destination,
                Origin = obj.Origin,
                User = obj.User.toDto(),
                Id = obj.Id
            };
        }

        public static Route toEntity(this RouteDto obj)
        {
            return new Route()
            {
                CreatedAt = obj.CreatedAt,
                Destination = obj.Destination,
                Origin = obj.Origin,
                User = obj.User.toEntity(),
                Id = obj.Id
            };
        }
    }
}
