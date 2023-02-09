using AutoMapper;
using DoAnBE.Models;
using DoAnBE.ViewModels;

namespace DoAnBE.Helper
{
    public class AutoMapper : Profile
    {
        public AutoMapper() { 
          CreateMap<Menu,MenuModel>().ReverseMap();
          CreateMap<About,AboutModel>().ReverseMap();
          CreateMap<Brand,BrandModel>().ReverseMap();
          CreateMap<Contact,ContactModel>().ReverseMap();
          CreateMap<Customer,CustomerModel>().ReverseMap();
          CreateMap<Feedback,FeedbackModel>().ReverseMap();
          CreateMap<Invoice,InvoiceModel>().ReverseMap();
          CreateMap<Member,MemberModel>().ReverseMap();
          CreateMap<Menu,MenuModel>().ReverseMap();
          CreateMap<Order,OrderModel>().ReverseMap();
          CreateMap<OrderDetail,OrderDetailModel>().ReverseMap();
          CreateMap<Post,PostModel>().ReverseMap();
          CreateMap<PostCategory,PostCategoryModel>().ReverseMap();
          CreateMap<PostComment,PostCommentModel>().ReverseMap();
          CreateMap<Product,ProductModel>().ReverseMap();
          CreateMap<ProductCategory,ProductCategoryModel>().ReverseMap();
          CreateMap<ProductComment,ProductCommentModel>().ReverseMap();
          CreateMap<Slider,SliderModel>().ReverseMap();
          CreateMap<Supplier,SupplierModel>().ReverseMap();
        }
    }
}
