using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dal.Entity;
using Models;

namespace Dal.Helper
{
    public static class Mapper
    {
        public static MapperConfiguration config = new MapperConfiguration(cfg =>
           cfg.CreateMap<UserDto, User>().ReverseMap());
        private static IMapper mapper = config.CreateMapper();

        //private static MapperConfiguration configComment = new MapperConfiguration(cfg =>
        //    cfg.CreateMap<Comment, CommentDto>().ReverseMap().
        //    ForMember(x => x.CommentId, opt => opt.Ignore()));
        //private static IMapper mapperComment = configComment.CreateMapper();
 
        #region UserMapping
        public static User ToUser(UserDto udto)
        {
            return mapper.Map<User>(udto);
        }

        public static UserAccount ToUserAccount(UserAccountDto udto)
        {
            return mapper.Map<UserAccount>(udto);
        }

        public static UserAccountDto ToUserAccountDto(UserAccount udto)
        {
            return mapper.Map<UserAccountDto>(udto);
        }

        public static UserDto ToUserDto(User User)
        {
            return mapper.Map<UserDto>(User);
        }

        public static List<UserDto> ToUserDtoList(List<User> userEntities)
        {
            return mapper.Map<List<UserDto>>(userEntities);
        }
        #endregion
        #region EventMapping
        public static List<EventDto> ToEventDtoList(List<Event> events)
        {
            return mapper.Map<List<EventDto>>(events);
        }

        public static List<InvitationDto> ToInvitationDtoList(List<Invitation> invitations)
        {
            return mapper.Map<List<InvitationDto>>(invitations);
        }

        public static EventDto ToEventDto(Event entity)
        {
            return mapper.Map<EventDto>(entity);
        }

        public static Event ToEvent(EventDto edto)
        {
            //config = new MapperConfiguration(cfg =>
            //cfg.CreateMap<EventDto, Event>().ReverseMap().ForMember(x => x.Comments, opt => opt.Ignore()));
            //mapper = config.CreateMapper();

            Event e = mapper.Map<Event>(edto);
            return e;
        }
        #endregion
        #region InvitaitonMapping
        public static Invitation ToInvitation(InvitationDto invitationDto)
        {
            return mapper.Map<Invitation>(invitationDto);
        }

        public static List<Invitation> ToInvitationList(List<InvitationDto> invitationDto)
        {
            return mapper.Map<List<Invitation>>(invitationDto);
        }
        #endregion
        #region CommentMapping
        public static Comment ToComment(CommentDto CommentDto)
        {
            return mapper.Map<Comment>(CommentDto);
        }

        public static List<Comment> ToCommentList(List<CommentDto> CommentDto)
        {
            return mapper.Map<List<Comment>>(CommentDto);
        }

        public static CommentDto ToCommentDto(Comment Comment)
        {
            
            return mapper.Map<CommentDto>(Comment);
        }

        public static List<CommentDto> ToCommentDtoList(List<Comment> Comment)
        {
            return mapper.Map<List<CommentDto>>(Comment);
        }
        #endregion
    }
}
