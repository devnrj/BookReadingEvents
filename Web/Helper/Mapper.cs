using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Models;
using Web.Models;

namespace Web.Helper
{
    public static class Mapper
    {
        public static MapperConfiguration config = new MapperConfiguration(cfg =>
           cfg.CreateMap<UserDto, UserViewModel>().ReverseMap());

        private static IMapper mapper = config.CreateMapper();
        public static CommentViewModel ToCommentViewModel(CommentDto commentDto)
        {
            return mapper.Map<CommentViewModel>(commentDto);
        }
        public static List<CommentViewModel> ToCommentViewModelList(List<CommentDto> comments)
        {
            return mapper.Map<List<CommentViewModel>>(comments);
        }
        public static EventViewModel ToEventViewModel(EventDto eventDto)
        {
            config = new MapperConfiguration(cfg => cfg.CreateMap<EventDto, EventViewModel>().
                                             ForMember(t => t.Invites, opt => opt.Ignore()));

            return config.CreateMapper().Map<EventViewModel>(eventDto);
        }

        public static EventDto ToEventDto(EventViewModel evm)
        {
            return mapper.Map<EventDto>(evm);
        }

        public static List<EventViewModel> ToEventViewModelList(List<EventDto> events)
        {
            config = new MapperConfiguration(cfg => cfg.CreateMap<EventDto, EventViewModel>().
                                             ForMember(t => t.Invites, opt => opt.Ignore()));
            return config.CreateMapper().Map<List<EventViewModel>>(events);
        }

        public static UserViewModel ToUserViewModel(UserDto udto)
        {
           
            return mapper.Map<UserViewModel>(udto);
        }

        public static UserDto ToUserDto(UserViewModel User)
        {
            return mapper.Map<UserDto>(User);
        }

        public static UserAccountDto ToUserAccountDto(UserAccountViewModel User)
        {
            return mapper.Map<UserAccountDto>(User);
        }

        public static List<UserDto> ToUserDtoList(List<UserViewModel> userEntities)
        {
            return mapper.Map<List<UserDto>>(userEntities);
        }

        public static List<UserViewModel> ToUserViewModelList(List<UserDto> users)
        {
            return mapper.Map<List<UserViewModel>>(users);
        }

    }
}
