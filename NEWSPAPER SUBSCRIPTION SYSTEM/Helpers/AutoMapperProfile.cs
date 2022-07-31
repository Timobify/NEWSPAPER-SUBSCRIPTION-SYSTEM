using AutoMapper;
using NEWSPAPER_SUBSCRIPTION_SYSTEM.Entities;
using NEWSPAPER_SUBSCRIPTION_SYSTEM.Models.NewsPapers;
using NEWSPAPER_SUBSCRIPTION_SYSTEM.Models.Subscriptions;
using NEWSPAPER_SUBSCRIPTION_SYSTEM.Models.Users;

namespace NEWSPAPER_SUBSCRIPTION_SYSTEM.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
            CreateMap<NewsPaper, NewsPaperModel>();
            CreateMap<NewsPaperSaveModel, NewsPaper>();
            CreateMap<Subscription, SubscriptionModel>();
            CreateMap<SubSaveModel, Subscription>();
        }
    }
}